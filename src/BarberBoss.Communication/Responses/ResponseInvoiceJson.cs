using BarberBoss.Communication.Enums;
namespace BarberBoss.Communication.Responses;

public class ResponseInvoiceJson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public ReceiptType ReceiptType { get; set; }
}