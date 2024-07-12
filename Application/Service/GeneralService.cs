using Application.Interface;
using Domain.Interface;

namespace Application.Service;

public class GeneralService : IGeneralService
{
    private readonly IGeneralRepository _generalRepository;

    public GeneralService(IGeneralRepository generalRepository)
    {
        _generalRepository = generalRepository;
    }

    public async Task Add<T>(T entity) where T : class
    {
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _generalRepository.Add(entity);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }

    public async Task Remove<T>(T entity) where T : class
    {
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _generalRepository.Remove(entity);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }

    public async Task Update<T>(T entity) where T : class
    {
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _generalRepository.Update(entity);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro: " + ex.Message);
        }
    }
}
