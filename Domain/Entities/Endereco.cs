using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Endereco : Entity
{
    public Endereco(string logradouro, int numero)
    {
        Logradouro = logradouro;
        Numero = numero;
    }

    [Required]
    [MinLength(2, ErrorMessage = "O Logradouro deve ter 2 ou mais caracteres.")]
    public string Logradouro { get; private set; }

    public int Numero { get; private set; }

    public virtual Cinema Cinema { get; set; }
}
