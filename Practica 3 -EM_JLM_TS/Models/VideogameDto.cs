using Practica3.API.Models;

namespace Practica3.API.Models;
public class VideogameDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? CompanyName { get; set; }
    public string? Category { get; set; }

    public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>(); //Lo seteamos a una nueva colección para evitar que retorne un null en algún momento de la ejecución.

    public int CantidadPuntosDeInteres
    {
        get { return Reviews.Count; }
    }
}