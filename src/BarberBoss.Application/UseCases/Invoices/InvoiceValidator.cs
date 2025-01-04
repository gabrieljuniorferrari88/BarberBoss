using BarberBoss.Communication.Requests;
using BarberBoss.Exception;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Invoices;

public class InvoiceValidator : AbstractValidator<RequestInvoiceJson>
{
    public InvoiceValidator()
    {
        RuleFor(invoice => invoice.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(invoice => invoice.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(invoice => invoice.Date).LessThanOrEqualTo(DateTime.Now)
            .WithMessage(ResourceErrorMessages.INVOICES_CANNOT_FOR_THE_FUTURE);
        RuleFor(invoice => invoice.ReceiptType).IsInEnum().WithMessage(ResourceErrorMessages.RECEIPT_TYPE_INVALID);
    }
}