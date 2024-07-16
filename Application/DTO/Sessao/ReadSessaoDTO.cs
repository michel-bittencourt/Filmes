using Application.DTO.Cinema;
using Application.DTO.Filme;

namespace Application.DTO.Sessao;

public class ReadSessaoDTO
{
    public ReadFilmeDTO Filme { get; set; }
    public ReadCinemaDTO Cinema { get; set; }
}
