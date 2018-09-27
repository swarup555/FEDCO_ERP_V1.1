using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IPIPDetails
    {
        IEnumerable<PIPDeatilsEntities> GetPIPDetailsById(int PIPDeatilId);
        IEnumerable<PIPDeatilsEntities> GetAllPIPDetails();
        int CreatePIPDetails(PIPDeatilsEntities PIPDetailEntities);
        bool UpdatePIPDetails(int PIPDeatilId, PIPDeatilsEntities PIPDeatilEntities);
        bool DeletePIPDetails(int PIPDeatilId);
    }
}
