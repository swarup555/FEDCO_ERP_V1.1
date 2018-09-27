using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Globalization;
using System.Runtime.Caching;

namespace BUSSINESS_SERVICE
{
    public class EmployeeBasicInfoService:IBasicinformationEmployee
    {
         private readonly UOW _UOW;
         private const string CacheKey = "Empfilterdata";
         ObjectCache cache = MemoryCache.Default;
         public EmployeeBasicInfoService()
        {
            _UOW = new UOW();
        }
    
        public IEnumerable<BasicInformaionEntities> GetEmployeebasicinfoById(int BasicinfoId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BasicInformaionEntities> GetAllEmployeeBasicinfo()
        {
            var data1 = _UOW.DESIGNATIONRepository.GetAll();
            var data2 = _UOW.DEPARTMENTRepository.GetAll();
            var data3 = _UOW.LOCATIONMASTERRepository.GetAll();
            var data4 = _UOW.DIVISIONRepository.GetAll();
            var data5 = _UOW.SUBDIVISIONRepository.GetAll();
            var data6 = _UOW.SECTIONORepository.GetAll();
            var data7 = _UOW.BLOODGROUPRepository.GetAll();
            var data8 = _UOW.GRADERepository.GetAll();
            var bsicinfo = (from a in _UOW.EMP_BASICINFORepository.Retrieve()
                            select new BasicInformaionEntities
                            {
                                ID = a.ID,
                                DESIGNATION = a.DESIGNATION,
                                JOINING_DATE = a.JOINING_DATE,
                                EMPLOYEE_CODE = a.EMPLOYEE_CODE,
                                EMPLOYEE_FIRSTNAME = a.EMPLOYEE_FIRSTNAME,
                                EMPLOYEE_FULLNAME = a.EMPLOYEE_FIRSTNAME + " " + a.EMPLOYEE_MIDDLENAME + " " + a.EMPLOYEE_LASTNAME,
                                DATE_OF_BIRTH = a.DATE_OF_BIRTH,
                                AGE = a.AGE,
                                SEX = a.SEX,
                                DIVISION = a.DIVISION,
                                SUBDIVISION = a.SUBDIVISION,
                                SECTION = a.SECTION,
                                BLOOD_GROUP = a.BLOOD_GROUP,
                                EXIT_DATE = a.EXIT_DATE,
                                departmentname = a.DEPARTMENT.HasValue ? data2.Where(x => x.ID == a.DEPARTMENT).FirstOrDefault().DEPARTMENT_NAME : null,
                                designationname = a.DESIGNATION.HasValue ? data1.Where(x => x.ID == a.DESIGNATION).FirstOrDefault().DESIGNATION_NAME : null,
                                PERSONAL_EMAIL = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().PERSONAL_EMAIL : null,
                                OFFICIAL_EMAIL = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().OFFICIAL_EMAIL : null,
                                OFFICIAL_MOBILE_NUMBER = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().OFFICIAL_MOBILE_NUMBER : null,
                                EMERGENCY_CONTACT_NUMBER = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().EMERGENCY_CONTACT_NUMBER : null,
                                MOBILE_NUMBER = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().MOBILE_NUMBER : null,
                                EMPIMAGE = a.EMPIMG != null ? "data:image/png;base64," + Convert.ToBase64String(a.EMPIMG) : null,
                                DEPARTMENT = a.DEPARTMENT,
                                WORKLOCATION = a.WORKLOCATION,
                                STATUS = a.STATUS,
                                GRADE = a.GRADE,
                                gradename = a.GRADE.HasValue ? data8.Where(x => x.ID == a.GRADE).FirstOrDefault().GRADE_NAME : null,
                                locationname = a.WORKLOCATION.HasValue ? data3.Where(x => x.ID == a.WORKLOCATION).FirstOrDefault().LOCATION_NAME : null,
                                DIVISIONNAME = a.DIVISION != null ? data4.Where(x => x.DIVISION_CODE == a.DIVISION).FirstOrDefault().DIV_NAME : null,
                                SUB_DIVISIONNAME = a.SUBDIVISION != null ? data5.Where(x => x.SUB_DIV_CODE == a.SUBDIVISION).FirstOrDefault().SUB_DIV_NAME : null,
                                SECTIONNAME = a.SECTION != null ? data6.Where(x => x.SEC_CODE == a.SECTION).FirstOrDefault().SEC_NAME : null,
                                REFERENCE = a.BLOOD_GROUP != null ? data7.Where(x => x.ID == a.BLOOD_GROUP).FirstOrDefault().BLOODGROUP_NAME : null,
                            }).ToList();
            return bsicinfo;
        }

        public int CreateEmployeebasicinfo(BasicInformaionEntities BasicinfoEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployeebasicinfo(int BasicinfoId, BasicInformaionEntities BasicinfoEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployeebasicinfo(int BasicinfoId)
        {
            throw new NotImplementedException();
        }
    }
}
