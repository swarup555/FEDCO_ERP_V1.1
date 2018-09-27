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
    public class ExitTypeService:IExittype
    {
         private readonly UOW _UOW;
        public ExitTypeService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<ExitTypeEntities> GetExittypeById(int ExittypeId)
        {
            var data = (from div in _UOW.EXITTYPERepository.GetAll()
                        where div.ID == ExittypeId
                        select new ExitTypeEntities
                        {
                            ID = div.ID,
                            EXITTYPE_NAME = div.EXITTYPE_NAME
                        }).ToList();
            return data;
        }

        public IEnumerable<ExitTypeEntities> GetAllExittype()
        {
            var data = (from div in _UOW.EXITTYPERepository.GetAll()
                        select new ExitTypeEntities
                        {
                            ID = div.ID,
                            EXITTYPE_NAME = div.EXITTYPE_NAME
                        }).ToList();
            return data;
        }

        public int CreateExittype(ExitTypeEntities ExittypeEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateExittype(int ExittypeId, ExitTypeEntities ExittypeEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteExittype(int ExittypeId)
        {
            throw new NotImplementedException();
        }
    }
}
