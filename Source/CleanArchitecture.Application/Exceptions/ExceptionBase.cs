using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CleanArchitecture.Application.Exceptions
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase(string message) : base(message) { }
        public HttpStatusCode Code { get; set; } = HttpStatusCode.InternalServerError;
    }
}
