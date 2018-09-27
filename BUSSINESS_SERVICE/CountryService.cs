using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;
using System.Transactions;

namespace BUSSINESS_SERVICE
{
    public class CountryService:ICountry
    {
        private readonly UOW _UOW;
        public CountryService()
        {
            _UOW = new UOW();
        }
        public IEnumerable<CountryEntities> GetCountryById(int CountryId)
        {
            var data = (from con in _UOW.COUNTRYRepository.GetAll()
                        where con.ID == CountryId
                        select new CountryEntities
                        {
                            ID = con.ID,
                            COUNTRY_NAME = con.COUNTRY_NAME
                        }).ToList();
            return data;
        }

        public IEnumerable<CountryEntities> GetAllCountry()
        {
            var data = (from con in _UOW.COUNTRYRepository.GetAll()
                        select new CountryEntities
                        {
                            ID = con.ID,
                            COUNTRY_NAME = con.COUNTRY_NAME
                        }).ToList();
            return data;
        }

        public int CreateCountry(CountryEntities CountryEntities)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCountry(int CountryId, CountryEntities CountryEntities)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCountry(int CountryId)
        {
            throw new NotImplementedException();
        }
    }
}
