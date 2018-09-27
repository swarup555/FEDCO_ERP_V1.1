using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface Iemppublicationdetails
    {
        IEnumerable<EmployeePublicationEntities> GetpublicationdetailsById(int publicationdetailsId);
        IEnumerable<EmployeePublicationEntities> GetAllpublicationdetailsDetails();
        int CreatepublicationdetailsDetails(EmployeePublicationEntities publicationdetailsEntities);
        bool UpdatepublicationdetailsDetails(int publicationdetailsId, EmployeePublicationEntities publicationdetailsEntities);
        bool DeletepublicationdetailsDetails(int publicationdetailsId); 
    }
}
