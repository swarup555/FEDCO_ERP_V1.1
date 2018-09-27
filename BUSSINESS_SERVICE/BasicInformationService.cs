using DATA_LAYER.HRMSOUW;
using DATA_LAYER.HRMSGR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Transactions;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Runtime.Caching;
namespace BUSSINESS_SERVICE
{
    public class BasicInformationService : IBasicinfo
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly UOW _UOW;
        public BasicInformationService()
        {
            _UOW = new UOW();
        }
        public string GetdivisionName(string id)
        {
            if (id != null && id != "")
            {
                var divname = _UOW.DIVISIONRepository.GetByID(id);
                return divname.DIV_NAME;
            }
            return null;
        }
        public string GetsubdivisionName(string id)
        {
            if (id != null && id != "")
            {
                var subdivname = _UOW.SUBDIVISIONRepository.GetByID(id);
                return subdivname.SUB_DIV_NAME;
            }
            return null;
        }
        public string GetSectionnName(string id)
        {
            if (id != null && id != "")
            {
                var secname = _UOW.SECTIONORepository.GetByID(id);
                return secname.SEC_NAME;
            }
            return null;
        }
        public string Getphoneno(string id)
        {
            if (id != null && id != "")
            {
                var phoneno = _UOW.EMP_COMMUNICATION_DETAILSRepository.GetAll().Where(x => x.EMPLOYEE_ID == Convert.ToDecimal(id)).ToList();
                if (phoneno.ToList().Count > 0)
                {
                    return phoneno.ToList()[0].MOBILE_NUMBER;
                }
            }
            return null;
        }
        public string GetEmail(string id)
        {
            if (id != null && id != "")
            {
                var Email = _UOW.EMP_COMMUNICATION_DETAILSRepository.GetAll().Where(x => x.EMPLOYEE_ID == Convert.ToDecimal(id)).ToList();
                if (Email.ToList().Count > 0)
                {
                    return Email.ToList()[0].PERSONAL_EMAIL;
                }

            }
            return null;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            return null;
        }
        public IEnumerable<BasicInformaionEntities> GetEmployeebasicinfoById(int BasicinfoId)
        {
            try
            {

                var bsicinfo = (from a in _UOW.EMP_BASICINFORepository.GetManyQueryable(x => x.ID == BasicinfoId)
                                    select new BasicInformaionEntities
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
                                        AGE = a.DATE_OF_BIRTH.HasValue ? CalculateAge(Convert.ToDateTime(a.DATE_OF_BIRTH)) : null,
                                        SEX = a.SEX,
                                        DOMICILE_STATUS = a.DOMICILE_STATUS,
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
                                        INDUCTION = a.INDUCTION,
                                        IDENTIFICATION_MARK = a.IDENTIFICATION_MARK,
                                        LAST_MAJOR_ILLNESS_SURGERY = a.LAST_MAJOR_ILLNESS_SURGERY,
                                        ALLERGY_HISTORY = a.ALLERGY_HISTORY,
                                        PHYSICAL_DISABILITY = a.PHYSICAL_DISABILITY,
                                        HIRING_TYPE = a.HIRING_TYPE,
                                        CV_TYPE = a.CV_TYPE,
                                        YEAR_OF_EXPERIENCE = a.YEAR_OF_EXPERIENCE,
                                        EXIT_DATE = a.EXIT_DATE,
                                        EXIT_TYPE = a.EXIT_TYPE,
                                        REFERENCE = a.REFERENCE,
                                        DEPARTMENT = a.DEPARTMENT,
                                        departmentname = a.DEPARTMENT.HasValue ? _UOW.DEPARTMENTRepository.GetManyQueryable(x => x.ID == a.DEPARTMENT).FirstOrDefault().DEPARTMENT_NAME : null,
                                        designationname = a.DESIGNATION.HasValue ? _UOW.DESIGNATIONRepository.GetManyQueryable(x => x.ID == a.DESIGNATION).FirstOrDefault().DESIGNATION_NAME : null,
                                        DIVISIONNAME = GetdivisionName(a.DIVISION),
                                        SUB_DIVISIONNAME = GetsubdivisionName(a.SUBDIVISION),
                                        SECTIONNAME = GetSectionnName(a.SECTION),
                                        EMPLOYEE_IMAGE = a.EMPLOYEE_IMAGE,
                                        RELIGION = a.RELIGION,
                                        JOININGDATE = a.JOINING_DATE.HasValue ? a.JOINING_DATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                                        DOB = a.DATE_OF_BIRTH.HasValue ? a.DATE_OF_BIRTH.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                                        WEDDING = a.WEDDING_ANNIVERSARY.HasValue ? a.WEDDING_ANNIVERSARY.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                                        EXITDATE = a.EXIT_DATE.HasValue ? a.EXIT_DATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                                        WORKLOCATION = a.WORKLOCATION,
                                        MOTHERTOUNGE = a.MOTHERTOUNGE,
                                        FULL_N_FINAL_STATUS = a.FULL_N_FINAL_STATUS,
                                        EMPIMAGE = a.EMPIMG != null ? "data:image/jpg;base64," + Convert.ToBase64String(a.EMPIMG) : null,
                                        EXITCATAGORY = a.EXITCATAGORY,
                                        RESIGNATIONDATE = a.RESIGNATIONDATE.HasValue ? a.RESIGNATIONDATE.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : null,
                                        LEAVEENCASHMENT=a.LEAVEENCASHMENT
                                    }).ToList();

                   
                    return bsicinfo;
                
            }
            catch (Exception ex)
            {
                log.Debug("Debug error logging", ex);
                log.Info("Info error logging", ex);
                log.Warn("Warn error logging", ex);
                log.Error("Error error logging", ex);
                log.Fatal("Fatal error logging", ex);
                var outputLines = new List<string>();
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        ex.Message, ex.StackTrace,ex.InnerException,ex.HelpLink));
                   
                System.IO.File.AppendAllLines(@"D:\errors.txt", outputLines);
                return null;
            }
           
        }

        private static string CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return Convert.ToString(age);
        }
        public IEnumerable<BasicInformaionEntities> GetAllEmployeeBasicinfo()
        {
            try
            {
                var data1 =_UOW.DESIGNATIONRepository.GetAll();
                var data2 =_UOW.DEPARTMENTRepository.GetAll();
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
                                    DIVISION=a.DIVISION,
                                    SUBDIVISION=a.SUBDIVISION,
                                    SECTION=a.SECTION,
                                    BLOOD_GROUP=a.BLOOD_GROUP,
                                    EXIT_DATE=a.EXIT_DATE,
                                    departmentname = a.DEPARTMENT.HasValue ? data2.Where(x => x.ID == a.DEPARTMENT).FirstOrDefault().DEPARTMENT_NAME : null,
                                    designationname =a.DESIGNATION.HasValue? data1.Where(x => x.ID == a.DESIGNATION).FirstOrDefault().DESIGNATION_NAME:null,
                                    PERSONAL_EMAIL =a.TBL_EMP_COMMUNICATION_DETAILS.Count>0 ?  a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().PERSONAL_EMAIL:null,
                                    OFFICIAL_EMAIL = a.TBL_EMP_COMMUNICATION_DETAILS.Count>0 ? a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().OFFICIAL_EMAIL:null,
                                    OFFICIAL_MOBILE_NUMBER =a.TBL_EMP_COMMUNICATION_DETAILS.Count>0 ?  a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().OFFICIAL_MOBILE_NUMBER:null,
                                    EMERGENCY_CONTACT_NUMBER =a.TBL_EMP_COMMUNICATION_DETAILS.Count>0 ?  a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().EMERGENCY_CONTACT_NUMBER:null,
                                    MOBILE_NUMBER =a.TBL_EMP_COMMUNICATION_DETAILS.Count>0 ?  a.TBL_EMP_COMMUNICATION_DETAILS.FirstOrDefault().MOBILE_NUMBER:null,
                                    EMPIMAGE = a.EMPIMG != null ? "data:image/png;base64," + Convert.ToBase64String(a.EMPIMG) : null,
                                    DEPARTMENT=a.DEPARTMENT,
                                    WORKLOCATION=a.WORKLOCATION,
                                    STATUS=a.STATUS,
                                    GRADE=a.GRADE
                                }).ToList();
                return bsicinfo;
            }
            catch (Exception ex)
            {
                log.Debug("Debug error logging", ex);
                log.Info("Info error logging", ex);
                log.Warn("Warn error logging", ex);
                log.Error("Error error logging", ex);
                log.Fatal("Fatal error logging", ex);
                return null;
            }
           

         
        }

        public int CreateEmployeebasicinfo(BasicInformaionEntities BasicinfoEntities)
        {
            int status = 0;
            if (BasicinfoEntities != null)
            {
                try
                {
                    var project = _UOW.EMP_BASICINFORepository.GetByID(Convert.ToInt32(BasicinfoEntities.ID));
                    if (project != null)
                    {
                        if (BasicinfoEntities.JOININGDATE != null)
                        {
                            var joiningdate = DateTime.ParseExact(BasicinfoEntities.JOININGDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            project.JOINING_DATE = joiningdate;
                        }
                        if (BasicinfoEntities.EMPLOYEE_CODE != "" && BasicinfoEntities.EMPLOYEE_CODE != null)
                        {
                            project.EMPLOYEE_CODE = BasicinfoEntities.EMPLOYEE_CODE;
                        }
                        if (BasicinfoEntities.EMPLOYEE_FIRSTNAME != "" && BasicinfoEntities.EMPLOYEE_FIRSTNAME != null)
                        {
                            project.EMPLOYEE_FIRSTNAME = BasicinfoEntities.EMPLOYEE_FIRSTNAME;
                        }
                        if (BasicinfoEntities.EMPLOYEE_MIDDLENAME != "" && BasicinfoEntities.EMPLOYEE_MIDDLENAME != null)
                        {
                            project.EMPLOYEE_MIDDLENAME = BasicinfoEntities.EMPLOYEE_MIDDLENAME;
                        }
                        if (BasicinfoEntities.EMPLOYEE_LASTNAME != "" && BasicinfoEntities.EMPLOYEE_LASTNAME != null)
                        {
                            project.EMPLOYEE_LASTNAME = BasicinfoEntities.EMPLOYEE_LASTNAME;
                        }
                        if (BasicinfoEntities.DOB != null && BasicinfoEntities.DOB != "")
                        {
                            var DOB = DateTime.ParseExact(BasicinfoEntities.DOB, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            project.DATE_OF_BIRTH = DOB;
                        }
                        if (BasicinfoEntities.AGE != null)
                        {
                            project.AGE = BasicinfoEntities.AGE;
                        }
                        if (BasicinfoEntities.SEX != "" && BasicinfoEntities.SEX != null)
                        {
                            project.SEX = BasicinfoEntities.SEX;
                        }
                        if (BasicinfoEntities.MATERIAL_STATUS != "" && BasicinfoEntities.MATERIAL_STATUS != null)
                        {
                            project.MATERIAL_STATUS = BasicinfoEntities.MATERIAL_STATUS;
                        }
                        if (BasicinfoEntities.WEDDING != null && BasicinfoEntities.WEDDING != "")
                        {
                            var WEDDING = DateTime.ParseExact(BasicinfoEntities.WEDDING, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            project.WEDDING_ANNIVERSARY = WEDDING;
                        }
                        if (BasicinfoEntities.REPORTING_TO != "" && BasicinfoEntities.REPORTING_TO != "0")
                        {
                            project.REPORTING_TO = BasicinfoEntities.REPORTING_TO;
                        }
                        if (BasicinfoEntities.DEPARTMENT != null && BasicinfoEntities.DEPARTMENT != 0)
                        {
                            project.DEPARTMENT = BasicinfoEntities.DEPARTMENT;
                        }
                        if (BasicinfoEntities.DESIGNATION != null && BasicinfoEntities.DESIGNATION != 0)
                        {
                            project.DESIGNATION = BasicinfoEntities.DESIGNATION;
                        }
                        if (BasicinfoEntities.GRADE != null && BasicinfoEntities.GRADE != 0)
                        {
                            project.GRADE = BasicinfoEntities.GRADE;
                        }
                        if (BasicinfoEntities.DIVISION != "" && BasicinfoEntities.DIVISION != "0")
                        {
                            project.DIVISION = BasicinfoEntities.DIVISION;
                        }
                        if (BasicinfoEntities.SUBDIVISION != "" && BasicinfoEntities.SUBDIVISION != "0")
                        {
                            project.SUBDIVISION = BasicinfoEntities.SUBDIVISION;
                        }
                        if (BasicinfoEntities.SECTION != "" && BasicinfoEntities.SECTION != "0")
                        {
                            project.SECTION = BasicinfoEntities.SECTION;
                        }
                        if (BasicinfoEntities.BLOOD_GROUP != null && BasicinfoEntities.BLOOD_GROUP != 0)
                        {
                            project.BLOOD_GROUP = BasicinfoEntities.BLOOD_GROUP;
                        }
                        if (BasicinfoEntities.HEIGHT != null)
                        {
                            project.HEIGHT = BasicinfoEntities.HEIGHT;
                        }
                        if (BasicinfoEntities.WEIGHT != null)
                        {
                            project.WEIGHT = BasicinfoEntities.WEIGHT;
                        }
                        if (BasicinfoEntities.MEDICLAIM_NUMBER != "" && BasicinfoEntities.MEDICLAIM_NUMBER != null)
                        {
                            project.MEDICLAIM_NUMBER = BasicinfoEntities.MEDICLAIM_NUMBER;
                        }
                        if (BasicinfoEntities.ESIC_NO != "" && BasicinfoEntities.ESIC_NO != null)
                        {
                            project.ESIC_NO = BasicinfoEntities.ESIC_NO;
                        }
                        if (BasicinfoEntities.PF_UNID_NUMBER != "" && BasicinfoEntities.PF_UNID_NUMBER != null)
                        {
                            project.PF_UNID_NUMBER = BasicinfoEntities.PF_UNID_NUMBER;
                        }
                        if (BasicinfoEntities.INDUCTION != "" && BasicinfoEntities.INDUCTION != null)
                        {
                            project.INDUCTION = BasicinfoEntities.INDUCTION;
                        }
                        if (BasicinfoEntities.IDENTIFICATION_MARK != "" && BasicinfoEntities.IDENTIFICATION_MARK != null)
                        {
                            project.IDENTIFICATION_MARK = BasicinfoEntities.IDENTIFICATION_MARK;
                        }
                        if (BasicinfoEntities.LAST_MAJOR_ILLNESS_SURGERY != "" && BasicinfoEntities.LAST_MAJOR_ILLNESS_SURGERY != null)
                        {
                            project.LAST_MAJOR_ILLNESS_SURGERY = BasicinfoEntities.LAST_MAJOR_ILLNESS_SURGERY;
                        }
                        if (BasicinfoEntities.ALLERGY_HISTORY != "" && BasicinfoEntities.ALLERGY_HISTORY != null)
                        {
                            project.ALLERGY_HISTORY = BasicinfoEntities.ALLERGY_HISTORY;
                        }
                        if (BasicinfoEntities.PHYSICAL_DISABILITY != "" && BasicinfoEntities.PHYSICAL_DISABILITY != null)
                        {
                            project.PHYSICAL_DISABILITY = BasicinfoEntities.PHYSICAL_DISABILITY;
                        }
                        if (BasicinfoEntities.HIRING_TYPE != "" && BasicinfoEntities.HIRING_TYPE != "0")
                        {
                            project.HIRING_TYPE = BasicinfoEntities.HIRING_TYPE;
                        }
                        if (BasicinfoEntities.CV_TYPE != "" && BasicinfoEntities.CV_TYPE != "0")
                        {
                            project.CV_TYPE = BasicinfoEntities.CV_TYPE;
                        }
                        if (BasicinfoEntities.YEAR_OF_EXPERIENCE != null)
                        {
                            project.YEAR_OF_EXPERIENCE = BasicinfoEntities.YEAR_OF_EXPERIENCE;
                        }
                        if (BasicinfoEntities.EXITDATE != null && BasicinfoEntities.EXITDATE != null)
                        {
                            var EXITDATE = DateTime.ParseExact(BasicinfoEntities.EXITDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            project.EXIT_DATE = EXITDATE;
                            var trdtls = _UOW.TRANSFER_DETAILSMASTERRepository.GetManyQueryable(x => x.EMPLOYEE_ID == BasicinfoEntities.ID).OrderBy(y => y.ID).LastOrDefault();
                            if(trdtls!=null)
                            {
                                trdtls.TO_DATE = EXITDATE;
                                trdtls.STATUS = "Inactive";
                            }
                            _UOW.TRANSFER_DETAILSMASTERRepository.Update(trdtls);
                            _UOW.Save();
                            project.STATUS = "Inactive";
                        }
                        if (BasicinfoEntities.RESIGNATIONDATE != "" && BasicinfoEntities.RESIGNATIONDATE != null)
                        {
                            var resigndate = DateTime.ParseExact(BasicinfoEntities.RESIGNATIONDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            project.RESIGNATIONDATE = resigndate;
                        }
                        if (BasicinfoEntities.LEAVEENCASHMENT != "" && BasicinfoEntities.LEAVEENCASHMENT != null)
                        {
                            project.LEAVEENCASHMENT = BasicinfoEntities.LEAVEENCASHMENT;
                        }
                        if (BasicinfoEntities.EXIT_TYPE != null && BasicinfoEntities.EXIT_TYPE != 0)
                        {
                            project.EXIT_TYPE = BasicinfoEntities.EXIT_TYPE;
                        }
                        if (BasicinfoEntities.REFERENCE != "" && BasicinfoEntities.REFERENCE != null)
                        {
                            project.REFERENCE = BasicinfoEntities.REFERENCE;
                        }
                        if (BasicinfoEntities.FULL_N_FINAL_STATUS != "0" && BasicinfoEntities.FULL_N_FINAL_STATUS != null)
                        {
                            project.FULL_N_FINAL_STATUS = BasicinfoEntities.FULL_N_FINAL_STATUS;
                        }
                        if (BasicinfoEntities.WORKLOCATION != null && BasicinfoEntities.WORKLOCATION != 0)
                        {
                            project.WORKLOCATION = BasicinfoEntities.WORKLOCATION;
                        }
                        if (BasicinfoEntities.RELIGION != "" && BasicinfoEntities.RELIGION != null)
                        {
                            project.RELIGION = BasicinfoEntities.RELIGION;
                        }
                        if (BasicinfoEntities.MOTHERTOUNGE != "" && BasicinfoEntities.MOTHERTOUNGE != null)
                        {
                            project.MOTHERTOUNGE = BasicinfoEntities.MOTHERTOUNGE;
                        }
                        if (BasicinfoEntities.DOMICILE_STATUS != "" && BasicinfoEntities.DOMICILE_STATUS != null)
                        {
                            project.DOMICILE_STATUS = BasicinfoEntities.DOMICILE_STATUS;
                        }
                        if ( BasicinfoEntities.EXITCATAGORY != null)
                        {
                            project.EXITCATAGORY = BasicinfoEntities.EXITCATAGORY;
                        }
                        //cache.Remove(CacheKey);
                        _UOW.EMP_BASICINFORepository.Update(project);
                        _UOW.Save();
                        status = Convert.ToInt32(BasicinfoEntities.ID);
                    }
                    else
                    {
                        var joiningdate = (DateTime?)null; 
                        //DateTime joiningdate = Convert.ToDateTime(BasicinfoEntities.JOININGDATE);
                        if (BasicinfoEntities.JOININGDATE != null)
                        {
                            joiningdate = DateTime.ParseExact(BasicinfoEntities.JOININGDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                        //var joiningdate = DateTime.ParseExact(BasicinfoEntities.JOININGDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        var bsicinfo = new TBL_EMP_BASICINFO
                        {
                            DESIGNATION = BasicinfoEntities.DESIGNATION,
                            JOINING_DATE = joiningdate,
                            EMPLOYEE_CODE = BasicinfoEntities.EMPLOYEE_CODE,
                            EMPLOYEE_FIRSTNAME = BasicinfoEntities.EMPLOYEE_FIRSTNAME,
                            EMPLOYEE_MIDDLENAME = BasicinfoEntities.EMPLOYEE_MIDDLENAME,
                            EMPLOYEE_LASTNAME = BasicinfoEntities.EMPLOYEE_LASTNAME,
                            DATE_OF_BIRTH = BasicinfoEntities.DATE_OF_BIRTH,
                            AGE = BasicinfoEntities.AGE,
                            SEX = BasicinfoEntities.SEX,
                            MATERIAL_STATUS = BasicinfoEntities.MATERIAL_STATUS,
                            WEDDING_ANNIVERSARY = BasicinfoEntities.WEDDING_ANNIVERSARY,
                            REPORTING_TO = BasicinfoEntities.REPORTING_TO,
                            GRADE = BasicinfoEntities.GRADE,
                            DIVISION = BasicinfoEntities.DIVISION,
                            SUBDIVISION = BasicinfoEntities.SUBDIVISION,
                            SECTION = BasicinfoEntities.SECTION,
                            BLOOD_GROUP = BasicinfoEntities.BLOOD_GROUP,
                            HEIGHT = BasicinfoEntities.HEIGHT,
                            WEIGHT = BasicinfoEntities.WEIGHT,
                            MEDICLAIM_NUMBER = BasicinfoEntities.MEDICLAIM_NUMBER,
                            ESIC_NO = BasicinfoEntities.ESIC_NO,
                            PF_UNID_NUMBER = BasicinfoEntities.PF_UNID_NUMBER,
                            INDUCTION = BasicinfoEntities.INDUCTION,
                            IDENTIFICATION_MARK = BasicinfoEntities.IDENTIFICATION_MARK,
                            LAST_MAJOR_ILLNESS_SURGERY = BasicinfoEntities.LAST_MAJOR_ILLNESS_SURGERY,
                            ALLERGY_HISTORY = BasicinfoEntities.ALLERGY_HISTORY,
                            PHYSICAL_DISABILITY = BasicinfoEntities.PHYSICAL_DISABILITY,
                            HIRING_TYPE = BasicinfoEntities.HIRING_TYPE,
                            CV_TYPE = BasicinfoEntities.CV_TYPE,
                            YEAR_OF_EXPERIENCE = BasicinfoEntities.YEAR_OF_EXPERIENCE,
                            EXIT_DATE = BasicinfoEntities.EXIT_DATE,
                            EXIT_TYPE = BasicinfoEntities.EXIT_TYPE,
                            REFERENCE = BasicinfoEntities.REFERENCE,
                            DEPARTMENT = BasicinfoEntities.DEPARTMENT,
                            FULL_N_FINAL_STATUS = BasicinfoEntities.FULL_N_FINAL_STATUS,
                            MOTHERTOUNGE = BasicinfoEntities.MOTHERTOUNGE,
                            WORKLOCATION = BasicinfoEntities.WORKLOCATION,
                            RELIGION = BasicinfoEntities.RELIGION,
                            STATUS="Active",

                        };
                        //cache.Remove(CacheKey);
                        _UOW.EMP_BASICINFORepository.Insert(bsicinfo);
                        _UOW.Save();
                        TBL_EMP_TRANSFER_DETAILS tr = new TBL_EMP_TRANSFER_DETAILS();
                        tr.EMPLOYEE_ID = Convert.ToDecimal(bsicinfo.ID);
                        tr.DESIGNATION_ID = BasicinfoEntities.DESIGNATION;
                        tr.WORK_LOCATION = BasicinfoEntities.WORKLOCATION;
                        tr.DIVISION = BasicinfoEntities.DIVISION;
                        tr.SUB_DIVISION = BasicinfoEntities.SUBDIVISION;
                        tr.SECTION = BasicinfoEntities.SECTION;
                        tr.DEPARTMENT = BasicinfoEntities.DEPARTMENT;
                        tr.REPORTINGPERNAME = BasicinfoEntities.REPORTING_TO;
                        tr.FROM_DATE =joiningdate;
                        _UOW.TRANSFER_DETAILSMASTERRepository.Insert(tr);
                        _UOW.Save();
                        status = Convert.ToInt32(bsicinfo.ID);
                    }
                }
                catch (Exception ex)
                {
                    log.Debug("Debug error logging", ex);
                    log.Info("Info error logging", ex);
                    log.Warn("Warn error logging", ex);
                    log.Error("Error error logging", ex);
                    log.Fatal("Fatal error logging", ex);
                    var outputLines = new List<string>();
                    //foreach (var eve in ex.Message)
                    //{
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        ex.Message, ex.StackTrace, ex.InnerException, ex.HelpLink));
                    //foreach (var ve in eve.ValidationErrors)
                    //{
                    //    outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    //}
                    //}

                    System.IO.File.AppendAllLines(@"D:\errors.txt", outputLines);
                }
               

            }
            return status;
        }

        public bool UpdateEmployeebasicinfo(int BasicinfoId, BasicInformaionEntities BasicinfoEntities)
        {
            var success = false;
            if (BasicinfoEntities != null)
            {
                //using (var scope = new TransactionScope())
                //    {
                try
                {
                    var project = _UOW.EMP_BASICINFORepository.GetByID(BasicinfoId);
                    if (project != null)
                    {
                        if (BasicinfoEntities.EMPLOYEE_CODE != "" && BasicinfoEntities.EMPLOYEE_CODE != null)
                        {
                            project.EMPLOYEE_CODE = BasicinfoEntities.EMPLOYEE_CODE;
                        }
                        if (BasicinfoEntities.EMPLOYEE_FIRSTNAME != "" && BasicinfoEntities.EMPLOYEE_FIRSTNAME != null)
                        {
                            project.EMPLOYEE_FIRSTNAME = BasicinfoEntities.EMPLOYEE_FIRSTNAME;
                        }
                        if (BasicinfoEntities.EMPLOYEE_MIDDLENAME != "" && BasicinfoEntities.EMPLOYEE_MIDDLENAME != null)
                        {
                            project.EMPLOYEE_MIDDLENAME = BasicinfoEntities.EMPLOYEE_MIDDLENAME;
                        }
                        if (BasicinfoEntities.EMPLOYEE_FIRSTNAME != "" && BasicinfoEntities.EMPLOYEE_FIRSTNAME != null)
                        {
                            project.EMPLOYEE_FIRSTNAME = BasicinfoEntities.EMPLOYEE_FIRSTNAME;
                        }
                        if (BasicinfoEntities.DATE_OF_BIRTH != null)
                        {
                            project.DATE_OF_BIRTH = BasicinfoEntities.DATE_OF_BIRTH;
                        }
                        if (BasicinfoEntities.AGE != null)
                        {
                            project.AGE = BasicinfoEntities.AGE;
                        }
                        if (BasicinfoEntities.SEX != "" && BasicinfoEntities.SEX != null)
                        {
                            project.SEX = BasicinfoEntities.SEX;
                        }
                        if (BasicinfoEntities.MATERIAL_STATUS != "" && BasicinfoEntities.MATERIAL_STATUS != null)
                        {
                            project.MATERIAL_STATUS = BasicinfoEntities.MATERIAL_STATUS;
                        }
                        if (BasicinfoEntities.WEDDING_ANNIVERSARY != null)
                        {
                            project.WEDDING_ANNIVERSARY = BasicinfoEntities.WEDDING_ANNIVERSARY;
                        }
                        if (BasicinfoEntities.REPORTING_TO != "" && BasicinfoEntities.REPORTING_TO != null)
                        {
                            project.REPORTING_TO = BasicinfoEntities.REPORTING_TO;
                        }
                        if (BasicinfoEntities.GRADE != null)
                        {
                            project.GRADE = BasicinfoEntities.GRADE;
                        }
                        if (BasicinfoEntities.DIVISION != "" && BasicinfoEntities.DIVISION != null)
                        {
                            project.DIVISION = BasicinfoEntities.DIVISION;
                        }
                        if (BasicinfoEntities.SUBDIVISION != "" && BasicinfoEntities.SUBDIVISION != null)
                        {
                            project.SUBDIVISION = BasicinfoEntities.SUBDIVISION;
                        }
                        if (BasicinfoEntities.SECTION != "" && BasicinfoEntities.SECTION != null)
                        {
                            project.SECTION = BasicinfoEntities.SECTION;
                        }
                        if (BasicinfoEntities.BLOOD_GROUP != null)
                        {
                            project.BLOOD_GROUP = BasicinfoEntities.BLOOD_GROUP;
                        }
                        if (BasicinfoEntities.HEIGHT != null)
                        {
                            project.HEIGHT = BasicinfoEntities.HEIGHT;
                        }
                        if (BasicinfoEntities.WEIGHT != null)
                        {
                            project.WEIGHT = BasicinfoEntities.WEIGHT;
                        }
                        if (BasicinfoEntities.MEDICLAIM_NUMBER != "" && BasicinfoEntities.MEDICLAIM_NUMBER != null)
                        {
                            project.MEDICLAIM_NUMBER = BasicinfoEntities.MEDICLAIM_NUMBER;
                        }
                        if (BasicinfoEntities.ESIC_NO != "" && BasicinfoEntities.ESIC_NO != null)
                        {
                            project.ESIC_NO = BasicinfoEntities.ESIC_NO;
                        }
                        if (BasicinfoEntities.PF_UNID_NUMBER != "" && BasicinfoEntities.PF_UNID_NUMBER != null)
                        {
                            project.PF_UNID_NUMBER = BasicinfoEntities.PF_UNID_NUMBER;
                        }
                        if (BasicinfoEntities.INDUCTION != "" && BasicinfoEntities.INDUCTION != null)
                        {
                            project.INDUCTION = BasicinfoEntities.INDUCTION;
                        }
                        if (BasicinfoEntities.IDENTIFICATION_MARK != "" && BasicinfoEntities.IDENTIFICATION_MARK != null)
                        {
                            project.IDENTIFICATION_MARK = BasicinfoEntities.IDENTIFICATION_MARK;
                        }
                        if (BasicinfoEntities.LAST_MAJOR_ILLNESS_SURGERY != "" && BasicinfoEntities.LAST_MAJOR_ILLNESS_SURGERY != null)
                        {
                            project.LAST_MAJOR_ILLNESS_SURGERY = BasicinfoEntities.LAST_MAJOR_ILLNESS_SURGERY;
                        }
                        if (BasicinfoEntities.ALLERGY_HISTORY != "" && BasicinfoEntities.ALLERGY_HISTORY != null)
                        {
                            project.ALLERGY_HISTORY = BasicinfoEntities.ALLERGY_HISTORY;
                        }
                        if (BasicinfoEntities.PHYSICAL_DISABILITY != "" && BasicinfoEntities.PHYSICAL_DISABILITY != null)
                        {
                            project.PHYSICAL_DISABILITY = BasicinfoEntities.PHYSICAL_DISABILITY;
                        }
                        if (BasicinfoEntities.HIRING_TYPE != "" && BasicinfoEntities.HIRING_TYPE != null)
                        {
                            project.HIRING_TYPE = BasicinfoEntities.HIRING_TYPE;
                        }
                        if (BasicinfoEntities.CV_TYPE != "" && BasicinfoEntities.CV_TYPE != null)
                        {
                            project.CV_TYPE = BasicinfoEntities.CV_TYPE;
                        }
                        if (BasicinfoEntities.YEAR_OF_EXPERIENCE != null)
                        {
                            project.YEAR_OF_EXPERIENCE = BasicinfoEntities.YEAR_OF_EXPERIENCE;
                        }
                        if (BasicinfoEntities.EXIT_DATE != null)
                        {
                            project.EXIT_DATE = BasicinfoEntities.EXIT_DATE;
                        }
                        if (BasicinfoEntities.EXIT_TYPE != null)
                        {
                            project.EXIT_TYPE = BasicinfoEntities.EXIT_TYPE;
                        }
                        if (BasicinfoEntities.REFERENCE != "" && BasicinfoEntities.REFERENCE != null)
                        {
                            project.REFERENCE = BasicinfoEntities.REFERENCE;
                        }
                        if (BasicinfoEntities.EMPLOYEE_IMAGE != "" && BasicinfoEntities.EMPLOYEE_IMAGE != null)
                        {
                            project.EMPLOYEE_IMAGE = BasicinfoEntities.EMPLOYEE_IMAGE;
                        }
                        if (BasicinfoEntities.EMPIMG != null)
                        {
                            project.EMPIMG = BasicinfoEntities.EMPIMG;
                        }
                        //cache.Remove(CacheKey);
                        _UOW.EMP_BASICINFORepository.Update(project);
                        _UOW.Save();
                        //scope.Complete();
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    log.Debug("Debug error logging", ex);
                    log.Info("Info error logging", ex);
                    log.Warn("Warn error logging", ex);
                    log.Error("Error error logging", ex);
                    log.Fatal("Fatal error logging", ex);
                }
               
                //}
            }
            return success;
        }


        public bool DeleteEmployeebasicinfo(int BasicinfoId)
        {
            throw new NotImplementedException();
        }
    }
}
