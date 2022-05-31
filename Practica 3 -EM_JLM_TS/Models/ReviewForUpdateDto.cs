using System.ComponentModel.DataAnnotations;

namespace Practica3.API.Models
{
    public class ReviewForUpdateDto
    {
        [Required(ErrorMessage = "Agregá un score")]
        public int Score { get; set; }
        [MaxLength(250)]
        public string? Comment { get; set; }
    }
}