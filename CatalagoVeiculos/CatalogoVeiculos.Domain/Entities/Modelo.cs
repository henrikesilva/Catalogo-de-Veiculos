namespace CatalogoVeiculos.Domain.Entities
{
    public class Modelo
    {
        public int ModeloId { get; set; }
        public string NomeModelo { get; set; }
        public int MarcaId { get; set; }
        public bool StatusModelo { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
