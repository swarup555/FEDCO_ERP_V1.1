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
    public class AssetDetailService:IAssetDetails
    {
        private readonly UOW _UOW;
        public AssetDetailService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<AssetDetailsEntities> GetAssetDetailsById(int AssetDetailsId)
        {
            var AssetDetailsdata = (from emp in _UOW.EMP_ASSETDETAILSRepository.GetAll()
                                    join ast in  _UOW.ASSET_MASTERRepository.GetAll()
                                    on emp.ASSET_CODE equals Convert.ToString(ast.ID)
                                    where emp.EMPLOYEE_ID == AssetDetailsId
                                      select new AssetDetailsEntities
                                      {
                                          ID = emp.ID,
                                          EMPLOYEE_ID = emp.EMPLOYEE_ID,
                                          ASSET_NAME = ast.ASSET_NAME,
                                          ASSET_CODE = ast.ASSETCODE,
                                          ISSUED_DATE = emp.ISSUED_DATE,
                                          RETURNED_DATE = emp.RETURNED_DATE,
                                          ISSUEDBY = emp.ISSUEDBY,
                                          RETURNEDTO = emp.RETURNEDTO,
                                          ASSET_STATUS = emp.ASSET_STATUS
                                      }).ToList();
            return AssetDetailsdata;
        }

        public IEnumerable<AssetDetailsEntities> GetAllAssetDetails()
        {
            var AssetDetailsdata = (from emp in _UOW.EMP_ASSETDETAILSRepository.GetAll()
                                    select new AssetDetailsEntities
                                    {
                                        ID = emp.ID,
                                        EMPLOYEE_ID = emp.EMPLOYEE_ID,
                                        ASSET_NAME = emp.ASSET_NAME,
                                        ASSET_CODE = emp.ASSET_CODE,
                                        ISSUED_DATE = emp.ISSUED_DATE,
                                        RETURNED_DATE = emp.RETURNED_DATE,
                                        ISSUEDBY = emp.ISSUEDBY,
                                        RETURNEDTO = emp.RETURNEDTO,
                                        ASSET_STATUS = emp.ASSET_STATUS
                                    }).ToList();
            return AssetDetailsdata;
        }

        public int CreateAssetDetails(AssetDetailsEntities AssetDetailEntities)
        {
            //DateTime? issuedate = null;
            //DateTime? returndate = null;
            var issuedate = (DateTime?)null;
            var returndate = (DateTime?)null;
            if (AssetDetailEntities.ISSUEDDATE != null)
            {
                issuedate = DateTime.ParseExact(AssetDetailEntities.ISSUEDDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (AssetDetailEntities.RETURNEDDATE != null)
            {
                returndate = DateTime.ParseExact(AssetDetailEntities.RETURNEDDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (AssetDetailEntities != null)
            {

                var AssetDetails = new TBL_EMP_ASSETDETAILS
                {
                    EMPLOYEE_ID = AssetDetailEntities.EMPLOYEE_ID,
                    ASSET_NAME = AssetDetailEntities.ASSET_NAME,
                    ASSET_CODE = AssetDetailEntities.ASSET_CODE,
                    ISSUED_DATE = issuedate,
                    RETURNED_DATE = returndate,
                    ISSUEDBY = AssetDetailEntities.ISSUEDBY,
                    RETURNEDTO = AssetDetailEntities.RETURNEDTO,
                    ASSET_STATUS = AssetDetailEntities.ASSET_STATUS

                };
                _UOW.EMP_ASSETDETAILSRepository.Insert(AssetDetails);
                _UOW.Save();
            }

            return Convert.ToInt32(AssetDetailEntities.ID);
        }

        public bool UpdateAssetDetails(int AssetDetailsId, AssetDetailsEntities AssetDetailEntities)
        {
            var issuedate = (DateTime?)null;
            var returndate = (DateTime?)null;
            if (AssetDetailEntities.ISSUEDDATE != null)
            {
                issuedate = DateTime.ParseExact(AssetDetailEntities.ISSUEDDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (AssetDetailEntities.RETURNEDDATE != null)
            {
                returndate = DateTime.ParseExact(AssetDetailEntities.RETURNEDDATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            var success = false;
            if (AssetDetailEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var AssetDetails = _UOW.EMP_ASSETDETAILSRepository.GetByID(AssetDetailsId);
                if (AssetDetails != null)
                {
                    if (AssetDetailEntities.EMPLOYEE_ID != null)
                    {
                        AssetDetails.EMPLOYEE_ID = AssetDetailEntities.EMPLOYEE_ID;
                    }

                    if (AssetDetailEntities.ASSET_NAME != "" && AssetDetailEntities.ASSET_NAME != null)
                    {
                        AssetDetails.ASSET_NAME = AssetDetailEntities.ASSET_NAME;
                    }
                    if (AssetDetailEntities.ASSET_CODE != "" && AssetDetailEntities.ASSET_CODE != null)
                    {
                        AssetDetails.ASSET_CODE = AssetDetailEntities.ASSET_CODE;
                    }
                    if (AssetDetailEntities.ISSUEDDATE != null)
                    {
                        AssetDetails.ISSUED_DATE = issuedate;
                    }
                    if (AssetDetailEntities.RETURNEDDATE != null)
                    {
                        AssetDetails.RETURNED_DATE = returndate;
                    }
                    if (AssetDetailEntities.ISSUEDBY != "" && AssetDetailEntities.ISSUEDBY != null)
                    {
                        AssetDetails.ISSUEDBY = AssetDetailEntities.ISSUEDBY;
                    }
                    if (AssetDetailEntities.RETURNEDTO != "" && AssetDetailEntities.RETURNEDTO != null)
                    {
                        AssetDetails.RETURNEDTO = AssetDetailEntities.RETURNEDTO;
                    }

                    if (AssetDetailEntities.ASSET_STATUS != "" && AssetDetailEntities.ASSET_STATUS != null)
                    {
                        AssetDetails.ASSET_STATUS = AssetDetailEntities.ASSET_STATUS;
                    }
                    _UOW.EMP_ASSETDETAILSRepository.Update(AssetDetails);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteAssetDetails(int AssetDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
