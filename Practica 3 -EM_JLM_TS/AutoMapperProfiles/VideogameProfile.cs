using AutoMapper;

namespace Practica3.API.AutoMapperProfiles
{
    public class VideogameProfile : Profile
    {
        public VideogameProfile()
        {
            CreateMap<Entities.Videogame, Models.VideogameWithoutReviewsDto>();
            CreateMap<Entities.Videogame, Models.VideogameDto>();
        }
    }
}
