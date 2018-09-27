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
    public class EmployeeHobbyService : IEmpHobby
    {
        private readonly UOW _UOW;
        public EmployeeHobbyService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<EmployeeHobbiesEntity> GetEmployeeHobbiesById(int EmployeeHobbiesId)
        {
            var data = (from div in _UOW.HOBBIESRepository.GetAll()
                        where div.EMPLOYEEID == EmployeeHobbiesId
                        select new BUSSINESS_ENTITIES.EmployeeHobbiesEntity
                        {
                            ID = div.ID,
                            EMPLOYEEID = div.EMPLOYEEID,
                            HOBBIES = div.HOBBIES
                        }).ToList();
            return data;
        }

        public IEnumerable<EmployeeHobbiesEntity> GetAllEmployeeHobbiesDetails()
        {
            var data = (from div in _UOW.HOBBIESRepository.GetAll()
                        select new BUSSINESS_ENTITIES.EmployeeHobbiesEntity
                        {
                            ID = div.ID,
                            EMPLOYEEID = div.EMPLOYEEID,
                            HOBBIES = div.HOBBIES
                        }).ToList();
            return data;
        }

        public int CreateEmployeeHobbiesDetails(EmployeeHobbiesEntity EmployeeHobbiesEntities)
        {
            if (EmployeeHobbiesEntities != null)
            {
                var EmployeeHobbiesDetail = new TBL_EMP_HOBBIES
                {
                    EMPLOYEEID = EmployeeHobbiesEntities.EMPLOYEEID,
                    HOBBIES = EmployeeHobbiesEntities.HOBBIES
                };
                _UOW.HOBBIESRepository.Insert(EmployeeHobbiesDetail);
                _UOW.Save();

            }
            return Convert.ToInt32(EmployeeHobbiesEntities.ID);
        }

        public bool UpdateEmployeeHobbiesDetails(int EmployeeHobbiesId, EmployeeHobbiesEntity EmployeeHobbiesEntities)
        {
            var success = false;
            if (EmployeeHobbiesEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var EmployeeHobbiesDetail = _UOW.HOBBIESRepository.GetByID(EmployeeHobbiesId);
                if (EmployeeHobbiesDetail != null)
                {

                    if (EmployeeHobbiesEntities.EMPLOYEEID != null)
                    {
                        EmployeeHobbiesDetail.EMPLOYEEID = EmployeeHobbiesEntities.EMPLOYEEID;
                    }
                    if (EmployeeHobbiesEntities.HOBBIES != null && EmployeeHobbiesEntities.HOBBIES != "")
                    {
                        EmployeeHobbiesDetail.HOBBIES = EmployeeHobbiesEntities.HOBBIES;
                    }

                    _UOW.HOBBIESRepository.Update(EmployeeHobbiesDetail);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteEmployeeHobbiesDetails(int EmployeeHobbiesId)
        {
            throw new NotImplementedException();
        }
    }
}
