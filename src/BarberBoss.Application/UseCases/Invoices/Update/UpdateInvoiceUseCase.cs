using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Invoices.Update;

public class UpdateInvoiceUseCase : IUpdateInvoiceUseCase
{
    private readonly IInvoicesUpdateOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInvoiceUseCase(
        IInvoicesUpdateOnlyRepository repository,
        IMapper mapper,
        IUnitOfWork unitOfWork
        )
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(int id, RequestInvoiceJson request)
    {
        Validate(request);

        var invoice = await _repository.GetById(id);

        if (invoice is null)
        {
            throw new NotFoundException(ResourceErrorMessages.INVOICE_NOT_FOUND);
        }

        _mapper.Map(request, invoice);
        
        _repository.Update(invoice);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestInvoiceJson request)
    {
        var validator = new InvoiceValidator();
        var result = validator.Validate(request);

        if (result.IsValid != false) return;
        
        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
}