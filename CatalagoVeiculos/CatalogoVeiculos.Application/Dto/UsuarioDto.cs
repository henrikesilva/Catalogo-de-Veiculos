namespace CatalogoVeiculos.Application.Dto
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string LoginUsuario { get; set; }
        public string? Senha { get; set; }
        public bool Administrador { get; set; }

    }
}
