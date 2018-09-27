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
    public class EmployeeAwardDetailsService:IEmpAwardDetails
    {
       private readonly UOW _UOW;
        public EmployeeAwardDetailsService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<EmployeeAwardEntities> GetEmployeeAwardById(int EmployeeAwardId)
        {
            var data = (from div in _UOW.AWARDSRepository.GetAll()
                        where div.EMPLOYEEID == EmployeeAwardId
                        select new BUSSINESS_ENTITIES.EmployeeAwardEntities
                        {
                            ID = div.ID,
                            ACHIEVEMENTDATE = div.ACHIEVEMENTDATE.HasValue ? div.ACHIEVEMENTDATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            AWARDSDETAIL=div.AWARDSDETAIL,
                            EMPLOYEEID=div.EMPLOYEEID,
                            COMMENTS=div.COMMENTS
                        }).ToList();
            return data;
        }

        public IEnumerable<EmployeeAwardEntities> GetAllEmployeeAwardDetails()
        {
            var data = (from div in _UOW.AWARDSRepository.GetAll()
                        select new BUSSINESS_ENTITIES.EmployeeAwardEntities
                        {
                            ID = div.ID,
                            ACHIEVEMENTDATE = div.ACHIEVEMENTDATE.HasValue ? div.ACHIEVEMENTDATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            AWARDSDETAIL = div.AWARDSDETAIL,
                            EMPLOYEEID = div.EMPLOYEEID,
                            COMMENTS = div.COMMENTS
                        }).ToList();
            return data;
        }

        public int CreateEmployeeAwardDetails(EmployeeAwardEntities EmployeeAwardEntities)
        {
            if (EmployeeAwardEntities != null)
            {
                var ACHIEVEMENTDATE1 = (DateTime?)null;
                //DateTime joiningdate = Convert.ToDateTime(BasicinfoEntities.JOININGDATE);
                if (EmployeeAwardEntities.ACHIEVEMENTDATE != null)
                {
                    ACHIEVEMENTDATE1 = DateTime.ParseExact(EmployeeAwardEntities.ACHIEVEMENTDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                var EmployeeAwardDetail = new TBL_EMP_AWARDS
                {
                    ACHIEVEMENTDATE = ACHIEVEMENTDATE1,
                    EMPLOYEEID = EmployeeAwardEntities.EMPLOYEEID,
                    AWARDSDETAIL = EmployeeAwardEntities.AWARDSDETAIL,
                    COMMENTS = EmployeeAwardEntities.COMMENTS
                };
                _UOW.AWARDSRepository.Insert(EmployeeAwardDetail);
                _UOW.Save();
               
            }
            return Convert.ToInt32(EmployeeAwardEntities.ID);
        }

        public bool UpdateEmployeeAwardDetails(int EmployeeAwardId, EmployeeAwardEntities EmployeeAwardEntities)
        {
            var success = false;
            if (EmployeeAwardEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var EmployeeAwardDetail = _UOW.AWARDSRepository.GetByID(EmployeeAwardId);
                if (EmployeeAwardDetail != null)
                {

                    if (EmployeeAwardEntities.EMPLOYEEID != null )
                    {
                        EmployeeAwardDetail.EMPLOYEEID = EmployeeAwardEntities.EMPLOYEEID;
                    }
                    if (EmployeeAwardEntities.AWARDSDETAIL != null && EmployeeAwardEntities.AWARDSDETAIL != "")
                    {
                        EmployeeAwardDetail.AWARDSDETAIL = EmployeeAwardEntities.AWARDSDETAIL;
                    }
                    if (EmployeeAwardEntities.COMMENTS != null && EmployeeAwardEntities.COMMENTS != "")
                    {
                        EmployeeAwardDetail.COMMENTS = EmployeeAwardEntities.COMMENTS;
                    }
                    if (EmployeeAwardEntities.ACHIEVEMENTDATE != null && EmployeeAwardEntities.ACHIEVEMENTDATE != "")
                    {
                        var ACHIEVEMENTDATE1 = DateTime.ParseExact(EmployeeAwardEntities.ACHIEVEMENTDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        EmployeeAwardDetail.ACHIEVEMENTDATE = ACHIEVEMENTDATE1;
                    }
                    _UOW.AWARDSRepository.Update(EmployeeAwardDetail);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteEmployeeAwardDetails(int EmployeeAwardId)
        {
            throw new NotImplementedException();
        }
    }
}
