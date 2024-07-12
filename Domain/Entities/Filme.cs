using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public sealed class Filme : Entity
{
    [Required]
    [MinLength(2, ErrorMessage = "O Titulo deve ter 2 ou mais caracteres.")]
    public string Titulo { get; private set; }

    [Required]
    [MinLength(2, ErrorMessage = "O genero deve ter 2 ou mais caracteres.")]
    public string Genero { get; private set; }

    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "A duração deve ser maior que 0.")]
    public float Duracao { get; private set; }

    public Filme(string titulo, string genero, float duracao)
    {
        Titulo = titulo;
        Genero = genero;
        Duracao = duracao;
    }
}
