using Application.DTO.Filme;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDTO, Filme>().ReverseMap();
        CreateMap<UpdateFilmeDTO, Filme>().ReverseMap();
        CreateMap<ReadFilmeDTO, Filme>().ReverseMap();
    }
}
