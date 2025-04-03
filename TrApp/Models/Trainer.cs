using System.ComponentModel.DataAnnotations;

namespace TrApp.Models
{
    public class Trainer
    {
        [Key]
        public Guid Id { get; set; }
        public IEnumerable<Trainee>? Trainees { get; set; } = new List<Trainee>();

        private Trainer() { }
        public Trainer(Guid id)
        {
            Id = id;
        }      
    }
}