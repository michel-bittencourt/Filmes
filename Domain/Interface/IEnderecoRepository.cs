using Domain.Entities;

namespace Domain.Interface;

public interface IEnderecoRepository : IGeneralRepository
{
    Task<IEnumerable<Endereco>> GetEnderecosAsync();
    Task<Endereco> GetEnderecoById(int? id);
}
