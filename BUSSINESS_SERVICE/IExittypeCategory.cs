using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IExittypeCategory
    {
        IEnumerable<ExitcatagoryEntities> GetExittypeCategoryById(int ExittypeCategoryId);
        IEnumerable<ExitcatagoryEntities> GetAllExittypeCategory();
        int CreateExittypeCategory(ExitcatagoryEntities ExittypeCategoryEntities);
        bool UpdateExittypeCategory(int ExittypeCategoryId, ExitcatagoryEntities ExittypeCategoryEntities);
        bool DeleteExittypeCategory(int ExittypeCategoryId);
    }
}
