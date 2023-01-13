using AutoMapper;
using CatalogoVeiculos.Infra.CrossCutting;

namespace CatalogoVeiculos.API
{
    public class Startup : IStartup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get;}
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjection.ConfigureDependenciesService(services);

            var config = new AutoMapper.MapperConfiguration(config =>
            {
                config.AddProfile(new MappingEntidade());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);


            services.AddControllers();
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(opt =>
            {
                opt.AddPolicy(MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyOrigin()
                           .AllowAnyMethod();
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

            app.UseHttpsRedirection();

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
