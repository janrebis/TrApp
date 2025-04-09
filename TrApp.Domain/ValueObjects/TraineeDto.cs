using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrApp.Domain.ValueObjects
{
    public class TraineeDto
    {
        public Guid TraineeId { get; private set; }
        public string Name { get; private set; }
        public int? Age {  get; private set; }

        public TraineeDto(Guid traineeId, string name, int? age)
        {
            TraineeId = traineeId;
            Name = name;
            Age = age;
        }
    }
}
