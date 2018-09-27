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
    public class AssetMasterController : ApiController
    {
        private readonly IAssetmaster _Assetmaster;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public AssetMasterController()
        {
            _Assetmaster = new AssetMasterService();
        }
        #endregion
        // GET api/assetmaster
        public HttpResponseMessage Get()
        {
            var Asset = _Assetmaster.GetAllAssetDetails();
            if (Asset != null)
            {
                var AssetEntities = Asset as List<AssetmasterEntities> ?? Asset.ToList();
                if (AssetEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, AssetEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Asset not found");
        }

        // GET api/assetmaster/5
        public HttpResponseMessage Get(int id)
        {
            var Asset = _Assetmaster.GetAssetDetailsById(id);
            if (Asset != null)
                return Request.CreateResponse(HttpStatusCode.OK, Asset);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Asset found for this id");
        }

        // POST api/assetmaster
        public int Post([FromBody] AssetmasterEntities Asset)
        {
            return _Assetmaster.CreateAssetDetails(Asset);
        }

        // PUT api/assetmaster/5
        public bool Put(int id, [FromBody]AssetmasterEntities Asset)
        {
            if (id > 0)
            {
                return _Assetmaster.UpdateAssetDetails(id, Asset);
            }
            return false;
        }

        // DELETE api/assetmaster/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _Assetmaster.DeleteAssetDetails(id);
            return false;
        }
    }
}
