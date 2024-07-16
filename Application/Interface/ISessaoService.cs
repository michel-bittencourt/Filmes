using Domain.Entities;

namespace Application.Interface;

public interface ISessaoService : IGeneralService
{
    Task<IEnumerable<Sessao>> GetSessoesAsync();
    Task<Sessao> GetSessaoByIdAsync(int id);
}
