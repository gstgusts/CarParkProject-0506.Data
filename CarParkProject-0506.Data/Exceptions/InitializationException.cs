using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkProject_0506.Data.Exceptions
{
    public class InitializationException : Exception
    {
        public InitializationException() : base("Unable to initialize object")
        {
            
        }

        public InitializationException(string message) : base(message) {
            
        }
    }
}
