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
    public class BackupController : ApiController
    {
        private BackupManager _backupManager;

        public BackupController()
        {
            _backupManager = new BackupManager();
        }

        // PUT: api/Backup/5
        [Route("api/Backup/SaveDiscSpace")]
        public IHttpActionResult SaveDiscSpace([FromBody]BackupSpaceModelRequest request)
        {
            ResponseBase result = _backupManager.SaveDiscSpace(request);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [Route("api/Backup/SaveBUSchema")]
        public IHttpActionResult SaveBUSchema([FromBody] List<BackupSchemaModelRequest> request)
        {
            //ResponseBase result = _backupManager.SaveBackupSchema(request);

            //if (result.Success)
            //{
                return Ok();
            //}
            //else
            //{
            //    return BadRequest(result.Message);
            //}
        }

    }
}
