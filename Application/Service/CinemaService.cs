using Application.Interface;
using Domain.Entities;
using Domain.Interface;

namespace Application.Service;

public class CinemaService : GeneralService, ICinemaService
{
    private readonly ICinemaRepository _cinemaRepository;

    public CinemaService(ICinemaRepository cinemaRepository) : base(cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }

    public async Task<IEnumerable<Cinema>> GetCinemasAsync()
    {
        try
        {
            IEnumerable<Cinema> cinemas = await _cinemaRepository.GetCinemasAsync();

            if (!cinemas.Any())
            {
                throw new KeyNotFoundException($"Nenhum cinema encontrado.");
            }

            return cinemas;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }

    public async Task<Cinema> GetCinemaByIdAsync(int id)
    {
        try
        {
            Cinema cinema = await _cinemaRepository.GetCinemaByIdAsync(id);

            if (cinema == null)
            {
                throw new KeyNotFoundException($"Nenhum filme encontrado.");
            }

            return cinema;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }
}
