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
    public class IndivisualEmployeeSevice:IindivisualEmployee
    {
        private readonly UOW _UOW;
        public IndivisualEmployeeSevice()
        {
            _UOW = new UOW();
        }
        public IEnumerable<IndivisualEmployeeEntities> GetEmployeeById(int AssetDetailsId)
        {
            var data1 = _UOW.DESIGNATIONRepository.GetAll();
            var data2 = _UOW.DEPARTMENTRepository.GetAll();
            var data3 = _UOW.LOCATIONMASTERRepository.GetAll();
            var data4 = _UOW.GRADERepository.GetAll();
            var data5 = _UOW.BLOODGROUPRepository.GetAll();
            //var data6 = _UOW.EMP_BASICINFORepository.RetrieveEmp();
            var data = (from a in _UOW.EMP_BASICINFORepository.Retrieve()
                        where a.ID == AssetDetailsId
                        select new IndivisualEmployeeEntities
                        {
                            ID = a.ID,
                            DESIGNATION = a.DESIGNATION,
                            JOINING_DATE = a.JOINING_DATE,
                            EMPLOYEE_CODE = a.EMPLOYEE_CODE,
                            EMPLOYEE_FIRSTNAME = a.EMPLOYEE_FIRSTNAME,
                            EMPLOYEE_MIDDLENAME = a.EMPLOYEE_MIDDLENAME,
                            EMPLOYEE_LASTNAME = a.EMPLOYEE_LASTNAME,
                            EMPLOYEE_FULLNAME = a.EMPLOYEE_FIRSTNAME + " " + a.EMPLOYEE_MIDDLENAME + " " + a.EMPLOYEE_LASTNAME,
                            DATE_OF_BIRTH = a.DATE_OF_BIRTH,
                            AGE = a.AGE,
                            SEX = a.SEX,
                            MATERIAL_STATUS = a.MATERIAL_STATUS,
                            WEDDING_ANNIVERSARY = a.WEDDING_ANNIVERSARY,
                            REPORTING_TO = a.REPORTING_TO,
                            GRADE = a.GRADE,
                            DIVISION = a.DIVISION,
                            SUBDIVISION = a.SUBDIVISION,
                            SECTION = a.SECTION,
                            BLOOD_GROUP = a.BLOOD_GROUP,
                            HEIGHT = a.HEIGHT,
                            WEIGHT = a.WEIGHT,
                            MEDICLAIM_NUMBER = a.MEDICLAIM_NUMBER,
                            ESIC_NO = a.ESIC_NO,
                            PF_UNID_NUMBER = a.PF_UNID_NUMBER,
                            HIRING_TYPE = a.HIRING_TYPE,
                            CV_TYPE = a.CV_TYPE,
                            YEAR_OF_EXPERIENCE = a.YEAR_OF_EXPERIENCE,
                            EXIT_DATE = a.EXIT_DATE,
                            EXIT_TYPE = a.EXIT_TYPE,
                            REFERENCE = a.REFERENCE,
                            WorkLocationname = a.WORKLOCATION.HasValue ? data3.Where(x => x.ID == a.WORKLOCATION).FirstOrDefault().LOCATION_NAME : null,
                            //departmentname = ps.
                            //designationname = Convert.ToString(a.TBL_HRMS_DESIGNATIONMASTER.DESIGNATION_NAME.FirstOrDefault()),
                            departmentname = a.DEPARTMENT.HasValue ? data2.Where(x => x.ID == a.DEPARTMENT).FirstOrDefault().DEPARTMENT_NAME : null,
                            designationname = a.DESIGNATION.HasValue ? data1.Where(x => x.ID == a.DESIGNATION).FirstOrDefault().DESIGNATION_NAME : null,
                            //EMPLOYEE_IMAGE = "http://localhost:56783/images/" + a.EMPLOYEE_IMAGE,
                            //PERSONAL_EMAIL = GetEmail(Convert.ToString(a.ID)),
                            //MOBILE_NUMBER = Getphoneno(Convert.ToString(a.ID)),
                            PERSONAL_EMAIL = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().PERSONAL_EMAIL : null,
                            OFFICIAL_EMAIL = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().OFFICIAL_EMAIL : null,
                            OFFICIAL_MOBILE_NUMBER = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().OFFICIAL_MOBILE_NUMBER : null,
                            EMERGENCY_CONTACT_NUMBER = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().EMERGENCY_CONTACT_NUMBER : null,
                            MOBILE_NUMBER = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().MOBILE_NUMBER : null,
                            Permanentaddress = a.TBL_EMP_COMMUNICATION_DETAILS.Count > 0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().PERMANENT_ADDRESS : null,
                            //PERSONAL_EMAIL = data3.Where(x=>x.EMPLOYEE_ID==a.ID).FirstOrDefault().PERSONAL_EMAIL,
                            //OFFICIAL_EMAIL = data3.Where(x => x.EMPLOYEE_ID == a.ID).FirstOrDefault().OFFICIAL_EMAIL,
                            //OFFICIAL_MOBILE_NUMBER = data3.Where(x => x.EMPLOYEE_ID == a.ID).FirstOrDefault().OFFICIAL_MOBILE_NUMBER,
                            //EMERGENCY_CONTACT_NUMBER = data3.Where(x => x.EMPLOYEE_ID == a.ID).FirstOrDefault().EMERGENCY_CONTACT_NUMBER,
                            //MOBILE_NUMBER = data3.Where(x => x.EMPLOYEE_ID == a.ID).FirstOrDefault().MOBILE_NUMBER,
                            EMPIMAGE = a.EMPIMG != null ? "data:image/png;base64," + Convert.ToBase64String(a.EMPIMG) : null,
                            DEPARTMENT = a.DEPARTMENT,
                            WORKLOCATION = a.WORKLOCATION,
                            STATUS = a.STATUS,
                            //locationname=f.LOCATION_NAME,
                            //DIVISIONNAME=g.DIV_NAME,
                            //SUB_DIVISIONNAME=h.SUB_DIV_NAME,
                            //SECTIONNAME=i.SEC_NAME,
                            gradename = a.GRADE.HasValue ? data4.Where(x => x.ID == a.GRADE).FirstOrDefault().GRADE_NAME : null,
                            bloodgroupname = a.BLOOD_GROUP.HasValue ? data5.Where(x => x.ID == a.BLOOD_GROUP).FirstOrDefault().BLOODGROUP_NAME : null,
                        }).ToList();
            return data;
        }

        public IEnumerable<IndivisualEmployeeEntities> GetAllEmployeeDetails()
        {
            throw new NotImplementedException();
        }
    }
}
