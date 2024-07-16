using Domain.Entities;

namespace Domain.Interface;

public interface ISessaoRepository : IGeneralRepository
{
    Task<IEnumerable<Sessao>> GetSessoesAsync();
    Task<Sessao> GetSessaoByIdAsync(int? id);
}
