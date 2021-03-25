using System.Configuration;
using System.Data;
using ControlBasesDesol.Models;
using MySqlConnector;

namespace ControlBasesDesol.Repositories
{
    public class BackupService
    {
        public void saveBackupSpace(BackupSpaceModel model)
        {
           var cmdText = $@"delete from espaciobakups where date_format(FechaActualizacion,'%Y/%m/%d')=curdate() and Disco=@Disco and Intance=@Intance;
                            INSERT INTO espaciobakups (Intance, PathBUFull, PathBUDif, PathBULog, PesoGbFull, PesoGbDif, PesoGbLog, Disco, EspacioTotalDisco, EspacioLibreDisco, FechaActualizacion) 
                            VALUES (@Intance, @PathBUFull, @PathBUDif, @PathBULog, @PesoGbFull, @PesoGbDif, @PesoGbLog, @Disco, @EspacioTotalDisco, @EspacioLibreDisco, NOW());";

            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString()))
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

        public void saveBackupSchema(BackupSchemaModel model)
        {
            var cmdText = $@"delete FROM `controlbd`.`esquemasbackup` where Intance=@Instance;
                             INSERT INTO `controlbd`.`esquemasbackup`(`Intance`,`BD`,`BackupFullFrecDays`,`DailyBackupDif`,`FechaActualización`)
                             VALUES(@Instance,@BD,@BackupFullFrecDays,@DailyBackupDif,now()); ";
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString()))
            {
                using (var cmd = new MySqlCommand(cmdText, conn))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Instance", model.Instance);
                    cmd.Parameters.AddWithValue("@BD", model.BD);
                    cmd.Parameters.AddWithValue("@BackupFullFrecDays", model.BackupFullFrecDays);
                    cmd.Parameters.AddWithValue("@DailyBackupDif", model.DailyBackupDif);


                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}