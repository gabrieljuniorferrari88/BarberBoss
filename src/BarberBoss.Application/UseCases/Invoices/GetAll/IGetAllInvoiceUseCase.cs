using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Invoices.GetAll;

public interface IGetAllInvoiceUseCase
{
    Task<ResponseInvoicesJson> Execute();
}