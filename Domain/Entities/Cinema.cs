namespace Domain.Entities;

public sealed class Cinema : Entity
{
    public string Nome { get; private set; }

    public Cinema(string nome)
    {
        Nome = nome;
    }
}
