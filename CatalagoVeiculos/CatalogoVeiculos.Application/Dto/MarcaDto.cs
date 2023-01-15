using System.ComponentModel.DataAnnotations;

namespace CatalogoVeiculos.Application.Dto
{
    public class MarcaDto
    {
        public MarcaDto(int? marcaId, string nomeMarca)
        {
            MarcaId = marcaId;
            NomeMarca = nomeMarca;
        }

        public int? MarcaId { get; set; }

        [Required(ErrorMessage = "O campo NomeMarca é obrigatório")]
        public string NomeMarca { get; set; }
    }
}
