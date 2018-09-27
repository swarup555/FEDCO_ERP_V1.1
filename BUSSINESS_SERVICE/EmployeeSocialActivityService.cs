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
    public class EmployeeSocialActivityService : ISocialActivity
    {
        private readonly UOW _UOW;
        public EmployeeSocialActivityService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<BUSSINESS_ENTITIES.EmployeeSocialActivityEntities> GetEmployeeSocialActivityById(int SocialActivityId)
        {
            var data = (from div in _UOW.SOCIALACTIVITIESRepository.GetAll()
                        where div.EMPLOYEEID == SocialActivityId
                        select new BUSSINESS_ENTITIES.EmployeeSocialActivityEntities
                        {
                            ID = div.ID,
                            ACTIVITYDATE = div.ACTIVITYDATE.HasValue ? div.ACTIVITYDATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            ACTIVITYDETAILS = div.ACTIVITYDETAILS,
                            EMPLOYEEID = div.EMPLOYEEID,
                            COMMENTS = div.COMMENTS
                        }).ToList();
            return data;
        }

        public IEnumerable<BUSSINESS_ENTITIES.EmployeeSocialActivityEntities> GetAllEmployeeSocialActivityDetails()
        {
            var data = (from div in _UOW.SOCIALACTIVITIESRepository.GetAll()
                        select new BUSSINESS_ENTITIES.EmployeeSocialActivityEntities
                        {
                            ID = div.ID,
                            ACTIVITYDATE = div.ACTIVITYDATE.HasValue ? div.ACTIVITYDATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            ACTIVITYDETAILS = div.ACTIVITYDETAILS,
                            EMPLOYEEID = div.EMPLOYEEID,
                            COMMENTS = div.COMMENTS
                        }).ToList();
            return data;
        }

        public int CreateEmployeeSocialActivityDetails(BUSSINESS_ENTITIES.EmployeeSocialActivityEntities SocialActivityEntities)
        {
            if (SocialActivityEntities != null)
            {
                var ACHIEVEMENTDATE1 = (DateTime?)null;
                //DateTime joiningdate = Convert.ToDateTime(BasicinfoEntities.JOININGDATE);
                if (SocialActivityEntities.ACTIVITYDATE != null)
                {
                    ACHIEVEMENTDATE1 = DateTime.ParseExact(SocialActivityEntities.ACTIVITYDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                var SOCIALACTIVITIES = new TBL_EMP_SOCIALACTIVITIES
                {
                    ACTIVITYDATE = ACHIEVEMENTDATE1,
                    EMPLOYEEID = SocialActivityEntities.EMPLOYEEID,
                    ACTIVITYDETAILS = SocialActivityEntities.ACTIVITYDETAILS,
                    COMMENTS = SocialActivityEntities.COMMENTS
                };
                _UOW.SOCIALACTIVITIESRepository.Insert(SOCIALACTIVITIES);
                _UOW.Save();

            }
            return Convert.ToInt32(SocialActivityEntities.ID);
        }

        public bool UpdateEmployeeSocialActivityDetails(int SocialActivityId, BUSSINESS_ENTITIES.EmployeeSocialActivityEntities SocialActivityEntities)
        {
            var success = false;
            if (SocialActivityEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var SOCIALACTIVITIES = _UOW.SOCIALACTIVITIESRepository.GetByID(SocialActivityId);
                if (SOCIALACTIVITIES != null)
                {

                    if (SocialActivityEntities.EMPLOYEEID != null)
                    {
                        SOCIALACTIVITIES.EMPLOYEEID = SocialActivityEntities.EMPLOYEEID;
                    }
                    if (SocialActivityEntities.ACTIVITYDETAILS != null && SocialActivityEntities.ACTIVITYDETAILS != "")
                    {
                        SOCIALACTIVITIES.ACTIVITYDETAILS = SocialActivityEntities.ACTIVITYDETAILS;
                    }
                    if (SocialActivityEntities.COMMENTS != null && SocialActivityEntities.COMMENTS != "")
                    {
                        SOCIALACTIVITIES.COMMENTS = SocialActivityEntities.COMMENTS;
                    }
                    if (SocialActivityEntities.ACTIVITYDATE != null && SocialActivityEntities.ACTIVITYDATE != "")
                    {
                        var ACHIEVEMENTDATE1 = DateTime.ParseExact(SocialActivityEntities.ACTIVITYDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        SOCIALACTIVITIES.ACTIVITYDATE = ACHIEVEMENTDATE1;
                    }
                    _UOW.SOCIALACTIVITIESRepository.Update(SOCIALACTIVITIES);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteEmployeeSocialActivityDetails(int SocialActivityId)
        {
            throw new NotImplementedException();
        }
    }
}
