using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;


namespace BUSSINESS_SERVICE
{
    public interface ICountry
    {
        IEnumerable<CountryEntities> GetCountryById(int CountryId);
        IEnumerable<CountryEntities> GetAllCountry();
        int CreateCountry(CountryEntities CountryEntities);
        bool UpdateCountry(int CountryId, CountryEntities CountryEntities);
        bool DeleteCountry(int CountryId); 
    }
}
