using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Invoices;

public interface IInvoicesUpdateOnlyRepository
{
    Task<Invoice?> GetById(int id);
    void Update(Invoice invoice);
}