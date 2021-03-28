using CleanArchitecture.Application.Exceptions;
using System;

namespace CleanArchitecture.Application.Common.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string name, object key) : base($"Entity '{name}' ({key}) was not found.")
        {
            Code = System.Net.HttpStatusCode.NotFound;
        }

        public NotFoundException(string message) : base(message)
        {
            Code = System.Net.HttpStatusCode.NotFound;
        }
    }
}
