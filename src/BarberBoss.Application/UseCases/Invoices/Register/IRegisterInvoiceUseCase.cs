using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
namespace BarberBoss.Application.UseCases.Invoices.Register;

public interface IRegisterInvoiceUseCase
{
    Task<ResponseRegisteredInvoiceJson> Execute(RequestInvoiceJson request);
}