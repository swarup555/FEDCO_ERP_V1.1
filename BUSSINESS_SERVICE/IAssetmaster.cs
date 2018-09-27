using BUSSINESS_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESS_SERVICE
{
    public interface IAssetmaster
    {
        IEnumerable<AssetmasterEntities> GetAssetDetailsById(int AssetDetailsId);
        IEnumerable<AssetmasterEntities> GetAllAssetDetails();
        int CreateAssetDetails(AssetmasterEntities AssetDetailEntities);
        bool UpdateAssetDetails(int AssetDetailsId, AssetmasterEntities AssetDetailEntities);
        bool DeleteAssetDetails(int AssetDetailsId);
    }
}
