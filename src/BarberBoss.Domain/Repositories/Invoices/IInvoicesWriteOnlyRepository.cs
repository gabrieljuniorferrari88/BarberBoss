using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Invoices;

public interface IInvoicesWriteOnlyRepository
{
    Task Add(Invoice invoice);
    /// <summary>
    /// This function returns TRUE if the deletion was successful otherwise returns FALSE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(int id);
}