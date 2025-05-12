using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrApp.Domain.Entities.DTO
{
    public class TraineeDto
    {
        public Guid TraineeId { get; private set; }
        public string Name { get; set; }
        public int? Age {  get; set; }

        public TraineeDto(Guid traineeId, string name, int? age)
        {
            TraineeId = traineeId;
            Name = name;
            Age = age;
        }
    }
}
