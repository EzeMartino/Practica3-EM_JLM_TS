using System.ComponentModel.DataAnnotations;

namespace Practica3.API.Models
{
    public class VideogameForUpdateDto
    {
        [Required(ErrorMessage = "Agregá un nombre")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Agregá una compañía")]
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = "Agregá una categoría")]
        public string? Category { get; set; }

        public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}