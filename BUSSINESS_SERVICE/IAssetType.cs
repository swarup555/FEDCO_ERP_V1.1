using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUSSINESS_ENTITIES;

namespace BUSSINESS_SERVICE
{
    public interface IAssetType
    {
        IEnumerable<AssetTypeEntities> GetAssetTypeById(int AssetDetailsId);
        IEnumerable<AssetTypeEntities> GetAllAssetTypeDetails();
        int CreateAssetType(AssetTypeEntities AssetDetailEntities);
        bool UpdateAssetType(int AssetDetailsId, AssetTypeEntities AssetDetailEntities);
        bool DeleteAssetType(int AssetDetailsId);
    }
}
