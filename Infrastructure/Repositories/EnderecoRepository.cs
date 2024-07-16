using Domain.Entities;
using Domain.Interface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EnderecoRepository : GeneralRepository, IEnderecoRepository
{
    private readonly ApplicationDbContext _context;

    public EnderecoRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Endereco>> GetEnderecosAsync()
    {
        IEnumerable<Endereco> enderecos = await _context.Enderecos.ToListAsync();

        return enderecos;
    }

    public async Task<Endereco> GetEnderecoById(int? id)
    {
        Endereco endereco = await _context.Enderecos.SingleOrDefaultAsync(endereco => endereco.Id == id);

        return endereco;
    }
}
