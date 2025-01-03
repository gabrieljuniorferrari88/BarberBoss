using System.Net;

namespace BarberBoss.Exception.ExceptionsBase;

public class NotFoundException : BarberBossException
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public NotFoundException(string message) : base(message)
    {
    }
    
    public override List<string> GetErrors()
    {
        return [Message];
    }
}