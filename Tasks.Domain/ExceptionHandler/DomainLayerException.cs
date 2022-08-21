using System;

namespace Tasks.Domain.ExceptionHandler
{
    public class DomainLayerException : Exception
    {
        public DomainLayerException (string message)
            : base(message) { }
    }
}
