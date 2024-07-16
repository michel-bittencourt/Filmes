using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Cinema;

public record CreateCinemaDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "O nome deve ter 2 ou mais caracteres.")]
    public string Nome { get; init; }
    public int EnderecoId { get; init; }
}
