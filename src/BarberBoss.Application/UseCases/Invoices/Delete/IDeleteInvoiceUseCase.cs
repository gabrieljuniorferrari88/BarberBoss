namespace BarberBoss.Application.UseCases.Invoices.Delete;

public interface IDeleteInvoiceUseCase
{
    Task Execute(int id);
}