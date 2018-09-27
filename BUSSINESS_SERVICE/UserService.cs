using DATA_LAYER.HRMSOUW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;
using DATA_LAYER;

namespace BUSSINESS_SERVICE
{
    public class UserService:Iuser
    {
        private readonly UOW _UOW;
        public UserService()
        {
            _UOW = new UOW();
        }

        public IEnumerable<UserEntities> GetUserById(int AssetDetailsId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntities> GetAllUserDetails()
        {
            var data = (from sta in _UOW.USERRepository.GetAll()
                        select new UserEntities
                        {
                            USERID = sta.USERID,
                            USERNAME = sta.USERNAME,
                            USERPASSWORD=sta.USERPASSWORD,
                            GROUPID=sta.GROUPID,
                            EMPID = sta.EMPID
                        }).ToList();
            return data;
        }
    }
}
