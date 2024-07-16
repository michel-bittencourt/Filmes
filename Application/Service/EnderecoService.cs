using Application.Interface;
using Domain.Entities;
using Domain.Interface;

namespace Application.Service;

public class EnderecoService : GeneralService, IEnderecoService
{
    private readonly IEnderecoRepository _enderecoRepository;

    public EnderecoService(IEnderecoRepository enderecoRepository) : base(enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }

    public async Task<Endereco> GetEnderecoByIdAsync(int id)
    {
        try
        {
            Endereco endereco = await _enderecoRepository.GetEnderecoById(id);

            if (endereco == null)
            {
                throw new KeyNotFoundException($"Nenhum filme encontrado.");
            }

            return endereco;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }

    public async Task<IEnumerable<Endereco>> GetEnderecosAsync()
    {
        try
        {
            IEnumerable<Endereco> enderecos = await _enderecoRepository.GetEnderecosAsync();

            if (!enderecos.Any())
            {
                throw new KeyNotFoundException($"Nenhum endereço encontrado.");
            }

            return enderecos;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }
}
