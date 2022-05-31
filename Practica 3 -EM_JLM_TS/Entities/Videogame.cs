using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica3.API.Entities
{
    public class Videogame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string CompanyName { get; set; }
        [MaxLength(15)]
        [Required]
        public string Category { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public Videogame(string nombre)
        {
            Name = nombre.Trim();
        }
    }
}
