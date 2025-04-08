using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrApp.Domain.Exception
{
    public class MaximumTraineesValueException : IOException
    {
        public MaximumTraineesValueException() : base("Cannot add more than 10 trainees.") { }
    }
}
