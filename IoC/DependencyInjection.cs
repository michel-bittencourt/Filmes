using Application.Interface;
using Application.Service;
using Domain.Interface;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("FilmesConnectionDb"), b =>
                b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IGeneralRepository, GeneralRepository>();
        services.AddScoped<IGeneralService, GeneralService>();

        services.AddScoped<IFilmeRepository, FilmeRepository>();
        services.AddScoped<IFilmeService, FilmeService>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }

    public static IServiceCollection AddGeneralConfig(this IServiceCollection services, IConfiguration configuration)
    {
        AddInfrastructure(services, configuration);
        AddApplication(services);

        return services;
    }
}
