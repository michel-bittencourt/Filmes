using Domain.Interface;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class GeneralRepository : IGeneralRepository
{
    private readonly ApplicationDbContext _context;

    public GeneralRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Add<T>(T entity) where T : class
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();

    }

    public async Task Update<T>(T entity) where T : class
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove<T>(T entity) where T : class
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
