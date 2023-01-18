using AutoMapper;
using CatalogoVeiculos.Application.Security;
using CatalogoVeiculos.Infra.CrossCutting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CatalogoVeiculos.API
{
    public class Startup : IStartup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get;}
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjection.ConfigureDependenciesService(services);

            var config = new AutoMapper.MapperConfiguration(config =>
            {
                config.AddProfile(new MappingEntidade());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);


            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                //CONFIGURAÇÃO DO APPSETTINGS.JSON
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            

            services.AddControllers();
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Catalogo de Veiculos",
                    Description = "Desenvolvido como parte de desenvolvimento de avaliação técnica",
                    Contact = new OpenApiContact
                    {
                        Name = "Henrique da Silva Lima",
                        Email = "henrikelima.0502@gmail.com",
                        Url = new Uri("https://henriquelima.netlify.app")
                    }
                });
                
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Informe o token gerado no login",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                        Reference = new OpenApiReference {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                        new List<string>()
                    }
                });
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowOrigin");

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder WebAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), WebAppBuilder.Configuration) as IStartup;
            if (startup == null) 
                throw new ArgumentException("Classe Startup.cs está null ou invalida");

            startup.ConfigureServices(WebAppBuilder.Services);
            var app = WebAppBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();
            return WebAppBuilder;
        }
    }
}
