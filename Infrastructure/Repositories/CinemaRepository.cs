using Domain.Entities;
using Domain.Interface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CinemaRepository : GeneralRepository, ICinemaRepository
{
    private readonly ApplicationDbContext _context;
    public CinemaRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cinema>> GetCinemasAsync()
    {
        IEnumerable<Cinema> cinemas = await _context.Cinemas.ToListAsync();

        return cinemas;
    }

    public async Task<Cinema?> GetCinemaAsync(int? id)
    {
        Cinema? cinema = await _context.Cinemas.SingleOrDefaultAsync(cinema => cinema.Id == id);

        return cinema;
    }

}
