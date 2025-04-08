using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrApp.Domain.Entities.AggregateRoots;

namespace TrApp.Models
{
    public class Trainee
    {
        [Key]
        public Guid TraineeId { get; private set; }
        [Required]
        public string Name { get; private set; }
        public int? Age { get; private set; }
        
        public DateTime CreatedAt { get; }

        public Guid TrainerId { get; private set; }
        public Trainer Trainer { get; private set; }

        public Trainee(string name, int age)
        {
            TraineeId = Guid.NewGuid();
            Name = name;
            Age = age;
        }
        private Trainee() { }

        internal void Update(string name, int age)
        {
            Name = name;
            Age = age;
        }

    }
}