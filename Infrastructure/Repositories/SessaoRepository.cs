using Domain.Entities;
using Domain.Interface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SessaoRepository : GeneralRepository, ISessaoRepository
{
    private readonly ApplicationDbContext _context;

    public SessaoRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sessao>> GetSessoesAsync()
    {
        IEnumerable<Sessao> sessaos = await _context.Sessoes.ToListAsync();
        return sessaos;
    }

    public async Task<Sessao> GetSessaoByIdAsync(int? id)
    {
        Sessao sessao = await _context.Sessoes.SingleOrDefaultAsync(sessao => sessao.Id == id);
        return sessao;
    }
}
