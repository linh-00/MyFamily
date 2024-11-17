using AutoMapper;
using Inc.MyFamily.Application.DTOs;
using ChildrenEntitie = Inc.MyFamily.Domain.Entities.Children;

namespace Inc.MyFamily.IoC.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Children, ChildrenEntitie>().ReverseMap();
        }
    }
}
