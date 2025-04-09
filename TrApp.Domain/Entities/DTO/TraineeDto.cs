using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrApp.Domain.Entities.DTO
{
    public class TraineeDto
    {
        private Guid traineeId;
        private string name;
        private int? age;

        public TraineeDto(Guid traineeId, string name, int? age)
        {
            this.traineeId = traineeId;
            this.name = name;
            this.age = age;
        }
    }
}
