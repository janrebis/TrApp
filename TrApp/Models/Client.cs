using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrApp.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get;}
        public string Name { get;}
        public Guid TrainerId { get; }
        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; }
    }
}