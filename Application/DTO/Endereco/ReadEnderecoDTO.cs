using Application.DTO.Cinema;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Endereco;

public record ReadEnderecoDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "O Logradouro deve ter 2 ou mais caracteres.")]
    public string Logradouro { get; set; }

    public int Numero { get; set; }

    public ReadCinemaDTO Cinema { get; set; }
}
