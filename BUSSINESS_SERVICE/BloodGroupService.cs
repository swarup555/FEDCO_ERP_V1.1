using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Transactions;
using System.Runtime.Caching;

namespace BUSSINESS_SERVICE
{
  public  class BloodGroupService:IBloodGroup
    {
        private const string CacheKey = "availablebld";
        ObjectCache cache = MemoryCache.Default;
       private readonly UOW _UOW;
       public BloodGroupService()
        {
            _UOW = new UOW();
        }

        public IEnumerable<BUSSINESS_ENTITIES.BloodGroupEntities> GetBloodGroupById(int BasicinfoId)
        {
            if (cache.Contains(CacheKey))
                return (IEnumerable<BloodGroupEntities>)cache.Get(CacheKey);
            else
            {
                var data = (from div in _UOW.BLOODGROUPRepository.GetAll()
                            where div.ID == BasicinfoId
                            select new BUSSINESS_ENTITIES.BloodGroupEntities
                            {
                                ID = div.ID,
                                BLOODGROUP_NAME = div.BLOODGROUP_NAME
                            }).ToList();
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(CacheKey, data, cacheItemPolicy);
                return data;
            }
        }

        public IEnumerable<BUSSINESS_ENTITIES.BloodGroupEntities> GetAllBloodGroup()
        {
             if (cache.Contains(CacheKey))
                 return (IEnumerable<BloodGroupEntities>)cache.Get(CacheKey);
            else
            {
            var data = (from div in _UOW.BLOODGROUPRepository.GetAll()
                        select new BUSSINESS_ENTITIES.BloodGroupEntities
                        {
                            ID = div.ID,
                            BLOODGROUP_NAME = div.BLOODGROUP_NAME
                        }).ToList();
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
            cache.Add(CacheKey, data, cacheItemPolicy);
            return data;
            }
        }

        public int CreateBloodGroup(BUSSINESS_ENTITIES.BloodGroupEntities BloodGroupEntities)
        {
            if (BloodGroupEntities != null)
            {

                var BLOODGROUPDetail = new TBL_HRMS_BLOODGROUP_MASTER
                {
                    BLOODGROUP_NAME = BloodGroupEntities.BLOODGROUP_NAME,
                };
                _UOW.BLOODGROUPRepository.Insert(BLOODGROUPDetail);
                _UOW.Save();
                cache.Remove(CacheKey);
            }
            return Convert.ToInt32(BloodGroupEntities.ID);
        }

        public bool UpdateBloodGroup(int BasicinfoId, BUSSINESS_ENTITIES.BloodGroupEntities BloodGroupEntities)
        {
            var success = false;
            if (BloodGroupEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var BLOODGROUPDetail = _UOW.BLOODGROUPRepository.GetByID(BasicinfoId);
                if (BLOODGROUPDetail != null)
                {

                    if (BloodGroupEntities.BLOODGROUP_NAME != null && BloodGroupEntities.BLOODGROUP_NAME != "")
                    {
                        BLOODGROUPDetail.BLOODGROUP_NAME = BloodGroupEntities.BLOODGROUP_NAME;
                    }

                    _UOW.BLOODGROUPRepository.Update(BLOODGROUPDetail);
                    _UOW.Save();
                    cache.Remove(CacheKey);
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteEmployeebasicinfo(int BasicinfoId)
        {
            var success = false;
            if (BasicinfoId > 0)
            {
                var BLOODGROUPDetail = _UOW.BLOODGROUPRepository.GetByID(BasicinfoId);
                if (BLOODGROUPDetail != null)
                {
                    _UOW.BLOODGROUPRepository.Delete(BLOODGROUPDetail);
                    _UOW.Save();
                    cache.Remove(CacheKey);
                    success = true;
                }
            }
            return success;
        }
    }
}
