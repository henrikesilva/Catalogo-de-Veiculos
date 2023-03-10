namespace CatalogoVeiculos.Application.Dto
{
    public class ModeloDto
    {
        public int? ModeloId { get; set; }
        public string NomeModelo { get; set; }
        public bool StatusModelo { get; set; }
        public int MarcaId { get; set; }

        public virtual MarcaDto? Marca { get; set; }
    }
}
