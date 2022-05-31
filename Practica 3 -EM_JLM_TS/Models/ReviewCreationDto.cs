using System.ComponentModel.DataAnnotations;

namespace Practica3.API.Models
{
    public class ReviewCreationDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
    }
}
