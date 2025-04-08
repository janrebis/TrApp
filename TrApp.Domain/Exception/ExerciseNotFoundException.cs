using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrApp.Domain.Exception
{
    public class ExerciseNotFoundException : IOException
    {
        public ExerciseNotFoundException() : base("Exercise does not exist in database") { }
    }
}
