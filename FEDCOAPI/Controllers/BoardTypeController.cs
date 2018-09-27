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
    public class BoardTypeController : ApiController
    {
        private readonly IBoardType _BoardType;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize item service instance
        /// </summary>
        public BoardTypeController()
        {
            _BoardType = new BoardTypeService();
        }
        #endregion
        // GET api/boardtype
        public HttpResponseMessage Get()
        {
            var BoardType = _BoardType.GetAllBoardType();
            if (BoardType != null)
            {
                var BoardTypeEntities = BoardType as List<BoardEntities> ?? BoardType.ToList();
                if (BoardTypeEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, BoardTypeEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "BoardType not found");
        }

        // GET api/boardtype/5
        public HttpResponseMessage Get(int id)
        {
            var BoardType = _BoardType.GetBoardTypeById(id);
            if (BoardType != null)
                return Request.CreateResponse(HttpStatusCode.OK, BoardType);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No BoardType found for this id");
        }

        // POST api/boardtype
        public void Post([FromBody]string value)
        {
        }

        // PUT api/boardtype/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/boardtype/5
        public void Delete(int id)
        {
        }
    }
}
