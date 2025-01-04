using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Invoices.Delete;
using BarberBoss.Application.UseCases.Invoices.GetAll;
using BarberBoss.Application.UseCases.Invoices.GetById;
using BarberBoss.Application.UseCases.Invoices.Register;
using BarberBoss.Application.UseCases.Invoices.Update;
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
        services.AddScoped<IGetAllInvoiceUseCase, GetAllInvoiceUseCase>();
        services.AddScoped<IGetInvoiceByIdUseCase, GetInvoiceByIdUseCase>();
        services.AddScoped<IDeleteInvoiceUseCase, DeleteInvoiceUseCase>();
        services.AddScoped<IUpdateInvoiceUseCase, UpdateInvoiceUseCase>();
        
    }
}