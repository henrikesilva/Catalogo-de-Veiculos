namespace CatalogoVeiculos.Domain.Entities
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int ModeloId { get; set; }
        public int UsuarioId { get; set; }
    }
}
