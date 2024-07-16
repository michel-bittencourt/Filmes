using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Endereco;

public record CreateEnderecoDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "O Logradouro deve ter 2 ou mais caracteres.")]
    public string Logradouro { get; set; }

    public int Numero { get; set; }
}
