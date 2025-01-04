using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Requests;
using Bogus;

namespace CommonTestUtilities.Requests;

public class RequestRegisterInvoiceJsonBuilder
{
    public static RequestInvoiceJson Build()
    {
        return new Faker<RequestInvoiceJson>("pt_BR")
            .RuleFor(x => x.Title, faker => faker.Commerce.ProductName())
            .RuleFor(x => x.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(x => x.Date, faker => faker.Date.Past())
            .RuleFor(x => x.Amount, faker => faker.Random.Decimal(min: 1, max: 100))
            .RuleFor(x => x.ReceiptType, faker => faker.PickRandom<ReceiptType>());
    }
}