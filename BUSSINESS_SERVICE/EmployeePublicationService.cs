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
    public class EmployeePublicationService : Iemppublicationdetails
    {
        private readonly UOW _UOW;
        public EmployeePublicationService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<EmployeePublicationEntities> GetpublicationdetailsById(int publicationdetailsId)
        {
            var data = (from div in _UOW.PUBLICATIONSRepository.GetAll()
                        where div.EMPLOYEEID == publicationdetailsId
                        select new BUSSINESS_ENTITIES.EmployeePublicationEntities
                        {
                            ID = div.ID,
                            DATEOFPUBLICATION = div.DATEOFPUBLICATION.HasValue ? div.DATEOFPUBLICATION.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            PUBLICATIONDETAILS = div.PUBLICATIONDETAILS,
                            EMPLOYEEID = div.EMPLOYEEID,
                            COMMENTS = div.COMMENTS
                        }).ToList();
            return data;
        }

        public IEnumerable<EmployeePublicationEntities> GetAllpublicationdetailsDetails()
        {
            var data = (from div in _UOW.PUBLICATIONSRepository.GetAll()
                        select new BUSSINESS_ENTITIES.EmployeePublicationEntities
                        {
                            ID = div.ID,
                            DATEOFPUBLICATION = div.DATEOFPUBLICATION.HasValue ? div.DATEOFPUBLICATION.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                            PUBLICATIONDETAILS = div.PUBLICATIONDETAILS,
                            EMPLOYEEID = div.EMPLOYEEID,
                            COMMENTS = div.COMMENTS
                        }).ToList();
            return data;
        }

        public int CreatepublicationdetailsDetails(EmployeePublicationEntities publicationdetailsEntities)
        {
            if (publicationdetailsEntities != null)
            {
                var ACHIEVEMENTDATE1 = (DateTime?)null;
                //DateTime joiningdate = Convert.ToDateTime(BasicinfoEntities.JOININGDATE);
                if (publicationdetailsEntities.DATEOFPUBLICATION != null)
                {
                    ACHIEVEMENTDATE1 = DateTime.ParseExact(publicationdetailsEntities.DATEOFPUBLICATION, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                var publicationDetail = new TBL_EMP_PUBLICATIONS
                {
                    DATEOFPUBLICATION = ACHIEVEMENTDATE1,
                    EMPLOYEEID = publicationdetailsEntities.EMPLOYEEID,
                    PUBLICATIONDETAILS = publicationdetailsEntities.PUBLICATIONDETAILS,
                    COMMENTS = publicationdetailsEntities.COMMENTS
                };
                _UOW.PUBLICATIONSRepository.Insert(publicationDetail);
                _UOW.Save();

            }
            return Convert.ToInt32(publicationdetailsEntities.ID);
        }

        public bool UpdatepublicationdetailsDetails(int publicationdetailsId, EmployeePublicationEntities publicationdetailsEntities)
        {
            var success = false;
            if (publicationdetailsEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var EmployeeAwardDetail = _UOW.PUBLICATIONSRepository.GetByID(publicationdetailsId);
                if (EmployeeAwardDetail != null)
                {

                    if (publicationdetailsEntities.EMPLOYEEID != null)
                    {
                        EmployeeAwardDetail.EMPLOYEEID = publicationdetailsEntities.EMPLOYEEID;
                    }
                    if (publicationdetailsEntities.PUBLICATIONDETAILS != null && publicationdetailsEntities.PUBLICATIONDETAILS != "")
                    {
                        EmployeeAwardDetail.PUBLICATIONDETAILS = publicationdetailsEntities.PUBLICATIONDETAILS;
                    }
                    if (publicationdetailsEntities.COMMENTS != null && publicationdetailsEntities.COMMENTS != "")
                    {
                        EmployeeAwardDetail.COMMENTS = publicationdetailsEntities.COMMENTS;
                    }
                    if (publicationdetailsEntities.DATEOFPUBLICATION != null && publicationdetailsEntities.DATEOFPUBLICATION != "")
                    {
                        var ACHIEVEMENTDATE1 = DateTime.ParseExact(publicationdetailsEntities.DATEOFPUBLICATION, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        EmployeeAwardDetail.DATEOFPUBLICATION = ACHIEVEMENTDATE1;
                    }
                    _UOW.PUBLICATIONSRepository.Update(EmployeeAwardDetail);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeletepublicationdetailsDetails(int publicationdetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
