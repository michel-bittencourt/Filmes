using Domain.Entities;

namespace Domain.Interface;

public interface IFilmeRepository : IGeneralRepository
{
    Task<IEnumerable<Filme>> GetFilmesAsync();
    Task<Filme?> GetFilmeByIdAsync(int? id);
}
