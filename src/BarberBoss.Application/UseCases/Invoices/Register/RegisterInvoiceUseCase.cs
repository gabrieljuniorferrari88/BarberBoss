using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Invoices.Register;

public class RegisterInvoiceUseCase : IRegisterInvoiceUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInvoicesWriteOnlyRepository _repository;
    private readonly IMapper _mapper;

    //private readonly IMapper _mapper;

    public RegisterInvoiceUseCase(
        IUnitOfWork unitOfWork,
        IInvoicesWriteOnlyRepository repository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredInvoiceJson> Execute(RequestInvoiceJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Invoice>(request);
        
        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredInvoiceJson>(entity);
    }
    
    private void Validate(RequestInvoiceJson request)
    {
        var validator = new InvoiceValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}