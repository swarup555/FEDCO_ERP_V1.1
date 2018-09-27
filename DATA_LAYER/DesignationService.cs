using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;



namespace DATA_LAYER
{
    public class DesignationService:IDesignation
    {
         private readonly UOW _UOW;
         public DesignationService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<DesignationEntities> GetDesignationById(int DesignationId)
        {
            var data = (from div in _UOW.DESIGNATIONRepository.GetAll()
                        where div.ID == DesignationId
                        select new DesignationEntities
                        {

                            ID = div.ID,
                            DESIGNATION_NAME = div.DESIGNATION_NAME
                           
                        }).ToList();
            return data;
        }

        public IEnumerable<DesignationEntities> GetAllDesignation()
        {
            var data = (from div in _UOW.DESIGNATIONRepository.GetAll()
                        select new DesignationEntities
                        {

                            ID = div.ID,
                            DESIGNATION_NAME = div.DESIGNATION_NAME

                        }).ToList();
            return data;
        }

        public int CreateDesignation(DesignationEntities DesignationEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDesignation(int DesignationId, DesignationEntities DesignationEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDesignation(int DesignationId)
        {
            throw new NotImplementedException();
        }
    }
}
