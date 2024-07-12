using Domain.Entities;
using Domain.Interface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FilmeRepository : GeneralRepository, IFilmeRepository
{
    private readonly ApplicationDbContext _context;

    public FilmeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Filme>> GetFilmesAsync()
    {
        IEnumerable<Filme> filmes = await _context.Filmes.ToListAsync();

        return filmes;
    }

    public async Task<Filme?> GetFilmeByIdAsync(int? id)
    {
        Filme? filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);

        return filme;
    }
}
