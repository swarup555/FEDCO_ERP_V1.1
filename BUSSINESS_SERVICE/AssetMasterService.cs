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
    public class AssetMasterService:IAssetmaster
    {
        private readonly UOW _UOW;
        public AssetMasterService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<BUSSINESS_ENTITIES.AssetmasterEntities> GetAssetDetailsById(int AssetDetailsId)
        {
            var data = (from con in _UOW.ASSET_MASTERRepository.GetAll()
                        where con.ID == AssetDetailsId
                        select new AssetmasterEntities
                        {
                            ID = con.ID,
                            ASSETTYPE_ID = con.ASSETTYPE_ID,
                            ASSET_NAME = con.ASSET_NAME,
                            ASSETCODE=con.ASSETCODE
                        }).ToList();
            return data;
        }

        public IEnumerable<BUSSINESS_ENTITIES.AssetmasterEntities> GetAllAssetDetails()
        {
            var data = (from con in _UOW.ASSET_MASTERRepository.GetAll()
                        join b in _UOW.ASSETTYPE_MASTERRepository.GetAll()
                        on con.ASSETTYPE_ID equals b.ID
                        select new AssetmasterEntities
                        {
                            ID = con.ID,
                            ASSETTypeName=b.ASSETTYPE_NAME,
                            ASSETTYPE_ID=con.ASSETTYPE_ID,
                            ASSET_NAME = con.ASSET_NAME,
                            ASSETCODE = con.ASSETCODE
                        }).ToList();
            return data;
        }

        public int CreateAssetDetails(BUSSINESS_ENTITIES.AssetmasterEntities AssetDetailEntities)
        {
            if (AssetDetailEntities != null)
            {

                var ASSETDetail = new TBL_HRMS_ASSET_MASTER
                {
                    ASSETTYPE_ID = AssetDetailEntities.ASSETTYPE_ID,
                    ASSET_NAME = AssetDetailEntities.ASSET_NAME,
                    ASSETCODE = AssetDetailEntities.ASSETCODE,
                };
                _UOW.ASSET_MASTERRepository.Insert(ASSETDetail);
                _UOW.Save();
              
            }
            return Convert.ToInt32(AssetDetailEntities.ID);
        }

        public bool UpdateAssetDetails(int AssetDetailsId, BUSSINESS_ENTITIES.AssetmasterEntities AssetDetailEntities)
        {
            var success = false;
            if (AssetDetailEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var ASSETDetail = _UOW.ASSET_MASTERRepository.GetByID(AssetDetailsId);
                if (ASSETDetail != null)
                {
                    if (AssetDetailEntities.ASSETTYPE_ID != null )
                    {
                        ASSETDetail.ASSETTYPE_ID = AssetDetailEntities.ASSETTYPE_ID;
                    }
                    if (AssetDetailEntities.ASSET_NAME != null && AssetDetailEntities.ASSET_NAME != "")
                    {
                        ASSETDetail.ASSET_NAME = AssetDetailEntities.ASSET_NAME;
                    }
                    if (AssetDetailEntities.ASSETCODE != null && AssetDetailEntities.ASSETCODE != "")
                    {
                        ASSETDetail.ASSETCODE = AssetDetailEntities.ASSETCODE;
                    }
                    _UOW.ASSET_MASTERRepository.Update(ASSETDetail);
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
            var success = false;
            if (AssetDetailsId > 0)
            {
                var ASSETDetail = _UOW.ASSET_MASTERRepository.GetByID(AssetDetailsId);
                if (ASSETDetail != null)
                {
                    _UOW.ASSET_MASTERRepository.Delete(ASSETDetail);
                    _UOW.Save();
                   
                    success = true;
                }
            }
            return success;
        }
    }
}
