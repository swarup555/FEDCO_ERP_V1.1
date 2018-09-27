using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IState
    {
        IEnumerable<StateEntities> GetStateById(int StateId);
        IEnumerable<StateEntities> GetAllState();
        int CreateState(StateEntities StateEntities);
        bool UpdateState(int StateId, StateEntities StateEntities);
        bool DeleteState(int StateId); 
    }
}
