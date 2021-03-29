using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using ControlBasesDesol.Models;
using MySql.Data.MySqlClient;

namespace ControlBasesDesol.Services
{
    internal class SizesService
    {
        public void saveBasesSizes(List<DatabaseSizesModel> listModel)
        {
            var deleteQuery = @"DELETE FROM tamanobases
                                WHERE fecha > date_format(date_sub(curdate(),interval 1 month),'%Y/%m/%d') and instance=@Instance;";
            var insertQuery = @"INSERT INTO tamanobases(instance, base, sizeMB, freespacemb, maxsize, growth, ispercentgrowth, LogicName, PhysicName, Type, fecha, FechaActualizacion)
                                        VALUES (@Instance, @Base, @SizeMB, @Freespacemb, @Maxsize, @Growth, @Ispercentgrowth, @LogicName, @PhysicName, @Type, @Fecha, NOW()";

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
                    cmd.CommandText = deleteQuery;
                    cmd.Parameters.AddWithValue("@Instance", listModel.FirstOrDefault().Instance);
                    cmd.ExecuteNonQuery();

                    // Insert each model
                    foreach (var model in listModel)
                    {
                        cmd.CommandText = insertQuery;
                        cmd.Parameters.AddWithValue("@Instance", model.Instance);
                        cmd.Parameters.AddWithValue("@Base", model.Base);
                        cmd.Parameters.AddWithValue("@SizeMB", model.SizeMB);
                        cmd.Parameters.AddWithValue("@Freespacemb", model.FreeSpaceMB);
                        cmd.Parameters.AddWithValue("@Maxsize", model.MaxSize);
                        cmd.Parameters.AddWithValue("@Growth", model.Growth);
                        cmd.Parameters.AddWithValue("@Ispercentgrowth", model.IsPercentGrowth);
                        cmd.Parameters.AddWithValue("@LogicName", model.LogicName);
                        cmd.Parameters.AddWithValue("@PhysicName", model.PhysicName);
                        cmd.Parameters.AddWithValue("@Type", model.Type);
                        cmd.Parameters.AddWithValue("@Fecha", model.Fecha);
                        cmd.ExecuteNonQuery();
                    }

                    // Save all changes
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    cmd.Dispose();
                    transaction.Dispose();
                }
            }
        }

        public void saveTablesSizes(List<TablesSizesModel> listTables)
        {
            var deleteQuery = @"DELETE FROM `ultimosbackups`
                                WHERE FechaBackup > date_format(date_sub(curdate(),interval 1 month),'%Y/%m/%d') and Instance=@Instance;";
            var insertQuery = @"INSERT INTO tamanotablas(instance, base, nombre, filas, resevadokb, datoskb, indicekb, sinusokb, fecha, FechaActualizacion)
                                    VALUES (@Instance, @Base, @Nombre, @Filas, @Resevadokb, @Datoskb, @Indicekb, @Sinusokb, @Fecha, NOW()";

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
                    cmd.CommandText = deleteQuery;
                    cmd.Parameters.AddWithValue("@Instance", listTables.FirstOrDefault().Instance);
                    cmd.ExecuteNonQuery();

                    // Insert each model
                    foreach (var model in listTables)
                    {
                        cmd.CommandText = insertQuery;
                        cmd.Parameters.AddWithValue("@Instance", model.Instance);
                        cmd.Parameters.AddWithValue("@Base", model.Base);
                        cmd.Parameters.AddWithValue("@Nombre", model.Nombre);
                        cmd.Parameters.AddWithValue("@Filas", model.Filas);
                        cmd.Parameters.AddWithValue("@Resevadokb", model.ResevadoKB);
                        cmd.Parameters.AddWithValue("@Datoskb", model.DatosKB);
                        cmd.Parameters.AddWithValue("@Indicekb", model.IndiceKB);
                        cmd.Parameters.AddWithValue("@Sinusokb", model.SinUsoKB);
                        cmd.Parameters.AddWithValue("@Fecha", model.Fecha);
                        cmd.ExecuteNonQuery();
                    }

                    // Save all changes
                    transaction.Commit();
                }
                catch (System.Exception)
                {
                    transaction.Rollback();
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