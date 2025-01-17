using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.Invoices;
namespace BarberBoss.Application.UseCases.Invoices.GetAll;

public class GetAllInvoiceUseCase : IGetAllInvoiceUseCase
{
    private readonly IInvoicesReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllInvoiceUseCase(
        IInvoicesReadOnlyRepository repository,
        IMapper mapper
        )
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseInvoicesJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseInvoicesJson
        {
            Invoices = _mapper.Map<List<ResponseShortInvoiceJson>>(result)
        };
    }
}