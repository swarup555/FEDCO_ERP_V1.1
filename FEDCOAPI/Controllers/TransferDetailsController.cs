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
    public class TransferDetailsController : ApiController
    {
        private readonly ITransferDetails _TransferDetails;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public TransferDetailsController()
        {
            _TransferDetails = new TransferDetailService();
        }
        #endregion
        // GET api/transferdetails
        public HttpResponseMessage Get()
        {
            var TransferDetails = _TransferDetails.GetAllTransferDetails();
            if (TransferDetails != null)
            {
                var TransferDetailsEntities = TransferDetails as List<TransferdetailsEntities> ?? TransferDetails.ToList();
                if (TransferDetailsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, TransferDetailsEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "TransferDetails not found");
        }

        // GET api/transferdetails/5
        public HttpResponseMessage Get(int id)
        {
            var TransferDetails = _TransferDetails.GetTransferDetailsById(id);
            if (TransferDetails != null)
                return Request.CreateResponse(HttpStatusCode.OK, TransferDetails);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No TransferDetails found for this id");
        }

        // POST api/transferdetails
        public int Post([FromBody] TransferdetailsEntities item)
        {
            return _TransferDetails.CreateTransferDetails(item);
        }

        // PUT api/transferdetails/5
        public bool Put(int id, [FromBody]TransferdetailsEntities item)
        {
            if (id > 0)
            {
                return _TransferDetails.UpdateTransferDetails(id, item);
            }
            return false;
        }

        // DELETE api/transferdetails/5
        public void Delete(int id)
        {
        }
    }
}
