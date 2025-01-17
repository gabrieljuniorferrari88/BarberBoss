using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;

namespace BarberBoss.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestInvoiceJson, Invoice>();
    }
    
    private void EntityToResponse()
    {
        CreateMap<Invoice, ResponseRegisteredInvoiceJson>();
        CreateMap<Invoice, ResponseShortInvoiceJson>();
        CreateMap<Invoice, ResponseInvoiceJson>();

    }
}