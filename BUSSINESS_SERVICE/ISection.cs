using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface ISection
    {
        IEnumerable<SectionEntities> GetSectionById(string SectionId);
        IEnumerable<SectionEntities> GetAllSection();
        int CreateSection(SectionEntities SectionEntities);
        bool UpdateSection(int SectionId, SectionEntities SectionEntities);
        bool DeleteSection(int SectionId); 
    }
}
