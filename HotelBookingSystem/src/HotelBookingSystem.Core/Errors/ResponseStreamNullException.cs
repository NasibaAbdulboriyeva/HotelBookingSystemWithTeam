using System.Runtime.Serialization;
namespace HotelBookingSystem.Core.Errors;

[Serializable]
public class ResponseStreamNullException : BaseException
{
    public ResponseStreamNullException() { }
    public ResponseStreamNullException(string message) : base(message) { }
    public ResponseStreamNullException(string message, Exception inner) : base(message, inner) { }
    protected ResponseStreamNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}