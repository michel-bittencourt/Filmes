using Application.DTO.Sessao;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDTO, Sessao>().ReverseMap();
        CreateMap<ReadSessaoDTO, Sessao>().ReverseMap();
        CreateMap<UpdateSessaoDTO, Sessao>().ReverseMap();
    }
}
