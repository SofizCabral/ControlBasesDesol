using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ControlBasesDesol.Models;
using MySql.Data.MySqlClient;

namespace ControlBasesDesol.Repositories
{
    public class BackupService
    {
        public void saveBackupSpace(BackupSpaceModel model)
        {
           var cmdText = $@"INSERT INTO espaciobakups (Intance, PathBUFull, PathBUDif, PathBULog, PesoGbFull, PesoGbDif, PesoGbLog, Disco, EspacioTotalDisco, EspacioLibreDisco, FechaActualizacion) 
                            VALUES (@Intance, @PathBUFull, @PathBUDif, @PathBULog, @PesoGbFull, @PesoGbDif, @PesoGbLog, @Disco, @EspacioTotalDisco, @EspacioLibreDisco, NOW());";

            using (var conn = new MySqlConnection(WebConfigurationManager.AppSettings["connectionString"].ToString()))
            {
                using (var cmd = new MySqlCommand(cmdText, conn))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Intance", model.Intance);
                    cmd.Parameters.AddWithValue("@PathBUFull", model.PathBUFull);
                    cmd.Parameters.AddWithValue("@PathBUDif", model.PathBUDif);
                    cmd.Parameters.AddWithValue("@PathBULog", model.PathBULog);
                    cmd.Parameters.AddWithValue("@PesoGbFull", model.PesoGbFull);
                    cmd.Parameters.AddWithValue("@PesoGbDif", model.PesoGbDif);
                    cmd.Parameters.AddWithValue("@PesoGbLog", model.PesoGbLog);
                    cmd.Parameters.AddWithValue("@Disco", model.Disco);
                    cmd.Parameters.AddWithValue("@EspacioTotalDisco", model.EspacioTotalDisco);
                    cmd.Parameters.AddWithValue("@EspacioLibreDisco", model.EspacioLibreDisco);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}