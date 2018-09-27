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
    public class DegreTypeService:IDegreeType
    {
         private readonly UOW _UOW;
         public DegreTypeService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<BUSSINESS_ENTITIES.DegreeTypeEntities> GetDegreeTypeById(int DegreeTypeId)
        {
            var data = (from de in _UOW.DEGREETYPERepository.GetAll()
                        where de.ID == DegreeTypeId
                        select new DegreeTypeEntities
                        {
                            ID = de.ID,
                            DEGREETYPE_NAME = de.DEGREETYPE_NAME
                        }).ToList();
            return data;
        }

        public IEnumerable<BUSSINESS_ENTITIES.DegreeTypeEntities> GetAllDegreeType()
        {
            var data = (from de in _UOW.DEGREETYPERepository.GetAll()
                        select new DegreeTypeEntities
                        {
                            ID = de.ID,
                            DEGREETYPE_NAME = de.DEGREETYPE_NAME
                        }).ToList();
            return data;
        }

        public int CreateDegreeType(BUSSINESS_ENTITIES.DegreeTypeEntities DegreeTypeEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDegreeType(int DegreeTypeId, BUSSINESS_ENTITIES.DegreeTypeEntities DegreeTypeEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDegreeType(int DegreeTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
