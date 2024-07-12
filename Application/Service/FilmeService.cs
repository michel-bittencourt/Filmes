using Application.Interface;
using Domain.Entities;
using Domain.Interface;

namespace Application.Service;

public class FilmeService : GeneralService, IFilmeService
{
    private readonly IFilmeRepository _filmeRepository;

    public FilmeService(IFilmeRepository filmeRepository) : base(filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }

    public async Task<IEnumerable<Filme>> GetFilmesAsync()
    {
        try
        {
            IEnumerable<Filme> filmes = await _filmeRepository.GetFilmesAsync();

            if (!filmes.Any())
            {
                throw new KeyNotFoundException($"Nenhum filme encontrado.");
            }

            return filmes;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }

    public async Task<Filme> GetFilmeIdAsync(int id)
    {
        try
        {
            Filme filme = await _filmeRepository.GetFilmeByIdAsync(id);

            if (filme == null)
            {
                throw new KeyNotFoundException($"Nenhum filme encontrado.");
            }

            return filme;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }
}
