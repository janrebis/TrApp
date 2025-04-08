using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrApp.Infrastructure.Persistence.Repositories.RepositoriesExceptions
{
    public class TrainerNotFoundException : IOException
    {
        public TrainerNotFoundException() : base("Trainer not found in database.") { }
    }
}
