using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Transactions;

namespace BUSSINESS_SERVICE
{
    public class ReportingService:IReportingPerson
    {
         private readonly UOW _UOW;
         public ReportingService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<Reportingentities> GetReportingPersonById(int ReportingPersonId)
        {
            var data = (from div in _UOW.REPORTINGRepository.GetAll()
                        where div.DEPARTMENT_ID == ReportingPersonId
                        select new Reportingentities
                        {
                            ID = div.ID,
                            REPORTING_PERSON_NAME = div.REPORTING_PERSON_NAME
                        }).ToList();
            return data;
        }

        public IEnumerable<Reportingentities> GetAllDepartment()
        {
            var data = (from div in _UOW.REPORTINGRepository.GetAll()
                        select new Reportingentities
                        {
                            ID = div.ID,
                            REPORTING_PERSON_NAME = div.REPORTING_PERSON_NAME
                        }).ToList();
            return data;
        }

        public int CreateReportingPerson(Reportingentities DepartmentEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReportingPerson(int DepartmentId, Reportingentities DepartmentEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReportingPerson(int DepartmentId)
        {
            throw new NotImplementedException();
        }
    }
}
