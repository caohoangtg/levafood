using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Features.Categories.Commands;
using Catalog.Application.ViewModels;
using Catalog.Domain.Entities;

namespace Catalog.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ModifierGroupDto, ModifierGroup>().ReverseMap();
            CreateMap<ModifierDto, Modifier>().ReverseMap();
            CreateMap<VariantDto, Variant>().ReverseMap();
            CreateMap<PhotoDto, Photo>().ReverseMap();
            CreateMap<ProductModifierDto, ProductModifier>().ReverseMap();
            CreateMap<ProductModifierGroupDto, ProductModifierGroup>().ReverseMap();


            CreateMap<ModifierGroupViewModel, ModifierGroup>().ReverseMap();
        }
    }
}
