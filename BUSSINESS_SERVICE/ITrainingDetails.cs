using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface ITrainingDetails
    {
        IEnumerable<TrainingDetailsEntities> GetTrainingDetailsById(int TrainingDetailsId);
        IEnumerable<TrainingDetailsEntities> GetAllTrainingDetails();
        int CreateTrainingDetails(TrainingDetailsEntities TrainingDetailsEntities); 
        bool UpdateTrainingDetails(int TrainingDetailsId, TrainingDetailsEntities TrainingDetailsEntities);
        bool DeleteTrainingDetails(int TrainingDetailsId);
    }
}
