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
    public class AssetTypeService:IAssetType
    {
        private readonly UOW _UOW;
        public AssetTypeService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<BUSSINESS_ENTITIES.AssetTypeEntities> GetAssetTypeById(int AssetDetailsId)
        {
            var data = (from con in _UOW.ASSETTYPE_MASTERRepository.GetAll()
                        where con.ID == AssetDetailsId
                        select new AssetTypeEntities
                        {
                            ID = con.ID,
                            ASSETTYPE_NAME = con.ASSETTYPE_NAME
                          
                        }).ToList();
            return data;
        }

        public IEnumerable<BUSSINESS_ENTITIES.AssetTypeEntities> GetAllAssetTypeDetails()
        {
            var data = (from con in _UOW.ASSETTYPE_MASTERRepository.GetAll()
                        select new AssetTypeEntities
                        {
                            ID = con.ID,
                            ASSETTYPE_NAME = con.ASSETTYPE_NAME

                        }).ToList();
            return data;
        }

        public int CreateAssetType(BUSSINESS_ENTITIES.AssetTypeEntities AssetDetailEntities)
        {
            if (AssetDetailEntities != null)
            {

                var ASSETDetail = new TBL_HRMS_ASSETTYPE_MASTER
                {
                    ASSETTYPE_NAME = AssetDetailEntities.ASSETTYPE_NAME,
                   
                };
                _UOW.ASSETTYPE_MASTERRepository.Insert(ASSETDetail);
                _UOW.Save();

            }
            return Convert.ToInt32(AssetDetailEntities.ID);
        }

        public bool UpdateAssetType(int AssetDetailsId, BUSSINESS_ENTITIES.AssetTypeEntities AssetDetailEntities)
        {
             var success = false;
             if (AssetDetailEntities != null)
             {
                 //using (var scope = new TransactionScope())
                 //{
                 var ASSETDetail = _UOW.ASSETTYPE_MASTERRepository.GetByID(AssetDetailsId);
                 if (ASSETDetail != null)
                 {

                     if (AssetDetailEntities.ASSETTYPE_NAME != null && AssetDetailEntities.ASSETTYPE_NAME != "")
                     {
                         ASSETDetail.ASSETTYPE_NAME = AssetDetailEntities.ASSETTYPE_NAME;
                     }

                     _UOW.ASSETTYPE_MASTERRepository.Update(ASSETDetail);
                     _UOW.Save();
                     //scope.Complete();
                     success = true;
                 }
             }
             return success;
        }

        public bool DeleteAssetType(int AssetDetailsId)
        {
            var success = false;
            if (AssetDetailsId > 0)
            {
                var ASSETDetail = _UOW.ASSETTYPE_MASTERRepository.GetByID(AssetDetailsId);
                if (ASSETDetail != null)
                {
                    _UOW.ASSETTYPE_MASTERRepository.Delete(ASSETDetail);
                    _UOW.Save();

                    success = true;
                }
            }
            return success;
        }
    }
}
