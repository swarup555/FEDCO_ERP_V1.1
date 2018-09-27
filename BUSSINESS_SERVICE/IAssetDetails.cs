using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IAssetDetails
    {
        IEnumerable<AssetDetailsEntities> GetAssetDetailsById(int AssetDetailsId);
        IEnumerable<AssetDetailsEntities> GetAllAssetDetails();
        int CreateAssetDetails(AssetDetailsEntities AssetDetailEntities);
        bool UpdateAssetDetails(int AssetDetailsId, AssetDetailsEntities AssetDetailEntities);
        bool DeleteAssetDetails(int AssetDetailsId);
    }
}
