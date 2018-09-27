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
    public class SectionService:ISection
    {
         private readonly UOW _UOW;
         public SectionService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<SectionEntities> GetSectionById(string SectionId)
        {
            var data = (from div in _UOW.SECTIONORepository.GetAll()
                        where div.SUB_DIV_CODE == SectionId
                        select new SectionEntities
                        {
                            
                            SUB_DIV_CODE = div.SUB_DIV_CODE,
                            SEC_CODE = div.SEC_CODE,
                            SEC_NAME=div.SEC_NAME
                        }).ToList();
            return data;
        }

        public IEnumerable<SectionEntities> GetAllSection()
        {
            var data = (from div in _UOW.SECTIONORepository.GetAll()
                        select new SectionEntities
                        {

                            SUB_DIV_CODE = div.SUB_DIV_CODE,
                            SEC_CODE = div.SEC_CODE,
                            SEC_NAME = div.SEC_NAME
                        }).ToList();
            return data;
        }

        public int CreateSection(SectionEntities SectionEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSection(int SectionId, SectionEntities SectionEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSection(int SectionId)
        {
            throw new NotImplementedException();
        }
    }
}
