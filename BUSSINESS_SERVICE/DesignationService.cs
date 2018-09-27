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

    public class DesignationService:IDesignation
    {
        private const string CacheKey = "availabledes";
        ObjectCache cache = MemoryCache.Default;
         private readonly UOW _UOW;
         public DesignationService()
        {
            _UOW = new UOW();
        }


         public IEnumerable<DesignationEntities> GetDesignationById(int DesignationId)
         {
             //if (cache.Contains(CacheKey))
             //    return (IEnumerable<DesignationEntities>)cache.Get(CacheKey);
             //else
             //{
                 var data = (from div in _UOW.DESIGNATIONRepository.GetAll()
                             where div.ID == DesignationId
                             select new DesignationEntities
                             {
                                 ID = div.ID,
                                 DESIGNATION_NAME = div.DESIGNATION_NAME
                             }).ToList();
                 //CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                 //cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                 //cache.Add(CacheKey, data, cacheItemPolicy);
                 return data;
             //}
         }

         public IEnumerable<DesignationEntities> GetAllDesignation()
         {
              if (cache.Contains(CacheKey))
                 return (IEnumerable<DesignationEntities>)cache.Get(CacheKey);
             else
             {
             var data = (from div in _UOW.DESIGNATIONRepository.GetAll()
                         select new DesignationEntities
                         {
                             ID = div.ID,
                             DESIGNATION_NAME = div.DESIGNATION_NAME
                         }).ToList().OrderBy(x=>x.DESIGNATION_NAME);
             CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
             cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
             cache.Add(CacheKey, data, cacheItemPolicy);
             return data;
             }
         }

         public int CreateDesignation(DesignationEntities DesignationEntities)
         {
             if (DesignationEntities != null)
             {

                 var DesignationDetail = new TBL_HRMS_DESIGNATIONMASTER
                 {
                     DESIGNATION_NAME = DesignationEntities.DESIGNATION_NAME,
                 };
                 _UOW.DESIGNATIONRepository.Insert(DesignationDetail);
                 _UOW.Save();
                 cache.Remove(CacheKey);
             }
             return Convert.ToInt32(DesignationEntities.ID);
         }

         public bool UpdateDesignationt(int DesignationId, DesignationEntities DesignationEntities)
         {
             var success = false;
             if (DesignationEntities != null)
             {
                 //using (var scope = new TransactionScope())
                 //{
                 var DesignationDetail = _UOW.DESIGNATIONRepository.GetByID(DesignationId);
                 if (DesignationDetail != null)
                 {

                     if (DesignationEntities.DESIGNATION_NAME != null && DesignationEntities.DESIGNATION_NAME != "")
                     {
                         DesignationDetail.DESIGNATION_NAME = DesignationEntities.DESIGNATION_NAME;
                     }

                     _UOW.DESIGNATIONRepository.Update(DesignationDetail);
                     _UOW.Save();
                     cache.Remove(CacheKey);
                     //scope.Complete();
                     success = true;
                     //}
                 }
             }
             return success;
         }

         public bool DeleteDesignation(int DesignationId)
         {
             var success = false;
             if (DesignationId > 0)
             {
                 var DesignationDetail = _UOW.DESIGNATIONRepository.GetByID(DesignationId);
                 if (DesignationDetail != null)
                     {

                         _UOW.DESIGNATIONRepository.Delete(DesignationDetail);
                         _UOW.Save();
                         cache.Remove(CacheKey);
                         success = true;
                     }
             }
             return success;
         }
    }
}
