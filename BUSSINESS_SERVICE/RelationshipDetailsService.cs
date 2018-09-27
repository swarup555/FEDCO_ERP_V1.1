using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Transactions;
using System.Globalization;

namespace BUSSINESS_SERVICE
{
    public class RelationshipDetailsService:IRelationshipdetails
    {
        private readonly UOW _UOW;
        public RelationshipDetailsService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<RelationshipDetailEntities> GetRelationshipdetailsById(int RelationshipdetailsId)
        {
            var Relationshipdata = (from emp in _UOW.RELATIONSHIP_DETAILSRepository.GetAll()
                                    where emp.EMPLOYEE_ID == RelationshipdetailsId
                                    select new RelationshipDetailEntities
                                  {
                                      ID=emp.ID,
                                      EMPLOYEE_ID = emp.EMPLOYEE_ID,
                                      RELATIONSHIP = emp.RELATIONSHIP,
                                      RELATIVE_NAME = emp.RELATIVE_NAME,
                                      DATE_OF_BIRTH = emp.DATE_OF_BIRTH,
                                      OCCUPATION = emp.OCCUPATION,
                                      DEPENDENT = emp.DEPENDENT
                                     
                                  }).ToList();
            return Relationshipdata;
        }

        public IEnumerable<RelationshipDetailEntities> GetAllRelationshipdetails()
        {
            var Relationshipdata = (from emp in _UOW.RELATIONSHIP_DETAILSRepository.GetAll()
                                    select new RelationshipDetailEntities
                                    {
                                        ID = emp.ID,
                                        EMPLOYEE_ID = emp.EMPLOYEE_ID,
                                        RELATIONSHIP = emp.RELATIONSHIP,
                                        RELATIVE_NAME = emp.RELATIVE_NAME,
                                        DATE_OF_BIRTH = emp.DATE_OF_BIRTH,
                                        OCCUPATION = emp.OCCUPATION,
                                        DEPENDENT = emp.DEPENDENT

                                    }).ToList();
            return Relationshipdata;
        }

        public int CreateRelationshipdetails(RelationshipDetailEntities RelationshipdetailsEntities)
        {
            var dob = (DateTime?)null;
            if (RelationshipdetailsEntities.DATEOFBIRTH != null)
            {
                dob = DateTime.ParseExact(RelationshipdetailsEntities.DATEOFBIRTH, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (RelationshipdetailsEntities != null)
            {

                var RelationshipDetail = new TBL_EMP_RELATIONSHIP_DETAILS
                {
                    EMPLOYEE_ID = RelationshipdetailsEntities.EMPLOYEE_ID,
                    RELATIONSHIP = RelationshipdetailsEntities.RELATIONSHIP,
                    RELATIVE_NAME = RelationshipdetailsEntities.RELATIVE_NAME,
                    DATE_OF_BIRTH = dob,
                    OCCUPATION = RelationshipdetailsEntities.OCCUPATION,
                    DEPENDENT = RelationshipdetailsEntities.DEPENDENT
                    
                };
                _UOW.RELATIONSHIP_DETAILSRepository.Insert(RelationshipDetail);
                _UOW.Save();
            }

            return Convert.ToInt32(RelationshipdetailsEntities.ID);
        }

        public bool UpdateRelationshipdetails(int RelationshipdetailsId, RelationshipDetailEntities RelationshipdetailsEntities)
        {
            var success = false;
            //DateTime? dob = null;
            var dob = (DateTime?)null; 
            if (RelationshipdetailsEntities.DATEOFBIRTH != null)
            {
                dob = DateTime.ParseExact(RelationshipdetailsEntities.DATEOFBIRTH, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (RelationshipdetailsEntities != null)
            {
                //using (var scope = new TransactionScope())
                //{
                var RelationshipdetailDetail = _UOW.RELATIONSHIP_DETAILSRepository.GetByID(RelationshipdetailsId);
                if (RelationshipdetailDetail != null)
                {
                    if (RelationshipdetailsEntities.EMPLOYEE_ID != null)
                    {
                        RelationshipdetailDetail.EMPLOYEE_ID = RelationshipdetailsEntities.EMPLOYEE_ID;
                    }
                    if (RelationshipdetailsEntities.RELATIONSHIP != "" && RelationshipdetailsEntities.RELATIONSHIP != null)
                    {
                        RelationshipdetailDetail.RELATIONSHIP = RelationshipdetailsEntities.RELATIONSHIP;
                    }
                    if (RelationshipdetailsEntities.RELATIVE_NAME != "" && RelationshipdetailsEntities.RELATIVE_NAME != null)
                    {
                        RelationshipdetailDetail.RELATIVE_NAME = RelationshipdetailsEntities.RELATIVE_NAME;
                    }
                    if (RelationshipdetailsEntities.DATEOFBIRTH != null)
                    {
                        RelationshipdetailDetail.DATE_OF_BIRTH = dob;
                    }
                    if (RelationshipdetailsEntities.OCCUPATION != "" && RelationshipdetailsEntities.OCCUPATION != null)
                    {
                        RelationshipdetailDetail.OCCUPATION = RelationshipdetailsEntities.OCCUPATION;
                    }
                    if (RelationshipdetailsEntities.DEPENDENT != "" && RelationshipdetailsEntities.DEPENDENT != null)
                    {
                        RelationshipdetailDetail.DEPENDENT = RelationshipdetailsEntities.DEPENDENT;
                    }
                   
                    _UOW.RELATIONSHIP_DETAILSRepository.Update(RelationshipdetailDetail);
                    _UOW.Save();
                    //scope.Complete();
                    success = true;
                    //}
                }
            }
            return success;
        }

        public bool DeleteRelationshipdetails(int RelationshipdetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
