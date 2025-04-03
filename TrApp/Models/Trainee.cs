using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrApp.Models
{
    public class Trainee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? Age { get; set; }
        [Required]
        public Guid? TrainerId { get; set;  }
        [ForeignKey("TrainerId")]
        public Trainer? Trainer { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public ICollection<TrainingPlan> TrainingPlans { get; set; } = new List<TrainingPlan>();

    }
}