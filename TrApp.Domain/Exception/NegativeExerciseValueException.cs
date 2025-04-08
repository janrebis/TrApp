using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrApp.Domain.Exception
{
    public class NegativeExerciseValueException : IOException
    {
        public NegativeExerciseValueException(string paramName) : base($"Value of {paramName} cannot be negative") { }
    }
}
