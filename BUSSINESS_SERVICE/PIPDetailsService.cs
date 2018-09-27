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
    public class PIPDetailsService:IPIPDetails
    {
        private readonly UOW _UOW;
        public PIPDetailsService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<PIPDeatilsEntities> GetPIPDetailsById(int PIPDeatilId)
        {
            var PIPDeatilsdata = (from emp in _UOW.PIPDETAILSRepository.GetAll()
                                  where emp.EMPLOYEE_ID == PIPDeatilId
                                  select new PIPDeatilsEntities
                                    {
                                        ID = emp.ID,
                                        EMPLOYEE_ID = emp.EMPLOYEE_ID,
                                        PIP_DATE = emp.PIP_DATE,
                                        REASON = emp.REASON,
                                        PERIOD = emp.PERIOD,
                                        PIPCREATEDBY = emp.PIPCREATEDBY,
                                        PIPCLOSEDBY = emp.PIPCLOSEDBY,
                                        PIPCLOSEDDATE = emp.PIPCLOSEDDATE,
                                        REMARKS = emp.REMARKS
                                    }).ToList();
            return PIPDeatilsdata;
        }

        public IEnumerable<PIPDeatilsEntities> GetAllPIPDetails()
        {
            var PIPDeatilsdata = (from emp in _UOW.PIPDETAILSRepository.GetAll()
                                  select new PIPDeatilsEntities
                                  {
                                      ID = emp.ID,
                                      EMPLOYEE_ID = emp.EMPLOYEE_ID,
                                      PIP_DATE = emp.PIP_DATE,
                                      REASON = emp.REASON,
                                      PERIOD = emp.PERIOD,
                                      PIPCREATEDBY = emp.PIPCREATEDBY,
                                      PIPCLOSEDBY = emp.PIPCLOSEDBY,
                                      PIPCLOSEDDATE = emp.PIPCLOSEDDATE,
                                      REMARKS = emp.REMARKS
                                  }).ToList();
            return PIPDeatilsdata;
        }

        public int CreatePIPDetails(PIPDeatilsEntities PIPDetailEntities)
        {
            //DateTime? createddate = null;
            //DateTime? closeddate = null;
            var createddate = (DateTime?)null;
            var closeddate = (DateTime?)null;
            if (PIPDetailEntities.CREATEDATE != null)
            {
                createddate = DateTime.ParseExact(PIPDetailEntities.CREATEDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (PIPDetailEntities.CLOSEDATE != null)
            {
                closeddate = DateTime.ParseExact(PIPDetailEntities.CLOSEDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (PIPDetailEntities != null)
            {

                var PIPDetailDetail = new TBL_EMP_PIPDETAILS
                {
                    EMPLOYEE_ID = PIPDetailEntities.EMPLOYEE_ID,
                    PIP_DATE = createddate,
                    REASON = PIPDetailEntities.REASON,
                    PERIOD = PIPDetailEntities.PERIOD,
                    PIPCREATEDBY = PIPDetailEntities.PIPCREATEDBY,
                    PIPCLOSEDBY = PIPDetailEntities.PIPCLOSEDBY,
                    PIPCLOSEDDATE = closeddate,
                    REMARKS = PIPDetailEntities.REMARKS

                };
                _UOW.PIPDETAILSRepository.Insert(PIPDetailDetail);
                _UOW.Save();
            }

            return Convert.ToInt32(PIPDetailEntities.ID);
        }

        public bool UpdatePIPDetails(int PIPDeatilId, PIPDeatilsEntities PIPDeatilEntities)
        {
            var createddate = (DateTime?)null;
            var closeddate = (DateTime?)null;
            if (PIPDeatilEntities.CREATEDATE != null)
            {
                createddate = DateTime.ParseExact(PIPDeatilEntities.CREATEDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (PIPDeatilEntities.CLOSEDATE != null)
            {
                closeddate = DateTime.ParseExact(PIPDeatilEntities.CLOSEDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            var success = false;
            if (PIPDeatilEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var PIPDeatil = _UOW.PIPDETAILSRepository.GetByID(PIPDeatilId);
                if (PIPDeatil != null)
                {
                    if (PIPDeatilEntities.EMPLOYEE_ID != null)
                    {
                        PIPDeatil.EMPLOYEE_ID = PIPDeatilEntities.EMPLOYEE_ID;
                    }
                    if (PIPDeatilEntities.CREATEDATE != null)
                    {
                        PIPDeatil.PIP_DATE = createddate;
                    }
                    if (PIPDeatilEntities.REASON != "" && PIPDeatilEntities.REASON != null)
                    {
                        PIPDeatil.REASON = PIPDeatilEntities.REASON;
                    }
                    if (PIPDeatilEntities.PERIOD != null)
                    {
                        PIPDeatil.PERIOD = PIPDeatilEntities.PERIOD;
                    }
                    if (PIPDeatilEntities.PIPCREATEDBY != "" && PIPDeatilEntities.PIPCREATEDBY != null)
                    {
                        PIPDeatil.PIPCREATEDBY = PIPDeatilEntities.PIPCREATEDBY;
                    }
                    if (PIPDeatilEntities.PIPCLOSEDBY != "" && PIPDeatilEntities.PIPCLOSEDBY != null)
                    {
                        PIPDeatil.PIPCLOSEDBY = PIPDeatilEntities.PIPCLOSEDBY;
                    }
                    if (PIPDeatilEntities.CLOSEDATE != null)
                    {
                        PIPDeatil.PIPCLOSEDDATE = closeddate;
                    }
                    if (PIPDeatilEntities.REMARKS != "" && PIPDeatilEntities.REMARKS != null)
                    {
                        PIPDeatil.REMARKS = PIPDeatilEntities.REMARKS;
                    }
                    _UOW.PIPDETAILSRepository.Update(PIPDeatil);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeletePIPDetails(int PIPDeatilId)
        {
            throw new NotImplementedException();
        }
    }
}
