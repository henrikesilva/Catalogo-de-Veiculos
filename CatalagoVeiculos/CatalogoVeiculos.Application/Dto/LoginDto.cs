using System.ComponentModel.DataAnnotations;

namespace CatalogoVeiculos.Application.Dto
{
    public class LoginDto
    {
        public LoginDto(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        [Required(ErrorMessage = "O campo Usuário é obrigatório")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
