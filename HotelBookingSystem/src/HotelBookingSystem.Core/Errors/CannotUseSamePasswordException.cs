using System.Runtime.Serialization;
namespace HotelBookingSystem.Core.Errors;

[Serializable]
public class CannotUseSamePasswordException : BaseException
{
    public CannotUseSamePasswordException() { }
    public CannotUseSamePasswordException(string message) : base(message) { }
    public CannotUseSamePasswordException(string message, Exception inner) : base(message, inner) { }
    protected CannotUseSamePasswordException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}