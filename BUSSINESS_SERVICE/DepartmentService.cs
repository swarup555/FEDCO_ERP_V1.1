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
    public class DepartmentService:IDepartment
    {
        private const string CacheKey = "availabledep";
        ObjectCache cache = MemoryCache.Default;
        private readonly UOW _UOW;
        public DepartmentService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<DepartmentEntities> GetDepartmentById(int DepartmentId)
        {
            //if (cache.Contains(CacheKey))
            //    return (IEnumerable<DepartmentEntities>)cache.Get(CacheKey);
            //else
            //{
                var data = (from div in _UOW.DEPARTMENTRepository.GetAll()
                            where div.ID == DepartmentId
                            select new DepartmentEntities
                            {
                                ID = div.ID,
                                DEPARTMENT_NAME = div.DEPARTMENT_NAME
                            }).ToList();
                //CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                //cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                //cache.Add(CacheKey, data, cacheItemPolicy);
                return data;
            //}
        }

        public IEnumerable<DepartmentEntities> GetAllDepartment()
        {
            if (cache.Contains(CacheKey))
                return (IEnumerable<DepartmentEntities>)cache.Get(CacheKey);
            else
            {
            var data = (from div in _UOW.DEPARTMENTRepository.GetAll()
                        select new DepartmentEntities
                        {
                            ID = div.ID,
                            DEPARTMENT_NAME = div.DEPARTMENT_NAME
                        }).ToList().OrderBy(x => x.DEPARTMENT_NAME);
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
            cache.Add(CacheKey, data, cacheItemPolicy);
            return data;
            }
        }

        public int CreateDepartment(DepartmentEntities DepartmentEntities)
        {
            if (DepartmentEntities != null)
            {

                var DepartmentDetail = new TBL_HRMS_DEPARTMENTMASTER
                {
                    DEPARTMENT_NAME = DepartmentEntities.DEPARTMENT_NAME,
                };
                _UOW.DEPARTMENTRepository.Insert(DepartmentDetail);
                _UOW.Save();
                cache.Remove(CacheKey);
            }
            return Convert.ToInt32(DepartmentEntities.ID);
        }

        public bool UpdateDepartment(int DepartmentId, DepartmentEntities DepartmentEntities)
        {
            var success = false;
            if (DepartmentEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var DepartmentDetail = _UOW.DEPARTMENTRepository.GetByID(DepartmentId);
                if (DepartmentDetail != null)
                {

                    if (DepartmentEntities.DEPARTMENT_NAME != null && DepartmentEntities.DEPARTMENT_NAME != "")
                    {
                        DepartmentDetail.DEPARTMENT_NAME = DepartmentEntities.DEPARTMENT_NAME;
                    }

                    _UOW.DEPARTMENTRepository.Update(DepartmentDetail);
                    _UOW.Save();
                    cache.Remove(CacheKey);
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteDepartment(int DepartmentId)
        {
            var success = false;
            if (DepartmentId > 0)
            {
                var DepartmentDetail = _UOW.DEPARTMENTRepository.GetByID(DepartmentId);
                if (DepartmentDetail != null)
                {
                    _UOW.DEPARTMENTRepository.Delete(DepartmentDetail);
                    _UOW.Save();
                    cache.Remove(CacheKey);
                    success = true;
                }
            }
            return success;
        }
    }
}
