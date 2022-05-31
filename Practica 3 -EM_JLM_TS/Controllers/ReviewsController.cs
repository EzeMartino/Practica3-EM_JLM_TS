using VideogamesInfo.API;
using Microsoft.AspNetCore.Mvc;
using Practica3.API;
using Practica3.API.Models;

namespace VideogamesInfo.API.Controllers
{
    [ApiController]
    [Route("api/videogames/{idVideogame}/reviews")] //Ya que esto es dependiente de ciudades necesito que primero me indique la ciudad
    public class ReviewsController : ControllerBase
    {
        private readonly VideogamesData _videogamesData;

        public ReviewsController(VideogamesData videogamesData)
        {
            _videogamesData = videogamesData;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ReviewDto>> GetReview(int idVideogame)
        {
            var videogame = _videogamesData.Videogames.FirstOrDefault(x => x.Id == idVideogame);
            if (videogame == null)
                return NotFound();

            return Ok(videogame.Reviews);
        }

        [HttpGet("{idReview}", Name = "GetReview")] // El name se lo da para usarlo en el POST.
        public ActionResult<ReviewDto> GetReview(int idVideogame, int idReview)
        {
            var videogame = _videogamesData.Videogames.FirstOrDefault(v => v.Id == idVideogame);

            if (videogame == null)
                return NotFound();

            var review = videogame.Reviews.FirstOrDefault(v => v.Id == idReview);

            if (review == null)
                return NotFound();

            return Ok(review);
        }

        [HttpPost]
        public ActionResult<ReviewDto> CreateReview(int idVideogame, ReviewCreationDto review)
        {
            var videogame = _videogamesData.Videogames.FirstOrDefault(v => v.Id == idVideogame);
            if (videogame is null)
            {
                return NotFound();
            }

            var maxIdReviews = _videogamesData.Videogames.SelectMany(v => v.Reviews).Max(r => r.Id);

            var newReview = new ReviewDto
            {
                Id = ++maxIdReviews,
                Score = review.Score,
                Comment = review.Comment
            };

            videogame.Reviews.Add(newReview);

            return CreatedAtRoute(//CreatedAtRoute es para q devuelva 201, el 200 de post.
                "GetReview", //El primer parámetro es el Name del endpoint que hace el Get
                new //El segundo los parametros q necesita ese endpoint
                {
                    idVideogame,
                    idReview = newReview.Id
                },
                newReview);//El tercero es el objeto creado. 
        }

        [HttpPut("{idReview}")]
        public ActionResult UpdateReview(int idVideogame, int idReview, ReviewForUpdateDto review)
        {
            var videogame = _videogamesData.Videogames.FirstOrDefault(v => v.Id == idVideogame);

            if (videogame == null)
                return NotFound();

            var reviewInDB = videogame.Reviews.FirstOrDefault(p => p.Id == idReview);
            if (reviewInDB == null)
                return NotFound();

            reviewInDB.Score = review.Score;
            reviewInDB.Comment = review.Comment;

            return NoContent();
        }


        [HttpDelete("{idReview}")]
        public ActionResult DeleteReview(int idVideogame, int idReview)
        {
            var videogame = _videogamesData.Videogames.FirstOrDefault(c => c.Id == idVideogame);
            if (videogame is null)
                return NotFound();

            var reviewToEliminate = videogame.Reviews
                .FirstOrDefault(r => r.Id == idReview);
            if (reviewToEliminate is null)
                return NotFound();

            videogame.Reviews.Remove(reviewToEliminate);

            return NoContent();
        }
    }
}
