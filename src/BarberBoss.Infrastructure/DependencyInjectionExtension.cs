using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Infrastructure.DataAccess;
using BarberBoss.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IInvoicesWriteOnlyRepository, InvoicesRepository>();
        services.AddScoped<IInvoicesReadOnlyRepository, InvoicesRepository>();
        services.AddScoped<IInvoicesUpdateOnlyRepository, InvoicesRepository>();
    }
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        
        services.AddDbContext<BarberBossDbContext>(config => config.UseSqlServer(connectionString));
    }
}