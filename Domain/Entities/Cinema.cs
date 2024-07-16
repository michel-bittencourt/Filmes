using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Cinema : Entity
{
    public Cinema(string nome)
    {
        Nome = nome;
    }

    [Required]
    [MinLength(2, ErrorMessage = "O Nome deve ter 2 ou mais caracteres.")]
    public string Nome { get; private set; }

    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; } = new List<Sessao>();

}
