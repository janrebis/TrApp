using System.ComponentModel.DataAnnotations;

namespace TrApp.Models
{
    public class Trainer
    {
        [Key]
        public Guid Id { get; private set; }
        public IEnumerable<Client>? clients { get; set; }

        private Trainer() { }
        public Trainer(Guid id)
        {
            Id = id;
        }      
    }
}