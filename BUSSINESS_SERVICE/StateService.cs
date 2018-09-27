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
    public class StateService:IState
    {
         private readonly UOW _UOW;
         public StateService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<StateEntities> GetStateById(int StateId)
        {
            var data = (from sta in _UOW.STATERepository.GetAll()
                        where sta.COUNTRY_ID == StateId
                        select new StateEntities
                        {
                            ID = sta.ID,
                            STATE_NAME = sta.STATE_NAME
                        }).ToList();
            return data;
        }

        public IEnumerable<StateEntities> GetAllState()
        {
            var data = (from sta in _UOW.STATERepository.GetAll()
                        select new StateEntities
                        {
                            ID = sta.ID,
                            STATE_NAME = sta.STATE_NAME
                        }).ToList();
            return data;
        }

        public int CreateState(StateEntities StateEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateState(int StateId, StateEntities StateEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteState(int StateId)
        {
            throw new NotImplementedException();
        }
    }
}
