using AutoMapper;
using Practica3.API.Entities;

namespace Practica3.API.AutoMapperProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, Models.ReviewDto>();
            CreateMap<Models.ReviewCreationDto, Review>();
            CreateMap<Models.ReviewForUpdateDto, Review>();
        }
    }
}
