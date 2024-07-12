namespace Application.Interface;

public interface IGeneralService
{
    Task Add<T>(T entity) where T : class;
    Task Update<T>(T entity) where T : class;
    Task Remove<T>(T entity) where T : class;
}
