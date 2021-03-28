using CleanArchitecture.Application.Exceptions;

namespace CleanArchitecture.Application.Common.Exceptions
{
    public class BadRequestException : ExceptionBase
    {
        public BadRequestException(string message) : base(message)
        {
            Code = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
