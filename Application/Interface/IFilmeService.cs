using Domain.Entities;

namespace Application.Interface;

public interface IFilmeService : IGeneralService
{
    Task<IEnumerable<Filme>> GetFilmesAsync();
    Task<Filme> GetFilmeIdAsync(int id);
}
