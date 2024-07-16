using Domain.Entities;

namespace Application.Interface;

public interface ICinemaService : IGeneralService
{
    Task<IEnumerable<Cinema>> GetCinemasAsync();
    Task<Cinema> GetCinemaByIdAsync(int id);
}
