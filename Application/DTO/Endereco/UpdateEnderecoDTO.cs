using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Endereco;

public record UpdateEnderecoDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "O Logradouro deve ter 2 ou mais caracteres.")]
    public string Logradouro { get; private set; }

    public int Numero { get; private set; }
}
