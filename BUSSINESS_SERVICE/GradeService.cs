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
    public class GradeService:IGrade
    {
        private const string CacheKey = "availablegrd";
        ObjectCache cache = MemoryCache.Default;
         private readonly UOW _UOW;
         public GradeService()
        {
            _UOW = new UOW();
        }


         public IEnumerable<GradeEnities> GetGradeById(int GradeId)
         {
             var data = (from div in _UOW.GRADERepository.GetAll()
                         where div.ID == GradeId
                         select new GradeEnities
                         {
                             ID = div.ID,
                             GRADE_NAME = div.GRADE_NAME
                         }).ToList();
             return data;
         }

         public IEnumerable<GradeEnities> GetAllGrade()
         {
              if (cache.Contains(CacheKey))
                  return (IEnumerable<GradeEnities>)cache.Get(CacheKey);
            else
            {
             var data = (from div in _UOW.GRADERepository.GetAll()
                         select new GradeEnities
                         {
                             ID = div.ID,
                             GRADE_NAME = div.GRADE_NAME
                         }).ToList().OrderBy(x => x.GRADE_NAME);
             CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
             cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
             cache.Add(CacheKey, data, cacheItemPolicy);
             return data;
            }
         }

         public int CreateGrade(GradeEnities GradeEntities)
         {
             if (GradeEntities != null)
             {

                 var GradeDetail = new TBL_HRMS_GRADE_MASTER
                 {
                     GRADE_NAME = GradeEntities.GRADE_NAME,
                 };
                 _UOW.GRADERepository.Insert(GradeDetail);
                 _UOW.Save();
                 cache.Remove(CacheKey);
             }
             return Convert.ToInt32(GradeEntities.ID);
         }

         public bool UpdateGrade(int GradeId, GradeEnities GradeEntities)
         {
             var success = false;
             if (GradeEntities != null)
             {
                 //using (var scope = new TransactionScope())
                 //{
                 var GradeDetail = _UOW.GRADERepository.GetByID(GradeId);
                 if (GradeDetail != null)
                 {

                     if (GradeEntities.GRADE_NAME != null && GradeEntities.GRADE_NAME != "")
                     {
                         GradeDetail.GRADE_NAME = GradeEntities.GRADE_NAME;
                     }

                     _UOW.GRADERepository.Update(GradeDetail);
                     _UOW.Save();
                     cache.Remove(CacheKey);
                     //scope.Complete();
                     success = true;
                     //}
                 }
             }
             return success;
         }

         public bool DeleteGrade(int GradeId)
         {
             var success = false;
             if (GradeId > 0)
             {
                 var GradeDetail = _UOW.GRADERepository.GetByID(GradeId);
                 if (GradeDetail != null)
                 {
                     _UOW.GRADERepository.Delete(GradeDetail);
                     _UOW.Save();
                     cache.Remove(CacheKey);
                     success = true;
                 }
             }
             return success;
         }
    }
}
