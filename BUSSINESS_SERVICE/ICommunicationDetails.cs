using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface ICommunicationDetails
    {
        IEnumerable<CommunicationDetailsEntities> GetCommunicationDetailsById(int CommunicationDetailsId);
        IEnumerable<CommunicationDetailsEntities> GetAllCommunicationDetails();
        int CreateCommunicationDetails(CommunicationDetailsEntities CommunicationDetailsEntities);
        bool UpdateCommunicationDetails(int CommunicationDetailsId, CommunicationDetailsEntities CommunicationDetailsEntities);
        bool DeleteCommunicationDetails(int CommunicationDetailsId);
    }
}
