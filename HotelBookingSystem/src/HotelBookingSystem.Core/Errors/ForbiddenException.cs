using System.Runtime.Serialization;

namespace HotelBookingSystem.Core.Errors;

public class ForbiddenException : BaseException
{
    public ForbiddenException() { }
    public ForbiddenException(string message) : base(message) { }
    public ForbiddenException(string message, Exception inner) : base(message, inner) { }
    protected ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
