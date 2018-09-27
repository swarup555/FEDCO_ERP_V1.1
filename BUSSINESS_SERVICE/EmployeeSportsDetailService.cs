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
    public class EmployeeSportsDetailService : Iempsportsdetails
    {
        private readonly UOW _UOW;
        public EmployeeSportsDetailService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<EmployeeSportsActivityEntities> GetSportsActivityById(int SportsActivityId)
        {
            var data = (from div in _UOW.SPORTSDETAILSRepository.GetAll()
                        where div.EMPLOYEEID == SportsActivityId
                        select new BUSSINESS_ENTITIES.EmployeeSportsActivityEntities
                        {
                            ID = div.ID,
                            PARTICIPATIONDATE = div.PARTICIPATIONDATE.HasValue ? div.PARTICIPATIONDATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            SPORTSDETAIL = div.SPORTSDETAIL,
                            OCCASION = div.OCCASION,
                            EMPLOYEEID = div.EMPLOYEEID,
                            COMMENTS = div.COMMENTS
                        }).ToList();
            return data;
        }

        public IEnumerable<EmployeeSportsActivityEntities> GetAllSportsActivityDetails()
        {
            var data = (from div in _UOW.SPORTSDETAILSRepository.GetAll()
                        select new BUSSINESS_ENTITIES.EmployeeSportsActivityEntities
                        {
                            ID = div.ID,
                            PARTICIPATIONDATE = div.PARTICIPATIONDATE.HasValue ? div.PARTICIPATIONDATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            SPORTSDETAIL = div.SPORTSDETAIL,
                            OCCASION = div.OCCASION,
                            EMPLOYEEID = div.EMPLOYEEID,
                            COMMENTS = div.COMMENTS
                        }).ToList();
            return data;
        }

        public int CreateSportsActivityDetails(EmployeeSportsActivityEntities SportsActivityEntities)
        {
            if (SportsActivityEntities != null)
            {
                var ACHIEVEMENTDATE1 = (DateTime?)null;
                //DateTime joiningdate = Convert.ToDateTime(BasicinfoEntities.JOININGDATE);
                if (SportsActivityEntities.PARTICIPATIONDATE != null)
                {
                    ACHIEVEMENTDATE1 = DateTime.ParseExact(SportsActivityEntities.PARTICIPATIONDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                var SPORTSDETAILS = new TBL_EMP_SPORTSDETAILS
                {
                    PARTICIPATIONDATE = ACHIEVEMENTDATE1,
                    EMPLOYEEID = SportsActivityEntities.EMPLOYEEID,
                    SPORTSDETAIL = SportsActivityEntities.SPORTSDETAIL,
                    OCCASION = SportsActivityEntities.OCCASION,
                    COMMENTS = SportsActivityEntities.COMMENTS
                };
                _UOW.SPORTSDETAILSRepository.Insert(SPORTSDETAILS);
                _UOW.Save();

            }
            return Convert.ToInt32(SportsActivityEntities.ID);
        }

        public bool UpdateSportsActivityDetails(int SportsActivityId, EmployeeSportsActivityEntities SportsActivityEntities)
        {
            var success = false;
            if (SportsActivityEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var SPORTSDETAILS = _UOW.SPORTSDETAILSRepository.GetByID(SportsActivityId);
                if (SPORTSDETAILS != null)
                {

                    if (SportsActivityEntities.EMPLOYEEID != null)
                    {
                        SPORTSDETAILS.EMPLOYEEID = SportsActivityEntities.EMPLOYEEID;
                    }
                    if (SportsActivityEntities.SPORTSDETAIL != null && SportsActivityEntities.SPORTSDETAIL != "")
                    {
                        SPORTSDETAILS.SPORTSDETAIL = SportsActivityEntities.SPORTSDETAIL;
                    }
                    if (SportsActivityEntities.OCCASION != null && SportsActivityEntities.OCCASION != "")
                    {
                        SPORTSDETAILS.OCCASION = SportsActivityEntities.OCCASION;
                    }
                    if (SportsActivityEntities.COMMENTS != null && SportsActivityEntities.COMMENTS != "")
                    {
                        SPORTSDETAILS.COMMENTS = SportsActivityEntities.COMMENTS;
                    }
                    if (SportsActivityEntities.PARTICIPATIONDATE != null && SportsActivityEntities.PARTICIPATIONDATE != "")
                    {
                        var ACHIEVEMENTDATE1 = DateTime.ParseExact(SportsActivityEntities.PARTICIPATIONDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        SPORTSDETAILS.PARTICIPATIONDATE = ACHIEVEMENTDATE1;
                    }
                    _UOW.SPORTSDETAILSRepository.Update(SPORTSDETAILS);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteSportsActivityDetails(int SportsActivityId)
        {
            throw new NotImplementedException();
        }
    }
}
