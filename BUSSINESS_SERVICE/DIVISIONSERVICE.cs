using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE 
{
    public class DIVISIONSERVICE:Idivision
    {
         private readonly UOW _UOW;

         public DIVISIONSERVICE()
        {
            _UOW = new UOW();
        }
        public IEnumerable<DIVISION> GetDIVISIONById(int DIVISIONId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DIVISION> GetAllDIVISION()
        {
            var data = (from div in _UOW.DIVISIONRepository.GetAll()
                        select new DIVISION
                        {
                            DIVISION_CODE=div.DIVISION_CODE,
                            DIV_NAME=div.DIV_NAME
                        }).ToList();
            return data;
        }

        public int CreateDIVISION(DIVISION DIVISIONEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDIVISION(int DIVISIONId, DIVISION DIVISIONEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDIVISION(int DIVISIONId)
        {
            throw new NotImplementedException();
        }
    }
}
