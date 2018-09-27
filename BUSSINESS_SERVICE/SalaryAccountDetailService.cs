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
    public class SalaryAccountDetailService:ISalaryAccountDetails
    {
        private readonly UOW _UOW;
        public SalaryAccountDetailService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<EmpAcountEntity> GetSalaryAccountDetailsById(int SalaryAccountDetailsId)
        {
            var salaryaccdtls = (from sal in _UOW.SALARYACCOUNTDETAILSRepository.GetAll()
                                 where sal.EMPLOYEE_ID == SalaryAccountDetailsId
                                 select new EmpAcountEntity
                                 {
                                     ID = sal.ID,
                                     EMPLOYEE_ID = sal.EMPLOYEE_ID,
                                     ACCOUNTNO = sal.ACCOUNTNO,
                                     IFSCCODE = sal.IFSCCODE,
                                     BRANCH = sal.BRANCH,
                                     BANKNAME=sal.BANKNAME,CTC=sal.CTC
                                 }).ToList();
            return salaryaccdtls;
        }

        public IEnumerable<EmpAcountEntity> GetAllSalaryAccountDetails()
        {
            throw new NotImplementedException();
        }

        public int CreateSalaryAccountDetails(EmpAcountEntity SalaryAccountDetailsEntities)
        {
            if (SalaryAccountDetailsEntities != null)
            {
                var SalaryAccountDetailsDetail = _UOW.SALARYACCOUNTDETAILSRepository.GetAll().ToList().Where(x => x.EMPLOYEE_ID == SalaryAccountDetailsEntities.EMPLOYEE_ID).FirstOrDefault();
                if (SalaryAccountDetailsDetail != null)
                {
                    if (SalaryAccountDetailsEntities.ACCOUNTNO != "" && SalaryAccountDetailsEntities.ACCOUNTNO != null)
                    {
                        SalaryAccountDetailsDetail.ACCOUNTNO = SalaryAccountDetailsEntities.ACCOUNTNO;
                    }
                    if (SalaryAccountDetailsEntities.IFSCCODE != "" && SalaryAccountDetailsEntities.IFSCCODE != null)
                    {
                        SalaryAccountDetailsDetail.IFSCCODE = SalaryAccountDetailsEntities.IFSCCODE;
                    }

                    if (SalaryAccountDetailsEntities.BRANCH != null && SalaryAccountDetailsEntities.BRANCH != "")
                    {
                        SalaryAccountDetailsDetail.BRANCH = SalaryAccountDetailsEntities.BRANCH;
                    }
                    if (SalaryAccountDetailsEntities.BANKNAME != null && SalaryAccountDetailsEntities.BANKNAME != "")
                    {
                        SalaryAccountDetailsDetail.BANKNAME = SalaryAccountDetailsEntities.BANKNAME;
                    }
                    if (SalaryAccountDetailsEntities.CTC != null && SalaryAccountDetailsEntities.CTC != "")
                    {
                        SalaryAccountDetailsDetail.CTC = SalaryAccountDetailsEntities.CTC;
                    }

                    _UOW.SALARYACCOUNTDETAILSRepository.Update(SalaryAccountDetailsDetail);
                    _UOW.Save();

                }
                else
                {
                    var SalaryAccountDetailsDetails = new TBL_EMP_SALARYACCOUNTDETAILS
                    {
                        EMPLOYEE_ID = SalaryAccountDetailsEntities.EMPLOYEE_ID,
                        ACCOUNTNO = SalaryAccountDetailsEntities.ACCOUNTNO,
                        IFSCCODE = SalaryAccountDetailsEntities.IFSCCODE,
                        BRANCH = SalaryAccountDetailsEntities.BRANCH,
                        BANKNAME = SalaryAccountDetailsEntities.BANKNAME
                    };
                    _UOW.SALARYACCOUNTDETAILSRepository.Insert(SalaryAccountDetailsDetails);
                    _UOW.Save();
                }
              
            }
            return Convert.ToInt32(SalaryAccountDetailsEntities.ID);
        }

        public bool UpdateSalaryAccountDetails(int SalaryAccountDetailsId, EmpAcountEntity SalaryAccountDetailsEntities)
        {
            var success = false;
            if (SalaryAccountDetailsEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var SalaryAccountDetailsDetail = _UOW.SALARYACCOUNTDETAILSRepository.GetByID(SalaryAccountDetailsId);
                if (SalaryAccountDetailsDetail != null)
                {
                    if (SalaryAccountDetailsEntities.EMPLOYEE_ID != null)
                    {
                        SalaryAccountDetailsDetail.EMPLOYEE_ID = SalaryAccountDetailsEntities.EMPLOYEE_ID;
                    }
                    if (SalaryAccountDetailsEntities.ACCOUNTNO != "" && SalaryAccountDetailsEntities.ACCOUNTNO != null)
                    {
                        SalaryAccountDetailsDetail.ACCOUNTNO = SalaryAccountDetailsEntities.ACCOUNTNO;
                    }
                    if (SalaryAccountDetailsEntities.IFSCCODE != null && SalaryAccountDetailsEntities.IFSCCODE != "")
                    {
                        SalaryAccountDetailsDetail.IFSCCODE = SalaryAccountDetailsEntities.IFSCCODE;
                    }
                    if (SalaryAccountDetailsEntities.BRANCH != null && SalaryAccountDetailsEntities.BRANCH != "")
                    {
                        SalaryAccountDetailsDetail.BRANCH =SalaryAccountDetailsEntities.BRANCH;
                    }

                    _UOW.SALARYACCOUNTDETAILSRepository.Update(SalaryAccountDetailsDetail);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteSalaryAccountDetails(int SalaryAccountDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
