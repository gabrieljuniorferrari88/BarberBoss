namespace BarberBoss.Communication.Responses;

public class ResponseShortInvoiceJson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}