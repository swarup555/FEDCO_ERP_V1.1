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
    public class SubDivisionService:ISubdivision
    {
         private readonly UOW _UOW;
         public SubDivisionService()
        {
            _UOW = new UOW();
        }
         public IEnumerable<SubDivisionEntities> GetSubDivisionById(string SubDivisionId)
        {
            var data = (from div in _UOW.SUBDIVISIONRepository.GetAll()
                        where div.DIVISION_CODE == SubDivisionId
                        select new SubDivisionEntities
                        {
                            DIVISION_CODE = div.DIVISION_CODE,
                            SUB_DIV_CODE = div.SUB_DIV_CODE,
                            SUB_DIV_NAME = div.SUB_DIV_NAME
                        }).ToList();
            return data;
        }

        public IEnumerable<SubDivisionEntities> GetAllSubDivision()
        {
            var data = (from div in _UOW.SUBDIVISIONRepository.GetAll()
                        select new SubDivisionEntities
                        {
                            DIVISION_CODE = div.DIVISION_CODE,
                            SUB_DIV_CODE = div.SUB_DIV_CODE,
                            SUB_DIV_NAME=div.SUB_DIV_NAME
                        }).ToList();
            return data;
        }

        public int CreateSubDivision(SubDivisionEntities SubDivisionEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSubDivision(int SubDivisionId, SubDivisionEntities SubDivisionEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSubDivision(int SubDivisionId)
        {
            throw new NotImplementedException();
        }
    }
}
