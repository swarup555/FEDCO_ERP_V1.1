using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IRelationshipdetails
    {
        IEnumerable<RelationshipDetailEntities> GetRelationshipdetailsById(int RelationshipdetailsId);
        IEnumerable<RelationshipDetailEntities> GetAllRelationshipdetails();
        int CreateRelationshipdetails(RelationshipDetailEntities RelationshipdetailsEntities);
        bool UpdateRelationshipdetails(int RelationshipdetailsId, RelationshipDetailEntities RelationshipdetailsEntities);
        bool DeleteRelationshipdetails(int RelationshipdetailsId);
    }
}
