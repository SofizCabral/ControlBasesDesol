using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlBasesDesol.Models;
using ControlBasesDesol.Services;

namespace ControlBasesDesol.Manager
{
    public class BackupManager
    {
        private BackupService _backupService;

        public BackupManager()
        {
            _backupService = new BackupService();
        }

        public ResponseBase saveSpace(BackupSpaceModelRequest request)
        {
            var response = new ResponseBase();
            try
            {
                _backupService.saveSpace(request);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return response;
        }

        public ResponseBase saveDiscSpace(List<DiscModel> request)
        {
            var response = new ResponseBase();

            try
            {
                _backupService.saveDiscSpace(request);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();

                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return response;
        }

        public ResponseBase saveBackupSchema(List<BackupSchemaModelRequest> backupSchemas)
        {
            var response = new ResponseBase();
            var listModel = new List<BackupSchemaModel>();

            try
            {
                foreach (var schema in backupSchemas)
                {
                    var model = new BackupSchemaModel();

                    model.Instance = schema.Instance;
                    model.BD = schema.Name;
                    model.BackupFullFrecDays = schema.BackupFullFrecDays;
                    model.DailyBackupDif = schema.DailyBackupDif ? 1 : 0;

                    listModel.Add(model);
                }

                _backupService.saveBackupSchema(listModel);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return response;
        }

        public ResponseBase saveLastBackup(List<LastBackupsModelRequest> lastbackups)
        {
            var response = new ResponseBase();
            var listModel = new List<LastBackupsModel>();

            try
            {
                foreach (var backup in lastbackups)
                {
                    var model = new LastBackupsModel();

                    model.Instance = backup.ServerOrigin;
                    model.Database = backup.TargetDatabase;
                    model.FechaBackup = backup.Operation_Date;
                    model.BackupSizeMB = backup.BackupSizeMB;
                    model.BackupType = backup.BackupType;
                    model.BackupFile = backup.BackupFile;
                    model.RecoveryModel = backup.recovery_model;

                    model.IsCopyOnly = backup.is_copy_only ? 1 : 0;

                    listModel.Add(model);
                }

                _backupService.saveLastBackup(listModel);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return response;
        }

    }
}