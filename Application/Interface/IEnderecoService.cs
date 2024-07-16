using Domain.Entities;

namespace Application.Interface;

public interface IEnderecoService : IGeneralService
{
    Task<IEnumerable<Endereco>> GetEnderecosAsync();
    Task<Endereco> GetEnderecoByIdAsync(int id);
}
