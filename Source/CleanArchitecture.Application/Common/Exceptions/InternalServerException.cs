using CleanArchitecture.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Common.Exceptions
{
    public class InternalServerException : ExceptionBase
    {
        public InternalServerException(string message) : base(message)
        {
            Code = System.Net.HttpStatusCode.InternalServerError;
        }
    }
}
