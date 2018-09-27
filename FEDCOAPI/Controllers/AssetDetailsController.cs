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
    public class AssetDetailsController : ApiController
    {
        private readonly IAssetDetails _AssetDetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public AssetDetailsController()
        {
            _AssetDetails = new AssetDetailService();
        }
        #endregion
        // GET api/assetdetails
        public HttpResponseMessage Get()
        {
            var AssetDetails = _AssetDetails.GetAllAssetDetails();
            if (AssetDetails != null)
            {
                var AssetDetailsEntities = AssetDetails as List<AssetDetailsEntities> ?? AssetDetails.ToList();
                if (AssetDetailsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, AssetDetailsEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "AssetDetails not found");
        }

        // GET api/assetdetails/5
        public HttpResponseMessage Get(int id)
        {
            var AssetDetails = _AssetDetails.GetAssetDetailsById(id);
            if (AssetDetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, AssetDetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No AssetDetails found for this id");
        }

        // POST api/assetdetails
        public int Post([FromBody] AssetDetailsEntities item)
        {
            return _AssetDetails.CreateAssetDetails(item);
        }

        // PUT api/assetdetails/5
        public bool Put(int id, [FromBody]AssetDetailsEntities item)
        {
            if (id > 0)
            {
                return _AssetDetails.UpdateAssetDetails(id, item);
            }
            return false;
        }

        // DELETE api/assetdetails/5
        public void Delete(int id)
        {
        }
    }
}
