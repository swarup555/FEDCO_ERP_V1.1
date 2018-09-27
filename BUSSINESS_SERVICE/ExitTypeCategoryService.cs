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
    public class ExitTypeCategoryService:IExittypeCategory
    {
        private readonly UOW _UOW;
        public ExitTypeCategoryService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<ExitcatagoryEntities> GetExittypeCategoryById(int ExittypeCategoryId)
        {
            var ExittypeCategorydtls = (from sal in _UOW.EXITSUBCATAGORYRepository.GetAll()
                                 where sal.EXITTYPEID == ExittypeCategoryId
                                        select new ExitcatagoryEntities
                                 {
                                     ID = sal.ID,
                                     SUBCATAGORYNAME=sal.SUBCATAGORYNAME
                                 }).ToList();
            return ExittypeCategorydtls;
        }

        public IEnumerable<ExitcatagoryEntities> GetAllExittypeCategory()
        {
            throw new NotImplementedException();
        }

        public int CreateExittypeCategory(ExitcatagoryEntities ExittypeCategoryEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateExittypeCategory(int ExittypeCategoryId, ExitcatagoryEntities ExittypeCategoryEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteExittypeCategory(int ExittypeCategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
