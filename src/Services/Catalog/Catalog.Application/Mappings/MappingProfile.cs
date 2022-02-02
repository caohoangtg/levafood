using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ModifierGroupDto, ModifierGroup>().ReverseMap();
            CreateMap<ModifierDto, Modifier>().ReverseMap();
            CreateMap<VariantDto, Variant>().ReverseMap();
            CreateMap<PhotoDto, Photo>().ReverseMap();
            CreateMap<ProductModifierDto, ProductModifier>().ReverseMap();
            CreateMap<ProductModifierGroupDto, ProductModifierGroup>().ReverseMap();


            //CreateMap<ModifierGroup, ModifierGroupDto>().ReverseMap();
            //CreateMap<Modifier, ProductModifierDto>().ReverseMap();
        }
    }
}
