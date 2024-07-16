using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Filme;

public record ReadFilmeDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "O Titulo deve ter 2 ou mais caracteres.")]
    public string Titulo { get; init; }

    [Required]
    [MinLength(2, ErrorMessage = "O genero deve ter 2 ou mais caracteres.")]
    public string Genero { get; init; }

    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "A duração deve ser maior que 0.")]
    public float Duracao { get; init; }
}
