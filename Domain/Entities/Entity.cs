using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}
