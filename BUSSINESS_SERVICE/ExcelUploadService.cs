using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Transactions;
using System.IO;

namespace BUSSINESS_SERVICE
{
    public class ExcelUploadService:IExcelUpload
    {
        private readonly UOW _UOW;
        public ExcelUploadService()
        {
            _UOW = new UOW();
        }

        public string Getsubdivisionid(string subdivname)
        {
            if (subdivname != null)
            {
                var subdivid = _UOW.SUBDIVISIONRepository.GetAll().Where(x => x.SUB_DIV_NAME.Contains(subdivname)).FirstOrDefault();
                if (subdivid != null)
                {
                    return subdivid.SUB_DIV_CODE;
                }
            }
            return null;
        }
        public string Getsectionid(string sectionname)
        {
            if (sectionname != null)
            {
                var secid = _UOW.SECTIONORepository.GetAll().Where(x => x.SEC_NAME.Contains(sectionname)).FirstOrDefault();
                if (secid != null)
                {
                    return secid.SEC_CODE;
                }
            }
            return null;
        }
        //public string Getdesigid(string designame)
        //{
        //    if (designame != null || designame != "")
        //    {
        //        var desigid = _UOW.DESIGNATIONRepository.GetAll().Where(x => x.DESIGNATION_NAME.Contains(designame)).FirstOrDefault();
        //        return Convert.ToString( desigid.ID);
        //    }
        //    return null;
        //}
        public decimal? Getdgradeid(string gradegname)
        {
            if (gradegname != null)
            {
                var gradeid = _UOW.GRADERepository.GetAll().Where(x => x.GRADE_NAME==gradegname).FirstOrDefault();
                
                if (gradeid!=null)
                {
                    return gradeid.ID;
                }
              
            }
            return null;
        }
        public decimal? Getdepartmentid(string deptname)
        {
            if (deptname != null )
            {
                var deptid = _UOW.DEPARTMENTRepository.GetAll().Where(x => x.DEPARTMENT_NAME==deptname).FirstOrDefault();
                if (deptid != null)
                {
                    return deptid.ID;
                }
            }
            return null;
        }
        public decimal? Getdesigid(string designame)
        {
            if (designame != null)
            {
                var desigid = _UOW.DESIGNATIONRepository.GetAll().Where(x => x.DESIGNATION_NAME==designame).FirstOrDefault();
                if (desigid!= null)
                {
                    return desigid.ID;
                }
            }
            return null;
        }
        public decimal? Getbloodgid(string bldgrpname)
        {
            if (bldgrpname != null)
            {
                var bldgrpid = _UOW.BLOODGROUPRepository.GetAll().Where(x => x.BLOODGROUP_NAME.Contains(bldgrpname)).FirstOrDefault();
                if (bldgrpid != null)
                {
                    return bldgrpid.ID;
                }
            }
            return null;
        }
        public int CreateExcelupload(ExcelUploadEntities ExcelUploadEntity)
        {
            //if (ExcelUploadEntity.SUBDIVISION!=null)
            //{
            //    ExcelUploadEntity.SUBDIVISION = Getsubdivisionid(ExcelUploadEntity.SUB_DIVISIONNAME);
            //}
            //if (ExcelUploadEntity.SECTION != null)
            //{
            //    ExcelUploadEntity.SECTION = Getsectionid(ExcelUploadEntity.SECTIONNAME);
            //}
            if (ExcelUploadEntity.gradename != null)
            {
                ExcelUploadEntity.GRADE = Getdgradeid(ExcelUploadEntity.gradename);
            }
            if (ExcelUploadEntity.departmentname != null)
            {
                ExcelUploadEntity.DEPARTMENT = Getdepartmentid(ExcelUploadEntity.departmentname);
            }
            if (ExcelUploadEntity.designationname != null)
            {
                ExcelUploadEntity.DESIGNATION = Getdesigid(ExcelUploadEntity.designationname);
            }
            //if (ExcelUploadEntity.bloodgroup != null)
            //{
            //    ExcelUploadEntity.BLOOD_GROUP = Getbloodgid(ExcelUploadEntity.bloodgroup);
            //}
           
          
            var bsicinfo = new TBL_EMP_BASICINFO
            {
                DESIGNATION = ExcelUploadEntity.DESIGNATION,
                JOINING_DATE = ExcelUploadEntity.JOINING_DATE,
                EMPLOYEE_CODE = ExcelUploadEntity.EMPLOYEE_CODE,
                EMPLOYEE_FIRSTNAME = ExcelUploadEntity.EMPLOYEE_FIRSTNAME,
                EMPLOYEE_MIDDLENAME = ExcelUploadEntity.EMPLOYEE_MIDDLENAME,
                EMPLOYEE_LASTNAME = ExcelUploadEntity.EMPLOYEE_LASTNAME,
                DATE_OF_BIRTH = ExcelUploadEntity.DATE_OF_BIRTH,
                AGE = ExcelUploadEntity.AGE,
                SEX = ExcelUploadEntity.SEX,
                MATERIAL_STATUS = ExcelUploadEntity.MATERIAL_STATUS,
                WEDDING_ANNIVERSARY = ExcelUploadEntity.WEDDING_ANNIVERSARY,
                REPORTING_TO = ExcelUploadEntity.REPORTING_TO,
                GRADE = ExcelUploadEntity.GRADE,
                DIVISION = ExcelUploadEntity.DIVISION,
                SUBDIVISION = ExcelUploadEntity.SUBDIVISION,
                SECTION = ExcelUploadEntity.SECTION,
                BLOOD_GROUP = ExcelUploadEntity.BLOOD_GROUP,
                HEIGHT = ExcelUploadEntity.HEIGHT,
                WEIGHT = ExcelUploadEntity.WEIGHT,
                MEDICLAIM_NUMBER = ExcelUploadEntity.MEDICLAIM_NUMBER,
                ESIC_NO = ExcelUploadEntity.ESIC_NO,
                PF_UNID_NUMBER = ExcelUploadEntity.PF_UNID_NUMBER,
                INDUCTION = ExcelUploadEntity.INDUCTION,
                IDENTIFICATION_MARK = ExcelUploadEntity.IDENTIFICATION_MARK,
                LAST_MAJOR_ILLNESS_SURGERY = ExcelUploadEntity.LAST_MAJOR_ILLNESS_SURGERY,
                ALLERGY_HISTORY = ExcelUploadEntity.ALLERGY_HISTORY,
                PHYSICAL_DISABILITY = ExcelUploadEntity.PHYSICAL_DISABILITY,
                HIRING_TYPE = ExcelUploadEntity.HIRING_TYPE,
                CV_TYPE = ExcelUploadEntity.CV_TYPE,
                YEAR_OF_EXPERIENCE = ExcelUploadEntity.YEAR_OF_EXPERIENCE,
                EXIT_DATE = ExcelUploadEntity.EXIT_DATE,
                EXIT_TYPE = ExcelUploadEntity.EXIT_TYPE,
                REFERENCE = ExcelUploadEntity.REFERENCE,
                DEPARTMENT = ExcelUploadEntity.DEPARTMENT,
                FULL_N_FINAL_STATUS = ExcelUploadEntity.FULL_N_FINAL_STATUS,
                MOTHERTOUNGE = ExcelUploadEntity.MOTHERTOUNGE,
                WORKLOCATION = ExcelUploadEntity.WORKLOCATION,
                RELIGION = ExcelUploadEntity.RELIGION,
                STATUS = ExcelUploadEntity.STATUS,
                EMPIMG=ExcelUploadEntity.EMPIMG

            };
            _UOW.EMP_BASICINFORepository.Insert(bsicinfo);
            _UOW.Save();
            TBL_EMP_TRANSFER_DETAILS tr = new TBL_EMP_TRANSFER_DETAILS();
            tr.EMPLOYEE_ID = Convert.ToDecimal(bsicinfo.ID);
            tr.DESIGNATION_ID = ExcelUploadEntity.DESIGNATION;
            tr.WORK_LOCATION = ExcelUploadEntity.WORKLOCATION;
            tr.DIVISION = ExcelUploadEntity.DIVISION;
            tr.SUB_DIVISION = ExcelUploadEntity.SUBDIVISION;
            tr.SECTION = ExcelUploadEntity.SECTION;
            tr.DEPARTMENT = ExcelUploadEntity.DEPARTMENT;
            tr.REPORTINGPERNAME = ExcelUploadEntity.REPORTING_TO;
            //tr.REPORTING_PERSON = Convert.ToDecimal(ExcelUploadEntity.REPORTING_TO);
            tr.FROM_DATE = ExcelUploadEntity.JOINING_DATE;
            tr.TO_DATE = ExcelUploadEntity.EXIT_DATE;
            tr.STATUS = ExcelUploadEntity.STATUS;
            _UOW.TRANSFER_DETAILSMASTERRepository.Insert(tr);
            _UOW.Save();
            if (ExcelUploadEntity.Account!=null)
            {
                foreach (var item in ExcelUploadEntity.Account)
                {
                    TBL_EMP_SALARYACCOUNTDETAILS sal = new TBL_EMP_SALARYACCOUNTDETAILS();
                    sal.EMPLOYEE_ID = Convert.ToDecimal(bsicinfo.ID);
                    sal.ACCOUNTNO = item.ACCOUNTNO;
                    sal.IFSCCODE = item.IFSCCODE;
                    sal.BRANCH = item.BRANCH;
                    sal.BANKNAME = item.BANKNAME;
                    sal.CTC = item.CTC;
                    _UOW.SALARYACCOUNTDETAILSRepository.Insert(sal);
                    _UOW.Save();
                }
            }
            if (ExcelUploadEntity.Relationship!=null)
            {
                foreach (var item in ExcelUploadEntity.Relationship)
                {
                    TBL_EMP_RELATIONSHIP_DETAILS rel = new TBL_EMP_RELATIONSHIP_DETAILS();
                    rel.EMPLOYEE_ID = Convert.ToDecimal(bsicinfo.ID);
                    rel.RELATIVE_NAME = item.RELATIVE_NAME;
                    rel.RELATIONSHIP = item.RELATIONSHIP;
                    rel.DATE_OF_BIRTH = item.DATE_OF_BIRTH;
                    _UOW.RELATIONSHIP_DETAILSRepository.Insert(rel);
                    _UOW.Save();
                }
            }
            if (ExcelUploadEntity.Communication != null)
            {
                foreach (var item in ExcelUploadEntity.Communication)
                {
                    TBL_EMP_COMMUNICATION_DETAILS rel = new TBL_EMP_COMMUNICATION_DETAILS();
                    rel.EMPLOYEE_ID = Convert.ToDecimal(bsicinfo.ID);
                    rel.PERMANENT_ADDRESS = item.PERMANENT_ADDRESS;
                    rel.MOBILE_NUMBER = item.MOBILE_NUMBER;
                    rel.PANCARD_NUMBER = item.PANCARD_NUMBER;
                    rel.EMERGENCY_CONTACT_NUMBER = item.EMERGENCY_CONTACT_NUMBER;
                    rel.OFFICIAL_MOBILE_NUMBER = item.OFFICIAL_MOBILE_NUMBER;
                    rel.OFFICIAL_EMAIL = item.OFFICIAL_EMAIL;
                    rel.PERSONAL_EMAIL = item.PERSONAL_EMAIL;
                    rel.AADHAR_NUMBER = item.AADHAR_NUMBER;
                    //rel.DATE_OF_BIRTH = item.DATE_OF_BIRTH;
                    _UOW.EMP_COMMUNICATION_DETAILSRepository.Insert(rel);
                    _UOW.Save();
                }
            }
            if (ExcelUploadEntity.qualification != null)
            {
                foreach (var item in ExcelUploadEntity.qualification)
                {
                    TBL_EMP_QUALIFICATION_DETAILS qual = new TBL_EMP_QUALIFICATION_DETAILS();
                    qual.EMPLOYEE_ID = Convert.ToDecimal(bsicinfo.ID);
                    qual.EXAM_DEGREE_TYPE = item.EXAM_DEGREE_TYPE;
                    qual.END_DATE = item.END_DATE;

                    _UOW.EMP_QUALIFICATION_DETAILSRepository.Insert(qual);
                    _UOW.Save();
                }
            }
            if (ExcelUploadEntity.Employment != null)
            {
                foreach (var item in ExcelUploadEntity.Employment)
                {
                    TBL_EMP_EMPLOYMENT_RECORD qual = new TBL_EMP_EMPLOYMENT_RECORD();
                    qual.EMPLOYEE_ID = Convert.ToDecimal(bsicinfo.ID);
                    qual.ORGANISATION_NAME = item.ORGANISATION_NAME;
                    _UOW.EMPLOYMENT_RECORDRepository.Insert(qual);
                    _UOW.Save();
                }
            }
           return Convert.ToInt32(bsicinfo.ID);
        }
    }
}
