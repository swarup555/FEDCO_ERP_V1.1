using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;

namespace BUSSINESS_SERVICE
{
    public class TrainingDetailsService:ITrainingDetails
    {
        private readonly UOW _UOW;

        public TrainingDetailsService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<TrainingDetailsEntities> GetTrainingDetailsById(int TrainingDetailsId)
        {
            var trainingdtls = (from div in _UOW.TRAINING_DETAILSRepository.GetManyQueryable(x => x.EMPLOYEE_ID == TrainingDetailsId)
                                select new TrainingDetailsEntities
                                {
                                    ID = div.ID,
                                    EMPLOYEE_ID = div.EMPLOYEE_ID,
                                    TRAINING_NAME = div.TRAINING_NAME,
                                    TRANING_DETAILS = div.TRANING_DETAILS,
                                    STARTING_DATE = div.STARTING_DATE,
                                    COMPLETED_DATE = div.COMPLETED_DATE,
                                    GUIDEDBY = div.GUIDEDBY,
                                    REMARKS=div.REMARKS
                                }).ToList();
            return trainingdtls;
        }

        public IEnumerable<TrainingDetailsEntities> GetAllTrainingDetails()
        {
            var trainingdtls = (from div in _UOW.TRAINING_DETAILSRepository.GetAll()
                                select new TrainingDetailsEntities
                                {
                                    ID = div.ID,
                                    EMPLOYEE_ID = div.EMPLOYEE_ID,
                                    TRAINING_NAME = div.TRAINING_NAME,
                                    TRANING_DETAILS = div.TRANING_DETAILS,
                                    STARTING_DATE = div.STARTING_DATE,
                                    COMPLETED_DATE = div.COMPLETED_DATE,
                                    GUIDEDBY = div.GUIDEDBY,
                                    REMARKS = div.REMARKS
                                }).ToList();
            return trainingdtls;
        }

        public int CreateTrainingDetails(TrainingDetailsEntities TrainingDetailsEntities)
        {
            if (TrainingDetailsEntities != null)
            {

                var TrainingDetail = new TBL_EMP_TRAINING_DETAILS
                {
                    EMPLOYEE_ID = TrainingDetailsEntities.EMPLOYEE_ID,
                    TRAINING_NAME = TrainingDetailsEntities.TRAINING_NAME,
                    TRANING_DETAILS = TrainingDetailsEntities.TRANING_DETAILS,
                    STARTING_DATE = TrainingDetailsEntities.STARTING_DATE,
                    COMPLETED_DATE = TrainingDetailsEntities.COMPLETED_DATE,
                    GUIDEDBY = TrainingDetailsEntities.GUIDEDBY,
                    REMARKS = TrainingDetailsEntities.REMARKS

                };
                _UOW.TRAINING_DETAILSRepository.Insert(TrainingDetail);
                _UOW.Save();
            }
            return Convert.ToInt32(TrainingDetailsEntities.ID);
        }

        public bool UpdateTrainingDetails(int TrainingDetailsId, TrainingDetailsEntities TrainingDetailsEntities)
        {
            var success = false;
            if (TrainingDetailsEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var TrainingDetail = _UOW.TRAINING_DETAILSRepository.GetByID(TrainingDetailsId);
                if (TrainingDetail != null)
                {
                    if (TrainingDetailsEntities.EMPLOYEE_ID != null)
                    {
                        TrainingDetail.EMPLOYEE_ID = TrainingDetailsEntities.EMPLOYEE_ID;
                    }
                    if (TrainingDetailsEntities.TRAINING_NAME != null)
                    {
                        TrainingDetail.TRAINING_NAME = TrainingDetailsEntities.TRAINING_NAME;
                    }
                    if (TrainingDetailsEntities.TRANING_DETAILS != "" && TrainingDetailsEntities.TRANING_DETAILS != null)
                    {
                        TrainingDetail.TRANING_DETAILS = TrainingDetailsEntities.TRANING_DETAILS;
                    }
                    if (TrainingDetailsEntities.STARTING_DATE != null)
                    {
                        TrainingDetail.STARTING_DATE = TrainingDetailsEntities.STARTING_DATE;
                    }
                    if (TrainingDetailsEntities.COMPLETED_DATE != null)
                    {
                        TrainingDetail.COMPLETED_DATE = TrainingDetailsEntities.COMPLETED_DATE;
                    }
                    if (TrainingDetailsEntities.GUIDEDBY != "" && TrainingDetailsEntities.GUIDEDBY != null)
                    {
                        TrainingDetail.GUIDEDBY = TrainingDetailsEntities.GUIDEDBY;
                    }
                    if (TrainingDetailsEntities.REMARKS != "" && TrainingDetailsEntities.REMARKS != null)
                    {
                        TrainingDetail.REMARKS = TrainingDetailsEntities.REMARKS;
                    }
                    _UOW.TRAINING_DETAILSRepository.Update(TrainingDetail);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteTrainingDetails(int TrainingDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
