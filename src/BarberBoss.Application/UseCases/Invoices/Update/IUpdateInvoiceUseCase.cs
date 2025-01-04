using BarberBoss.Communication.Requests;

namespace BarberBoss.Application.UseCases.Invoices.Update;

public interface IUpdateInvoiceUseCase
{
    Task Execute(int id, RequestInvoiceJson request);
}