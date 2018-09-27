using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Transactions;
using System.Globalization;

namespace BUSSINESS_SERVICE
{
    public class EmploymentService : IEmploymentDetails
    {
        private readonly UOW _UOW;
        public EmploymentService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<BUSSINESS_ENTITIES.EmploymentEntities> GetEmploymentDetailsById(int EmploymentDetailsId)
        {
            var employmentdata = (from emp in _UOW.EMPLOYMENT_RECORDRepository.GetAll()
                                  where emp.EMPLOYEE_ID == EmploymentDetailsId
                                  select new EmploymentEntities
                                  {
                                      ID = emp.ID,
                                      EMPLOYEE_ID = emp.EMPLOYEE_ID,
                                      ORGANISATION_NAME = emp.ORGANISATION_NAME,
                                      JOINING_DATE = emp.JOINING_DATE,
                                      RELIEVING_DATE = emp.RELIEVING_DATE,
                                      LAST_DESIGNATION = emp.LAST_DESIGNATION,
                                      JOINING_EMOLUMENTS = emp.JOINING_EMOLUMENTS,
                                      LEAVING_EMOLUMENTS = emp.LEAVING_EMOLUMENTS,
                                      REASON_FOR_LEAVING = emp.REASON_FOR_LEAVING
                                  }).ToList();
            return employmentdata;
        }

        public IEnumerable<BUSSINESS_ENTITIES.EmploymentEntities> GetAllEmploymentDetails()
        {
            var employmentdata = (from emp in _UOW.EMPLOYMENT_RECORDRepository.GetAll()
                                  select new EmploymentEntities
                                  {
                                      ID = emp.ID,
                                      EMPLOYEE_ID = emp.EMPLOYEE_ID,
                                      ORGANISATION_NAME = emp.ORGANISATION_NAME,
                                      JOINING_DATE = emp.JOINING_DATE,
                                      RELIEVING_DATE = emp.RELIEVING_DATE,
                                      LAST_DESIGNATION = emp.LAST_DESIGNATION,
                                      JOINING_EMOLUMENTS = emp.JOINING_EMOLUMENTS,
                                      LEAVING_EMOLUMENTS = emp.LEAVING_EMOLUMENTS,
                                      REASON_FOR_LEAVING = emp.REASON_FOR_LEAVING
                                  }).ToList();
            return employmentdata;
        }

        public int CreateEmploymentDetails(BUSSINESS_ENTITIES.EmploymentEntities EmploymentDetailsEntities)
        {
            //DateTime? joindate = null;
            //DateTime? releivedate = null;
            var joindate = (DateTime?)null;
            var releivedate = (DateTime?)null;
            if (EmploymentDetailsEntities.JOININGDATE != "" && EmploymentDetailsEntities.JOININGDATE != null)
            {
                joindate = DateTime.ParseExact(EmploymentDetailsEntities.JOININGDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (EmploymentDetailsEntities.RELIEVINGDATE != "" && EmploymentDetailsEntities.RELIEVINGDATE != null)
            {
                releivedate = DateTime.ParseExact(EmploymentDetailsEntities.RELIEVINGDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (EmploymentDetailsEntities != null)
            {

                var QualificationDetail = new TBL_EMP_EMPLOYMENT_RECORD
                {
                    EMPLOYEE_ID = EmploymentDetailsEntities.EMPLOYEE_ID,
                    ORGANISATION_NAME = EmploymentDetailsEntities.ORGANISATION_NAME,
                    JOINING_DATE = joindate,
                    RELIEVING_DATE = releivedate,
                    LAST_DESIGNATION = EmploymentDetailsEntities.LAST_DESIGNATION,
                    JOINING_EMOLUMENTS = EmploymentDetailsEntities.JOINING_EMOLUMENTS,
                    LEAVING_EMOLUMENTS = EmploymentDetailsEntities.LEAVING_EMOLUMENTS,
                    REASON_FOR_LEAVING = EmploymentDetailsEntities.REASON_FOR_LEAVING
                };
                _UOW.EMPLOYMENT_RECORDRepository.Insert(QualificationDetail);
                _UOW.Save();
            }

            return Convert.ToInt32(EmploymentDetailsEntities.ID);
        }

        public bool UpdateEmploymentDetails(int EmploymentDetailsId, BUSSINESS_ENTITIES.EmploymentEntities EmploymentDetailsEntities)
        {
            var joindate = (DateTime?)null;
            var releivedate = (DateTime?)null;
            if (EmploymentDetailsEntities.JOININGDATE != "" && EmploymentDetailsEntities.JOININGDATE != null)
            {
                joindate = DateTime.ParseExact(EmploymentDetailsEntities.JOININGDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (EmploymentDetailsEntities.RELIEVINGDATE != "" && EmploymentDetailsEntities.RELIEVINGDATE != null)
            {
                releivedate = DateTime.ParseExact(EmploymentDetailsEntities.RELIEVINGDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            var success = false;
            if (EmploymentDetailsEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var EmploymentDetail = _UOW.EMPLOYMENT_RECORDRepository.GetByID(EmploymentDetailsId);
                if (EmploymentDetail != null)
                {
                    if (EmploymentDetailsEntities.EMPLOYEE_ID != null)
                    {
                        EmploymentDetail.EMPLOYEE_ID = EmploymentDetailsEntities.EMPLOYEE_ID;
                    }
                    if (EmploymentDetailsEntities.ORGANISATION_NAME != "" && EmploymentDetailsEntities.ORGANISATION_NAME != null)
                    {
                        EmploymentDetail.ORGANISATION_NAME = EmploymentDetailsEntities.ORGANISATION_NAME;
                    }
                    if (EmploymentDetailsEntities.JOININGDATE != null && EmploymentDetailsEntities.JOININGDATE != "")
                    {
                        EmploymentDetail.JOINING_DATE = joindate;
                    }
                    if (EmploymentDetailsEntities.RELIEVINGDATE != null && EmploymentDetailsEntities.RELIEVINGDATE != "")
                    {
                        EmploymentDetail.RELIEVING_DATE = releivedate;
                    }
                    if (EmploymentDetailsEntities.LAST_DESIGNATION != null)
                    {
                        EmploymentDetail.LAST_DESIGNATION = EmploymentDetailsEntities.LAST_DESIGNATION;
                    }
                    if (EmploymentDetailsEntities.JOINING_EMOLUMENTS != null)
                    {
                        EmploymentDetail.JOINING_EMOLUMENTS = EmploymentDetailsEntities.JOINING_EMOLUMENTS;
                    }
                    if (EmploymentDetailsEntities.LEAVING_EMOLUMENTS != null)
                    {
                        EmploymentDetail.LEAVING_EMOLUMENTS = EmploymentDetailsEntities.LEAVING_EMOLUMENTS;
                    }
                    if (EmploymentDetailsEntities.REASON_FOR_LEAVING != "" && EmploymentDetailsEntities.REASON_FOR_LEAVING != null)
                    {
                        EmploymentDetail.REASON_FOR_LEAVING = EmploymentDetailsEntities.REASON_FOR_LEAVING;
                    }

                    _UOW.EMPLOYMENT_RECORDRepository.Update(EmploymentDetail);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteEmploymentDetails(int EmploymentDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
