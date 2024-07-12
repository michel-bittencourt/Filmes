using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<CreateFilmeDTO, Filme>().ReverseMap();
        CreateMap<UpdateFilmeDTO, Filme>().ReverseMap();
        CreateMap<ReadFilmeDTO, Filme>().ReverseMap();
    }
}
