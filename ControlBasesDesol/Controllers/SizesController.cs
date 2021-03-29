using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ControlBasesDesol.Manager;
using ControlBasesDesol.Models;

namespace ControlBasesDesol.Controllers
{
    public class SizesController : ApiController
    {
        private SizesManager _sizesManager;

        public SizesController()
        {
            _sizesManager = new SizesManager();
        }

        [HttpPost]
        [Route("api/Backup/SaveSizesBase")]
        public IHttpActionResult postDiscSpace([FromBody]List<DatabaseSizesModelRequest> request)
        {
            ResponseBase result = _sizesManager.saveSizesBase(request);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        [Route("api/Backup/SaveSizeTable")]
        public IHttpActionResult postSchema([FromBody] List<TablesSizesModel> request)
        {
            ResponseBase result = _sizesManager.saveSizesTable(request);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

      

    }
}
