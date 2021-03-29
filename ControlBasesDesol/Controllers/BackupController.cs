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

        [HttpPost]
        [Route("api/Backup/SaveDiscSpace")]
        public IHttpActionResult postDiscSpace([FromBody]BackupSpaceModelRequest request)
        {
            ResponseBase result = _backupManager.saveDiscSpace(request);

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
        [Route("api/Backup/SaveSchema")]
        public IHttpActionResult postSchema([FromBody] List<BackupSchemaModelRequest> request)
        {
            ResponseBase result = _backupManager.saveBackupSchema(request);

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
        [Route("api/Backup/SaveLastBackups")]
        public IHttpActionResult postLastBackups([FromBody] List<LastBackupsModelRequest> request)
        {
            ResponseBase result = _backupManager.saveLastBackup(request);

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
