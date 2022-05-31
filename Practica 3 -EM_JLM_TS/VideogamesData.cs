using Practica3.API.Models;

namespace Practica3.API
{
    public class VideogamesData
    {
        public List<VideogameDto> Videogames { get; set; }

        public VideogamesData()
        {
            Videogames = new List<VideogameDto>()
            {
                new VideogameDto()
                {
                     Id = 1,
                     Name = "Shadow of the Tomb Raider",
                     CompanyName = "Eidos Montréal, Nixxes Software",
                     Category = "Adventure, Action",
                     Reviews = new List<ReviewDto>()
                     {
                         new ReviewDto() {
                             Id = 1,
                             Score = 9,
                             Comment = "Un juego espectacular, con muy buenos gráficos y una historia bien desarrollada",
                         },
                          new ReviewDto() {
                             Id = 2,
                             Score = 10,
                             Comment = "El mejor juego de aventuras del mercado" },
                     }
                },
                new VideogameDto()
                {
                    Id = 2,
                    Name = "Bioshock",
                    CompanyName = "2k Games",
                    Category = "FPS, Action, Adventure, Thriller",
                    Reviews = new List<ReviewDto>()
                     {
                         new ReviewDto() {
                             Id = 3,
                             Score = 8,
                             Comment = "Un juego retro-futurista de terror, muy recomendable" },
                          new ReviewDto() {
                             Id = 4,
                             Score = 5,
                             Comment = "Se hace muy largo y es poco rejugable" },
                     }
                },
                new VideogameDto()
                {
                    Id= 3,
                    Name = "League of Legends",
                    CompanyName = "Riot Games",
                    Category = "MOBA",
                    Reviews = new List<ReviewDto>()
                     {
                         new ReviewDto() {
                             Id = 5,
                             Score = 0,
                             Comment = "Desearía no haberlo jugado nunca" },
                          new ReviewDto() {
                             Id = 6,
                             Score = 7,
                             Comment = "Los gráficos son malos pero es divertido para jugar con amigos",},
                          new ReviewDto()
                          {
                             Id = 7,
                             Score = 10,
                             Comment = "El mejor juego de la historia, lo juego todo el día. Ya casi salgo de hierro",
                          }
                     }
                }
            };
        }
    }
}
