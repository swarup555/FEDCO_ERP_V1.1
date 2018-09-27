using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IQualificationDetails
    {
        IEnumerable<QualificationDetailsEntities> GetQualificationDetailseById(int QualificationDetailsId);
        IEnumerable<QualificationDetailsEntities> GetAllQualificationDetails();
        int CreateQualificationDetails(QualificationDetailsEntities QualificationDetailsEntities);
        bool UpdateQualificationDetails(int QualificationDetailsId, QualificationDetailsEntities QualificationDetailsEntities);
        bool DeleteQualificationDetails(int QualificationDetailsId);
    }
}
