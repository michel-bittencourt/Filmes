using Application.DTO.Endereco;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDTO, Endereco>().ReverseMap();
        CreateMap<ReadEnderecoDTO, Endereco>().ReverseMap();
        CreateMap<UpdateEnderecoDTO, Endereco>().ReverseMap();
    }
}
