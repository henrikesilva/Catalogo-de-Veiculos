namespace CatalogoVeiculos.Domain.Entities
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public decimal Preco { get; set; }

        private DateTime _dataCriacao;
        public DateTime DataCriacao { get { return _dataCriacao; } set { _dataCriacao = (value == DateTime.MinValue ? DateTime.UtcNow.AddHours(-3d) : value); } }

        private DateTime _dataAtualizacao;
        public DateTime DataAtualizacao { get { return _dataAtualizacao; } set { _dataAtualizacao = (value == DateTime.MinValue ? DateTime.UtcNow.AddHours(-3d) : value); } }

        public bool StatusVeiculo { get; set; }
        public int ModeloId { get; set; }
        public int UsuarioId { get; set; }


        public virtual Modelo Modelo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
