using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Globalization;

namespace BUSSINESS_SERVICE
{
    public class EmployeeCulturalActivityService : ICulturalActivityDetails
    {
        private readonly UOW _UOW;
        public EmployeeCulturalActivityService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<EmployeeCulturalActivityEntities> GetEmployeeCulturalActivityById(int CulturalActivityId)
        {
            var data = (from div in _UOW.CULTURAL_ACTIVITYDTLSRepository.GetAll()
                        where div.EMPLOYEEID == CulturalActivityId
                        select new BUSSINESS_ENTITIES.EmployeeCulturalActivityEntities
                        {
                            ID = div.ID,
                            PARTICIPATIONDATE = div.PARTICIPATIONDATE.HasValue ? div.PARTICIPATIONDATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            CULTURALACTIVITY = div.CULTURALACTIVITY,
                            OCCASION = div.OCCASION,
                            EMPLOYEEID = div.EMPLOYEEID,
                            COMMENTS = div.COMMENTS
                        }).ToList();
            return data;
        }

        public IEnumerable<EmployeeCulturalActivityEntities> GetAllEmployeeCulturalActivityDetails()
        {
            var data = (from div in _UOW.CULTURAL_ACTIVITYDTLSRepository.GetAll()
                        select new BUSSINESS_ENTITIES.EmployeeCulturalActivityEntities
                        {
                            ID = div.ID,
                            PARTICIPATIONDATE = div.PARTICIPATIONDATE.HasValue ? div.PARTICIPATIONDATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            CULTURALACTIVITY = div.CULTURALACTIVITY,
                            OCCASION = div.OCCASION,
                            EMPLOYEEID = div.EMPLOYEEID,
                            COMMENTS = div.COMMENTS
                        }).ToList();
            return data;
        }

        public int CreateEmployeeCulturalActivityDetails(EmployeeCulturalActivityEntities CulturalActivityEntities)
        {
            if (CulturalActivityEntities != null)
            {
                var ACHIEVEMENTDATE1 = (DateTime?)null;
                //DateTime joiningdate = Convert.ToDateTime(BasicinfoEntities.JOININGDATE);
                if (CulturalActivityEntities.PARTICIPATIONDATE != null)
                {
                    ACHIEVEMENTDATE1 = DateTime.ParseExact(CulturalActivityEntities.PARTICIPATIONDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                var CulturalActivityDETAILS = new TBL_EMP_CULTURAL_ACTIVITYDTLS
                {
                    PARTICIPATIONDATE = ACHIEVEMENTDATE1,
                    EMPLOYEEID = CulturalActivityEntities.EMPLOYEEID,
                    CULTURALACTIVITY = CulturalActivityEntities.CULTURALACTIVITY,
                    OCCASION = CulturalActivityEntities.OCCASION,
                    COMMENTS = CulturalActivityEntities.COMMENTS
                };
                _UOW.CULTURAL_ACTIVITYDTLSRepository.Insert(CulturalActivityDETAILS);
                _UOW.Save();

            }
            return Convert.ToInt32(CulturalActivityEntities.ID);
        }

        public bool UpdateEmployeeCulturalActivityDetails(int CulturalActivityId, EmployeeCulturalActivityEntities CulturalActivityEntities)
        {
            var success = false;
            if (CulturalActivityEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var CulturalActivityDETAILS = _UOW.CULTURAL_ACTIVITYDTLSRepository.GetByID(CulturalActivityId);
                if (CulturalActivityDETAILS != null)
                {

                    if (CulturalActivityEntities.EMPLOYEEID != null)
                    {
                        CulturalActivityDETAILS.EMPLOYEEID = CulturalActivityEntities.EMPLOYEEID;
                    }
                    if (CulturalActivityEntities.CULTURALACTIVITY != null && CulturalActivityEntities.CULTURALACTIVITY != "")
                    {
                        CulturalActivityDETAILS.CULTURALACTIVITY = CulturalActivityEntities.CULTURALACTIVITY;
                    }
                    if (CulturalActivityEntities.OCCASION != null && CulturalActivityEntities.OCCASION != "")
                    {
                        CulturalActivityDETAILS.OCCASION = CulturalActivityEntities.OCCASION;
                    }
                    if (CulturalActivityEntities.COMMENTS != null && CulturalActivityEntities.COMMENTS != "")
                    {
                        CulturalActivityDETAILS.COMMENTS = CulturalActivityEntities.COMMENTS;
                    }
                    if (CulturalActivityEntities.PARTICIPATIONDATE != null && CulturalActivityEntities.PARTICIPATIONDATE != "")
                    {
                        var ACHIEVEMENTDATE1 = DateTime.ParseExact(CulturalActivityEntities.PARTICIPATIONDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        CulturalActivityDETAILS.PARTICIPATIONDATE = ACHIEVEMENTDATE1;
                    }
                    _UOW.CULTURAL_ACTIVITYDTLSRepository.Update(CulturalActivityDETAILS);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteEmployeeCulturalActivityDetails(int CulturalActivityId)
        {
            throw new NotImplementedException();
        }
    }
}
