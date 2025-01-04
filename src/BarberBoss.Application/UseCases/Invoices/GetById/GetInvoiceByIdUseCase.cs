using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.Invoices;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionsBase;

namespace BarberBoss.Application.UseCases.Invoices.GetById;

public class GetInvoiceByIdUseCase: IGetInvoiceByIdUseCase
{
    private readonly IInvoicesReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetInvoiceByIdUseCase(
        IInvoicesReadOnlyRepository repository,
        IMapper mapper
        )
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseInvoiceJson> Execute(int id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.INVOICE_NOT_FOUND);
        }

        return _mapper.Map<ResponseInvoiceJson>(result);
    }
}