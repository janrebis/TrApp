using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrApp.Models
{
    public class Trainee
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public Guid? TrainerId { get; set;  }
        
        public DateTime CreatedAt { get; set; }

    }
}