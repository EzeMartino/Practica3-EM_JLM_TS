using Microsoft.AspNetCore.Mvc;
using Practica3.API;
using Practica3.API.Models;
using Practica3.API.Entities;

namespace VideogamesInfo.API.Controllers
{
    [ApiController]
    [Route("api/videogames")]
    public class VideogamesController : ControllerBase
    {
        private readonly VideogamesData _videogamesData;

        public VideogamesController(VideogamesData videogamesData)
        {
            _videogamesData = videogamesData;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VideogameDto>> GetVideogames()
        {
            return Ok(_videogamesData.Videogames);
        }

        [HttpGet("{id}", Name = "GetVideogame")]
        public ActionResult<VideogameDto> GetVideogame(int id)
        {
            var videogameToReturn = _videogamesData.Videogames.FirstOrDefault(v => v.Id == id);
            if (videogameToReturn == null)
                return NotFound();
            return Ok(videogameToReturn);
        }

        [HttpPost]
        public ActionResult<VideogameDto> CreateVideogame(VideogameDto videogame)
        {
            if (videogame is null)
            {
                return NotFound();
            }

            var maxIdVideogame = _videogamesData.Videogames.Max(v => v.Id);

            var newVideogame = new VideogameDto
            {
                Id = ++maxIdVideogame,
                Name = videogame.Name,
                CompanyName = videogame.CompanyName,
                Category = videogame.Category,
                Reviews = videogame.Reviews,
            };

            _videogamesData.Videogames.Add(newVideogame);

            //return NoContent();

            return CreatedAtRoute(//CreatedAtRoute es para q devuelva 201, el 200 de post.
                "GetVideogame", //El primer parámetro es el Name del endpoint que hace el Get
                new //El segundo los parametros q necesita ese endpoint
                {
                    id = newVideogame.Id
                },
                newVideogame);//El tercero es el objeto creado. 
        }

        [HttpPut("{idVideogame}")]
        public ActionResult UpdateVideogame(int idVideogame, VideogameForUpdateDto videogame)
        {
            var videogameInDB = _videogamesData.Videogames.Where(v => v.Id == idVideogame).FirstOrDefault();

            if (videogameInDB == null)
                return NotFound();

            videogameInDB.Name = videogame.Name;
            videogameInDB.CompanyName = videogame.CompanyName;
            videogameInDB.Category = videogame.Category;
            videogameInDB.Reviews = videogame.Reviews;

            return NoContent();
        }

        [HttpDelete("{idVideogame}")]
        public ActionResult DeleteVideogame(int idVideogame)
        {
            var videogame = _videogamesData.Videogames.FirstOrDefault(c => c.Id == idVideogame);
            if (videogame is null)
                return NotFound();


            _videogamesData.Videogames.Remove(videogame);

            return NoContent();
        }
    }
}