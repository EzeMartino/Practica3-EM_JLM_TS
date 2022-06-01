namespace Practica3.API.Models
{
    public class VideogameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public string? Category { get; set; }

        public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
