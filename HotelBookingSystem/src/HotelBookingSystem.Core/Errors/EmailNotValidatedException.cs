using System.Runtime.Serialization;
namespace HotelBookingSystem.Core.Errors;
    
//EmailNotValidated
[Serializable]
public class EmailNotValidatedException : BaseException
{
    public EmailNotValidatedException() { }
    public EmailNotValidatedException(string message) : base(message) { }
    public EmailNotValidatedException(string message, Exception inner) : base(message, inner) { }
    protected EmailNotValidatedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}