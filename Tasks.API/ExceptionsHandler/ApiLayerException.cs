using System;

namespace Tasks.API.ExceptionsHandler
{
    public class ApiLayerException : Exception
    {
        public ApiLayerException(string message) 
            : base(message) { }
    }
}
