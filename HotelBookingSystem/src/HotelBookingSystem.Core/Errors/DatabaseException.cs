using System.Runtime.Serialization;

namespace HotelBookingSystem.Core.Errors;

[Serializable]
public class DatabaseException : BaseException
{
    public DatabaseException() { }
    public DatabaseException(string message) : base(message) { }
    public DatabaseException(string message, Exception inner) : base(message, inner) { }
    protected DatabaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
