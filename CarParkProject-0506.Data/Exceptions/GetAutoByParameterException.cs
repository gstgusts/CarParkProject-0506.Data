using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkProject_0506.Data.Exceptions
{
    public class GetAutoByParameterException : ArgumentException
    {
        public GetAutoByParameterException(string paramName) : base($"Unable to get auto by parameter", paramName)
        {
            
        }
    }
}
