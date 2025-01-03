using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Invoices.Register;

public class RegisterInvoiceUseCase : IRegisterInvoiceUseCase
{
    public Task<ResponseRegisteredInvoiceJson> Execute(RequestInvoiceJson request)
    {
        throw new NotImplementedException();
    }
}