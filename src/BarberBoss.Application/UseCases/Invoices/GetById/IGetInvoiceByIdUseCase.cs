using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Invoices.GetById;

public interface IGetInvoiceByIdUseCase
{
    Task<ResponseInvoiceJson> Execute(int id);
}