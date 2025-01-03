using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Requests;

public class RequestInvoiceJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public ReceiptType ReceiptType { get; set; }
}