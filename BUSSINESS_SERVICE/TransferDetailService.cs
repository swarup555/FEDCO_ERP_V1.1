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
    public class TransferDetailService:ITransferDetails
    {
        private readonly UOW _UOW;

        public TransferDetailService()
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
        public string GetReportingpersonname(string id)
        {
            if (id != null && id != "")
            {
                var pername = _UOW.REPORTINGRepository.GetByID(Convert.ToDecimal(id));
                return pername.REPORTING_PERSON_NAME;
            }
            return null;
        }
        public IEnumerable<TransferdetailsEntities> GetTransferDetailsById(int AssetDetailsId)
        {
            var transferdtlsdata = (from tr in _UOW.TRANSFER_DETAILSMASTERRepository.GetAll()
                                     join des in _UOW.DESIGNATIONRepository.GetAll()
                                     on tr.DESIGNATION_ID equals des.ID
                                     join lo in _UOW.LOCATIONMASTERRepository.GetAll()
                                     on tr.WORK_LOCATION equals lo.ID
                                     join dep in _UOW.DEPARTMENTRepository.GetAll()
                                     on tr.DEPARTMENT equals dep.ID
                                     where tr.EMPLOYEE_ID == AssetDetailsId
                                     select new TransferdetailsEntities
                                     {
                                         ID = tr.ID,
                                         EMPLOYEE_ID = tr.EMPLOYEE_ID,
                                         DESIGNATION_ID = tr.DESIGNATION_ID,
                                         WORK_LOCATION = tr.WORK_LOCATION,
                                         DIVISION = tr.DIVISION,
                                         SUB_DIVISION = tr.SUB_DIVISION,
                                         SECTION = tr.SECTION,
                                         DEPARTMENT = tr.DEPARTMENT,
                                         REPORTING_PERSON = tr.REPORTING_PERSON,
                                         FROM_DATE = tr.FROM_DATE,
                                         TO_DATE = tr.TO_DATE,
                                         STATUS = tr.STATUS,
                                         DIVISIONNAME = GetdivisionName(tr.DIVISION),
                                         SUB_DIVISIONNAME=GetsubdivisionName(tr.SUB_DIVISION),
                                         SECTIONNAME=GetSectionnName(tr.SECTION),
                                         DESIGNATIONNAME = des.DESIGNATION_NAME,
                                         DEPARTMENTNAME = dep.DEPARTMENT_NAME,
                                          WorkLocationname=lo.LOCATION_NAME,
                                         //REPORTING_PERSONNAME = GetReportingpersonname(Convert.ToString(tr.REPORTING_PERSON))
                                         REPORTING_PERSONNAME=tr.REPORTINGPERNAME
                                     }
                                     ).ToList().OrderBy(x=>x.ID);
            return transferdtlsdata;
        }

        public IEnumerable<TransferdetailsEntities> GetAllTransferDetails()
        {
            var transferdtlsdata = (from tr in _UOW.TRANSFER_DETAILSMASTERRepository.GetAll()
                                    join des in _UOW.DESIGNATIONRepository.GetAll()
                                    on tr.DESIGNATION_ID equals des.ID
                                    join lo in _UOW.LOCATIONMASTERRepository.GetAll()
                                    on tr.WORK_LOCATION equals lo.ID
                                    join dep in _UOW.DEPARTMENTRepository.GetAll()
                                    on tr.DEPARTMENT equals dep.ID
                                    join re in _UOW.REPORTINGRepository.GetAll()
                                    on tr.REPORTING_PERSON equals re.ID
                                    select new TransferdetailsEntities
                                    {
                                        ID = tr.ID,
                                        EMPLOYEE_ID = tr.EMPLOYEE_ID,
                                        DESIGNATION_ID = tr.DESIGNATION_ID,
                                        WORK_LOCATION = tr.WORK_LOCATION,
                                        DIVISION = tr.DIVISION,
                                        SUB_DIVISION = tr.SUB_DIVISION,
                                        SECTION = tr.SECTION,
                                        DEPARTMENT = tr.DEPARTMENT,
                                        REPORTING_PERSON = tr.REPORTING_PERSON,
                                        FROM_DATE = tr.FROM_DATE,
                                        TO_DATE = tr.TO_DATE,
                                        STATUS=tr.STATUS,
                                        DIVISIONNAME = GetdivisionName(tr.DIVISION),
                                        SUB_DIVISIONNAME = GetsubdivisionName(tr.SUB_DIVISION),
                                        SECTIONNAME = GetSectionnName(tr.SECTION),
                                        DESIGNATIONNAME=des.DESIGNATION_NAME,
                                        DEPARTMENTNAME=dep.DEPARTMENT_NAME,
                                        REPORTING_PERSONNAME=re.REPORTING_PERSON_NAME,
                                        WorkLocationname=lo.LOCATION_NAME
                                    }
                                     ).ToList();
            return transferdtlsdata;
        }

        public int CreateTransferDetails(TransferdetailsEntities TransferDetailEntities)
        {
             //DateTime? startdate = null;
            var startdate = (DateTime?)null; 
             if (TransferDetailEntities.SDATE != null && TransferDetailEntities.SDATE != "")
             {
                 startdate = DateTime.ParseExact(TransferDetailEntities.SDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
             }
            if (TransferDetailEntities != null)
            {
                var trnsferdata = _UOW.TRANSFER_DETAILSMASTERRepository.GetAll().Where(x => x.EMPLOYEE_ID == TransferDetailEntities.EMPLOYEE_ID).Count();
                if (trnsferdata > 0)
                {
                    var trnsdata = _UOW.TRANSFER_DETAILSMASTERRepository.GetAll().Where(x => x.EMPLOYEE_ID == TransferDetailEntities.EMPLOYEE_ID).ToList().OrderBy(y => y.ID).LastOrDefault();
                    if (trnsdata != null)
                    {

                        if (startdate != null)
                        {
                            trnsdata.TO_DATE = startdate.Value.AddDays(-1);
                        }
                        _UOW.TRANSFER_DETAILSMASTERRepository.Update(trnsdata);
                        _UOW.Save();
                    }
                }
                var TransferDetail = new TBL_EMP_TRANSFER_DETAILS
                {
                    EMPLOYEE_ID = TransferDetailEntities.EMPLOYEE_ID,
                    DESIGNATION_ID = TransferDetailEntities.DESIGNATION_ID,
                    WORK_LOCATION = TransferDetailEntities.WORK_LOCATION,
                    DIVISION = TransferDetailEntities.DIVISION,
                    SUB_DIVISION = TransferDetailEntities.SUB_DIVISION,
                    SECTION = TransferDetailEntities.SECTION,
                    DEPARTMENT = TransferDetailEntities.DEPARTMENT,
                    REPORTING_PERSON = TransferDetailEntities.REPORTING_PERSON,
                    FROM_DATE = startdate,
                    STATUS=TransferDetailEntities.STATUS
                    
                };
                _UOW.TRANSFER_DETAILSMASTERRepository.Insert(TransferDetail);
                _UOW.Save();
               
            }

            return Convert.ToInt32(TransferDetailEntities.ID);
        }

        public bool UpdateTransferDetails(int TransferDetailsId, TransferdetailsEntities TransferDetailEntities)
        {
            var success = false;
            if (TransferDetailEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var TransferDetail = _UOW.TRANSFER_DETAILSMASTERRepository.GetByID(TransferDetailsId);
                if (TransferDetail != null)
                {
                    if (TransferDetailEntities.EMPLOYEE_ID != null)
                    {
                        TransferDetail.EMPLOYEE_ID = TransferDetailEntities.EMPLOYEE_ID;
                    }
                    if ( TransferDetailEntities.DESIGNATION_ID != null)
                    {
                        TransferDetail.DESIGNATION_ID = TransferDetailEntities.DESIGNATION_ID;
                    }
                    if ( TransferDetailEntities.WORK_LOCATION != null)
                    {
                        TransferDetail.WORK_LOCATION = TransferDetailEntities.WORK_LOCATION;
                    }
                    if (TransferDetailEntities.DIVISION != null)
                    {
                        TransferDetail.DIVISION = TransferDetailEntities.DIVISION;
                    }
                    if ( TransferDetailEntities.SUB_DIVISION != null)
                    {
                        TransferDetail.SUB_DIVISION = TransferDetailEntities.SUB_DIVISION;
                    }
                    if ( TransferDetailEntities.SECTION != null)
                    {
                        TransferDetail.SECTION = TransferDetailEntities.SECTION;
                    }
                    if (TransferDetailEntities.DEPARTMENT != null)
                    {
                        TransferDetail.DEPARTMENT = TransferDetailEntities.DEPARTMENT;
                    }
                    if (TransferDetailEntities.REPORTING_PERSON != null)
                    {
                        TransferDetail.REPORTING_PERSON = TransferDetailEntities.REPORTING_PERSON;
                    }
                    if (TransferDetailEntities.FROM_DATE != null)
                    {
                        TransferDetail.FROM_DATE = TransferDetailEntities.FROM_DATE;
                    }
                    if (TransferDetailEntities.TO_DATE != null)
                    {
                        TransferDetail.TO_DATE = TransferDetailEntities.TO_DATE;
                    }
                    if (TransferDetailEntities.STATUS != null && TransferDetailEntities.STATUS != "")
                    {
                        TransferDetail.STATUS = TransferDetailEntities.STATUS;
                    }
                    _UOW.TRANSFER_DETAILSMASTERRepository.Update(TransferDetail);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteTransferDetails(int TransferDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
