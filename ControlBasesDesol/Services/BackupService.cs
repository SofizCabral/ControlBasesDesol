using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using ControlBasesDesol.Models;
using MySql.Data.MySqlClient;

namespace ControlBasesDesol.Services
{
    public class BackupService
    {
        public void saveSpace(BackupSpaceModelRequest model)
        {
            var deleteQuery = @"delete from espaciobakups where date_format(FechaActualizacion,'%Y/%m/%d')=curdate() and Instance=@Instance;";
            var insertBackupQuery = $@"INSERT INTO espaciobakups (Instance, PathBUFull, PathBUDif, PathBULog, PesoGbFull, PesoGbDif, PesoGbLog, FechaActualizacion) 
                                        VALUES (@Instance, @PathBUFull, @PathBUDif, @PathBULog, @PesoGbFull, @PesoGbDif, @PesoGbLog, NOW());";

            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString()))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                try
                {
                    // Delete 2 tables
                    cmd.Parameters.Clear();
                    cmd.CommandText = deleteQuery;
                    cmd.Parameters.AddWithValue("@Instance", model.Instance);
                    cmd.ExecuteNonQuery();

                    // Insert table espaciobakups
                    cmd.Parameters.Clear();
                    cmd.CommandText = insertBackupQuery;
                    cmd.Parameters.AddWithValue("@Instance", model.Instance);
                    cmd.Parameters.AddWithValue("@PathBUFull", model.PathBUFull);
                    cmd.Parameters.AddWithValue("@PathBUDif", model.PathBUDif);
                    cmd.Parameters.AddWithValue("@PathBULog", model.PathBULog);
                    cmd.Parameters.AddWithValue("@PesoGbFull", model.PesoGbFull);
                    cmd.Parameters.AddWithValue("@PesoGbDif", model.PesoGbDif);
                    cmd.Parameters.AddWithValue("@PesoGbLog", model.PesoGbLog);
                    cmd.ExecuteNonQuery();

                    // Save all changes
                    transaction.Commit();
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    transaction.Dispose();
                }
            }
        }

        public void saveDiscSpace(List<DiscModel> listModel)
        {
            var deleteQuery = @"delete from espaciodiscos where date_format(FechaActualizacion,'%Y/%m/%d')=curdate() and Instance=@Instance;";
            var insertDiscQuery = @"INSERT INTO espaciodiscos (Instance, Disco, EspacioLibreGB, EspacioTotalGB, FechaActualizacion) 
                                        VALUES (@Instance, @Disco, @EspacioTotalDisco, @EspacioLibreDisco, NOW());";

            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString()))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                try
                {
                    // Delete 
                    cmd.Parameters.Clear();
                    cmd.CommandText = deleteQuery;
                    cmd.Parameters.AddWithValue("@Instance", listModel.FirstOrDefault().Instance);
                    cmd.ExecuteNonQuery();

                    // Insert each disc in espaciodiscos
                    foreach (var disc in listModel)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = insertDiscQuery;
                        cmd.Parameters.AddWithValue("@Instance", disc.Instance);
                        cmd.Parameters.AddWithValue("@Disco", disc.Letra);
                        cmd.Parameters.AddWithValue("@EspacioTotalDisco", disc.TamañoGb);
                        cmd.Parameters.AddWithValue("@EspacioLibreDisco", disc.LibreGB);
                        cmd.ExecuteNonQuery();
                    }

                    // Save all changes
                    transaction.Commit();
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    transaction.Dispose();
                }
            }
        }

        public void saveBackupSchema(List<BackupSchemaModel> ListModel)
        {
            var deleteQuery = @"delete FROM esquemasbackup where Instance = @Instance;";
            var insertQuery = @"INSERT INTO esquemasbackup(Instance, BD, BackupFullFrecDays, DailyBackupDif, FechaActualizacion)
                                        VALUES (@Instance, @BD, @BackupFullFrecDays, @DailyBackupDif, now());";

            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString()))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                try
                {
                    // Delete 
                    cmd.Parameters.Clear();
                    cmd.CommandText = deleteQuery;
                    cmd.Parameters.AddWithValue("@Instance", ListModel.FirstOrDefault().Instance);
                    cmd.ExecuteNonQuery();

                    // Insert each model
                    foreach (var model in ListModel)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = insertQuery;
                        cmd.Parameters.AddWithValue("@Instance", model.Instance);
                        cmd.Parameters.AddWithValue("@BD", model.BD);
                        cmd.Parameters.AddWithValue("@BackupFullFrecDays", model.BackupFullFrecDays);
                        cmd.Parameters.AddWithValue("@DailyBackupDif", model.DailyBackupDif);
                        cmd.ExecuteNonQuery();
                    }

                    // Save all changes
                    transaction.Commit();
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    transaction.Dispose();
                }
            }
        }

        public void saveLastBackup(List<LastBackupsModel> ListModel)
        {
            var deleteQuery = @"DELETE FROM ultimosbackups
                                WHERE FechaBackup > date_format(date_sub(curdate(),interval 1 month),'%Y/%m/%d') and Instance=@Instance;";
            var insertQuery = @"INSERT INTO ultimosbackups (Instance, `database`, FechaBackup, BackupSizeMB, BackupType, backupFile, RecoveryModel, IsCopyOnly, FechaActualizacion)
                                        VALUES(@Instance, @Database, @FechaBackup, @BackupSizeMB, @BackupType, @BackupFile, @RecoveryModel, @IsCopyOnly, NOW())";

            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString()))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                try
                {
                    // Delete 
                    cmd.Parameters.Clear();
                    cmd.CommandText = deleteQuery;
                    cmd.Parameters.AddWithValue("@Instance", ListModel.FirstOrDefault().Instance);
                    cmd.ExecuteNonQuery();

                    // Insert each model
                    foreach (var model in ListModel)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = insertQuery;
                        cmd.Parameters.AddWithValue("@Instance", model.Instance);
                        cmd.Parameters.AddWithValue("@Database", model.Database);
                        cmd.Parameters.AddWithValue("@FechaBackup", model.FechaBackup);
                        cmd.Parameters.AddWithValue("@BackupSizeMB", model.BackupSizeMB);
                        cmd.Parameters.AddWithValue("@BackupType", model.BackupType);
                        cmd.Parameters.AddWithValue("@BackupFile", model.BackupFile);
                        cmd.Parameters.AddWithValue("@RecoveryModel", model.RecoveryModel);
                        cmd.Parameters.AddWithValue("@IsCopyOnly", model.IsCopyOnly);
                        cmd.ExecuteNonQuery();
                    }

                    // Save all changes
                    transaction.Commit();
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    transaction.Dispose();
                }
            }
        }

    }
}