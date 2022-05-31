using Microsoft.AspNetCore.Mvc;
using Practica3.API;
using Practica3.API.Models;

namespace VideogamesInfo.API.Controllers
{
    [ApiController]
    [Route("api/videogames")]
    public class VideogamesController : ControllerBase //controller deriva de ControllerBase
    {
        private readonly VideogamesData _videogamesData;

        public VideogamesController(VideogamesData videogamesData)
        {
            _videogamesData = videogamesData;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VideogameDto>> GetVideogames() //JsonResults implementa IActionResults
        {
            return Ok(_videogamesData.Videogames);
        }

        [HttpGet("{id}")]
        public ActionResult<VideogameDto> GetVideogame(int id)
        {
            var videogameToReturn = _videogamesData.Videogames.FirstOrDefault(v => v.Id == id);
            if (videogameToReturn == null)
                return NotFound();
            return Ok(videogameToReturn);
        }
    }
}