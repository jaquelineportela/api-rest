using AutoMapper;
using api_rest.Resources;
using api_rest.Extensions;
using api_rest.Domain.Models;

namespace api_rest.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<User, UserResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitSearch, opt => opt.MapFrom(src => src.UnitSearch.ToDescriptionString()));
        }
    }
}
