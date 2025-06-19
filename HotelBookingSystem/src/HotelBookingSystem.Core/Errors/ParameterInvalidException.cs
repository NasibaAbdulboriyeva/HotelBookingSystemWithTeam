using System.Runtime.Serialization;

namespace HotelBookingSystem.Core.Errors;

[Serializable]
public class ParameterInvalidException : BaseException
{
    public ParameterInvalidException() { }
    public ParameterInvalidException(string message) : base(message) { }
    public ParameterInvalidException(string message, Exception inner) : base(message, inner) { }
    protected ParameterInvalidException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
