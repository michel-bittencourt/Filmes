using Application.Interface;
using Domain.Entities;
using Domain.Interface;

namespace Application.Service;

public class SessaoService : GeneralService, ISessaoService
{
    private readonly ISessaoRepository _sessaoRepository;

    public SessaoService(ISessaoRepository sessaoRepository) : base(sessaoRepository)
    {
        _sessaoRepository = sessaoRepository;
    }
    public async Task<IEnumerable<Sessao>> GetSessoesAsync()
    {
        try
        {
            IEnumerable<Sessao> sessoes = await _sessaoRepository.GetSessoesAsync();

            if (!sessoes.Any())
            {
                throw new KeyNotFoundException($"Nenhuma sessão encontrado.");
            }

            return sessoes;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }

    public async Task<Sessao> GetSessaoByIdAsync(int id)
    {
        try
        {
            Sessao sessao = await _sessaoRepository.GetSessaoByIdAsync(id);

            if (sessao == null)
            {
                throw new KeyNotFoundException($"Nenhum filme encontrado.");
            }

            return sessao;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }
}
