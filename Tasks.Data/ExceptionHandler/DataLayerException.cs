using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Data.ExceptionHandler
{
    public class DataLayerException : Exception
    {
        public DataLayerException (string message) 
            : base(message) { }
    }
}
