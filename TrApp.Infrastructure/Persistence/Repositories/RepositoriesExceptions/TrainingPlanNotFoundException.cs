using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrApp.Infrastructure.Persistence.Repositories.RepositoriesExceptions
{
    internal class TrainingPlanNotFoundException : IOException
    {
        public TrainingPlanNotFoundException() : base("Training plan not found in database.") { }
    }
    
}
