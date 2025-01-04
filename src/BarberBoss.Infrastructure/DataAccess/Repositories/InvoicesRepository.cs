using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Invoices;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure.DataAccess.Repositories;

internal class InvoicesRepository : IInvoicesReadOnlyRepository, IInvoicesUpdateOnlyRepository, IInvoicesWriteOnlyRepository
{
    private readonly BarberBossDbContext _dbContext;

    public InvoicesRepository(BarberBossDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Add(Invoice invoice) => await _dbContext.Invoices.AddAsync(invoice);
    public async Task<List<Invoice>> GetAll()
    {
        return await _dbContext.Invoices.AsNoTracking().ToListAsync();
    }

    async Task<Invoice?> IInvoicesReadOnlyRepository.GetById(int id)
    {
        return await _dbContext.Invoices.AsNoTracking().FirstOrDefaultAsync(invoice => invoice.Id == id);
    }

    public async Task<List<Invoice>> FilterByMonth(DateOnly date)
    {
        var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

        var daysIsMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
        var endDate = new DateTime(year: date.Year, month: date.Month,
            day: daysIsMonth, hour: 23, minute: 59, second: 59);

        return await _dbContext
            .Invoices
            .AsNoTracking()
            .Where(x => x.Date >= startDate && x.Date <= endDate)
            .OrderBy(x => x.Date)
            .ThenBy(x => x.Title)
            .ToListAsync();
    }

    async Task<Invoice?> IInvoicesUpdateOnlyRepository.GetById(int id)
    {
        return await _dbContext.Invoices.FirstOrDefaultAsync(invoice => invoice.Id == id);
    }
    
    public async Task<bool> Delete(int id)
    {
        var result = await _dbContext.Invoices.FirstOrDefaultAsync(invoice => invoice.Id == id);
        
        if(result is null)
        {
            return false;
        }

        _dbContext.Invoices.Remove(result);

        return true;
    }

    public void Update(Invoice invoice)
    {
        _dbContext.Invoices.Update(invoice);
    }
}