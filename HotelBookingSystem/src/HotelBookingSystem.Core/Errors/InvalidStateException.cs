using System.Runtime.Serialization;
namespace HotelBookingSystem.Core.Errors;

[Serializable]
public class InvalidStateException : BaseException
{
    public InvalidStateException() { }
    public InvalidStateException(string message) : base(message) { }
    public InvalidStateException(string message, Exception inner) : base(message, inner) { }
    protected InvalidStateException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}