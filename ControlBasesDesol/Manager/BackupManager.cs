using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlBasesDesol.Models;
using ControlBasesDesol.Repositories;

namespace ControlBasesDesol.Manager
{
    public class BackupManager
    {
        private BackupService _backupService;

        public BackupManager()
        {
            _backupService = new BackupService();
        }

        public ResponseBase SaveDiscSpace(BackupSpaceModelRequest request)
        {
            var response = new ResponseBase();

            var listSpace = new List<BackupSpaceModel>();
            BackupSpaceModel model1;
            BackupSpaceModel model2 = new BackupSpaceModel();
            BackupSpaceModel model3= new BackupSpaceModel();

            try
            {
                 model1 = new BackupSpaceModel()
                {
                    Intance = request.Intance,
                    PathBUFull = request.PathBUFull,
                    PesoGbFull = request.PesoGbFull,
                    Disco = request.Discos.Where(x => x.Letra.Substring(0, 1).ToUpper() == request.PathBUFull.Substring(0, 1).ToUpper()).FirstOrDefault()?.Letra,
                    EspacioTotalDisco = request.Discos.Where(x => x.Letra.Substring(0, 1).ToUpper() == request.PathBUFull.Substring(0, 1).ToUpper()).FirstOrDefault()?.TamañoGb,
                    EspacioLibreDisco = request.Discos.Where(x => x.Letra.Substring(0, 1).ToUpper() == request.PathBUFull.Substring(0, 1).ToUpper()).FirstOrDefault()?.LibreGB
                };


                if (request.PathBUFull.Substring(0, 1).ToUpper() == request.PathBUDif.Substring(0, 1).ToUpper())
                {
                    model1.PathBUDif = request.PathBUDif;
                    model1.PesoGbDif = request.PesoGbDif;
                }
                else
                {
                     model2 = new BackupSpaceModel()
                    {
                        Intance = request.Intance,
                        PathBUDif = request.PathBUDif,
                        PesoGbDif = request.PesoGbDif,
                        Disco = request.Discos.Where(x => x.Letra.Substring(0, 1).ToUpper() == request.PathBUDif.Substring(0, 1).ToUpper()).FirstOrDefault()?.Letra,
                        EspacioTotalDisco = request.Discos.Where(x => x.Letra.Substring(0, 1).ToUpper() == request.PathBUDif.Substring(0, 1).ToUpper()).FirstOrDefault()?.TamañoGb,
                        EspacioLibreDisco = request.Discos.Where(x => x.Letra.Substring(0, 1).ToUpper() == request.PathBUDif.Substring(0, 1).ToUpper()).FirstOrDefault()?.LibreGB
                    };
                }

                if (request.PathBUFull.Substring(0, 1).ToUpper() == request.PathBULog.Substring(0, 1).ToUpper())
                {
                    model1.PathBULog = request.PathBULog;
                    model1.PesoGbLog = request.PesoGbLog;
                }
                else
                {
                    if (request.PathBUDif.Substring(0, 1).ToUpper() == request.PathBULog.Substring(0, 1).ToUpper())
                    {
                        model2.PathBULog = request.PathBULog;
                        model2.PesoGbLog = request.PesoGbLog;
                    }
                    else
                    {
                         model3 = new BackupSpaceModel()
                        {
                            Intance = request.Intance,
                            PathBULog = request.PathBULog,
                            PesoGbLog = request.PesoGbFull,
                            Disco = request.Discos.Where(x => x.Letra.Substring(0, 1).ToUpper() == request.PathBULog.Substring(0, 1).ToUpper()).FirstOrDefault()?.Letra,
                            EspacioTotalDisco = request.Discos.Where(x => x.Letra.Substring(0, 1).ToUpper() == request.PathBULog.Substring(0, 1).ToUpper()).FirstOrDefault()?.TamañoGb,
                            EspacioLibreDisco = request.Discos.Where(x => x.Letra.Substring(0, 1).ToUpper() == request.PathBULog.Substring(0, 1).ToUpper()).FirstOrDefault()?.LibreGB
                        };
                    }
                }

                listSpace.Add(model1);

                if (!string.IsNullOrEmpty(model2.Intance))
                    listSpace.Add(model2);
                
                if (!string.IsNullOrEmpty(model3.Intance))
                    listSpace.Add(model3);

                foreach (var item in listSpace)
                {
                    _backupService.saveBackupSpace(item);
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return response;
        }
    }
}