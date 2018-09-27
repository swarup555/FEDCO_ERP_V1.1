using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BUSSINESS_SERVICE;
using BUSSINESS_ENTITIES;

namespace FEDCOAPI.Controllers
{
    public class AssetTypeController : ApiController
    {
        private readonly IAssetType _AssetTypemaster;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public AssetTypeController()
        {
            _AssetTypemaster = new AssetTypeService();
        }
        #endregion
        // GET api/assettype
        public HttpResponseMessage Get()
        {
            var AssetType = _AssetTypemaster.GetAllAssetTypeDetails();
            if (AssetType != null)
            {
                var DesignationEntities = AssetType as List<AssetTypeEntities> ?? AssetType.ToList();
                if (DesignationEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, DesignationEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "AssetType not found");
        }

        // GET api/assettype/5
        public HttpResponseMessage Get(int id)
        {
            var AssetType = _AssetTypemaster.GetAssetTypeById(id);
            if (AssetType != null)
                return Request.CreateResponse(HttpStatusCode.OK, AssetType);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No AssetType found for this id");
        }

        // POST api/assettype
        public int Post([FromBody] AssetTypeEntities AssetType)
        {
            return _AssetTypemaster.CreateAssetType(AssetType);
        }

        // PUT api/assettype/5
        public bool Put(int id, [FromBody]AssetTypeEntities AssetType)
        {
            if (id > 0)
            {
                return _AssetTypemaster.UpdateAssetType(id, AssetType);
            }
            return false;
        }

        // DELETE api/assettype/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _AssetTypemaster.DeleteAssetType(id);
            return false;
        }
    }
}
