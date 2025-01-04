using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Invoices.Register;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterInvoiceUseCase, RegisterInvoiceUseCase>();
        
    }
}