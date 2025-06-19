using System.Runtime.Serialization;

namespace HotelBookingSystem.Core.Errors;

[Serializable]
public class NoConnectionException : BaseException
{
    public NoConnectionException() { }
    public NoConnectionException(string message) : base(message) { }
    public NoConnectionException(string message, Exception inner) : base(message, inner) { }
    protected NoConnectionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}