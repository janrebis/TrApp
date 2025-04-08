using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrApp.Domain.Exception
{
    public class WeightUnitException : IOException
    {
        public WeightUnitException(string paramName) : base($"Value of {paramName} cannot be empty if weight if provided") { }
    }
}
