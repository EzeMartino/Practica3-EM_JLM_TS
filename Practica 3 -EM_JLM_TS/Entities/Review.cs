using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica3.API.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Score { get; set; }
        [MaxLength(250)]
        public string Comment { get; set; }
        [ForeignKey("VideogameId")]
        public Videogame? Videogame { get; set; }
        public int VideogameId { get; set; }
    }
}

