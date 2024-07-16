using System.ComponentModel.DataAnnotations;
using Application.DTO.Endereco;
using Application.DTO.Sessao;

namespace Application.DTO.Cinema;

public record ReadCinemaDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "O nome deve ter 2 ou mais caracteres.")]
    public string Nome { get; init; }
    public ReadEnderecoDTO Endereco { get; set; }
    public ICollection<ReadSessaoDTO> Sessoes { get; set; }
}
