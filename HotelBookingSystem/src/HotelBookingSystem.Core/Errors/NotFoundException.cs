using System.Runtime.Serialization;

namespace HotelBookingSystem.Core.Errors;

[Serializable]
public class NotFoundException : BaseException
{
    public NotFoundException() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception inner) : base(message, inner) { }
    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}