using Application.DTO.Cinema;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDTO, Cinema>().ReverseMap();
        CreateMap<ReadCinemaDTO, Cinema>().ReverseMap()
            .ForMember(cinemaDTO => cinemaDTO.Endereco,
                       opt => opt.MapFrom(cinema => cinema.Endereco))
            .ForMember(cinemaDTO => cinemaDTO.Sessoes,
                       opt => opt.MapFrom(cinema => cinema.Sessoes));
        CreateMap<UpdateCinemaDTO, Cinema>().ReverseMap();
    }
}
