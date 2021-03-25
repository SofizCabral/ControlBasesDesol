using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlBasesDesol.Models
{
    public class BackupSpaceModelRequest
    {
        public string Intance { get; set; }
        public string PathBUFull { get; set; }
        public string PathBUDif { get; set; }
        public string PathBULog { get; set; }
        public float PesoGbDif { get; set; }
        public float PesoGbFull { get; set; }
        public float PesoGbLog { get; set; }

        public List<DiscModel> Discos { get; set; }
    }

    public class SaveBackupSchemaModelRequest
    {
        public List<BackupSchemaModelRequest> Schemas { get; set; }
    }
    public class BackupSchemaModelRequest
    {
        public string Instance { get; set; }
        public string Name { get; set; }
        public int BackupFullFrecDays { get; set; }
     // public Boolean DailyBackupDif { get; set; }

    }

    public class DatabaseSizesModelRequest
    {
        public string Intance { get; set; }
        public string Base { get; set; }
        public float SizeMB { get; set; }
        public float FreeSpaceMB { get; set; }
        public int MaxSize { get; set; }
        public float Growth { get; set; }
        public Boolean IsPercentGrowth { get; set; }
        public string LogicName { get; set; }
        public string PhysicName { get; set; }
        public string Type { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class TablesSizesModelRequest
    {
        public string Instance { get; set; }
        public string Base { get; set; }
        public string Nombre { get; set; }
        public int Filas { get; set; }
        public float ResevadoKB { get; set; }
        public float DatosKB { get; set; }
        public float IndiceKB { get; set; }
        public float SinUsoKB { get; set; }
        public DateTime Fecha { get; set; }

    }

    public class LastBackupsModelRequest
    {
        public string ServerOrigin { get; set; }
        public string TargetDatabase { get; set; }
        public DateTime Operation_Date { get; set; }
        public float BackupSizeMB { get; set; }
        public string BackupType { get; set; }
        public string BackupFile { get; set; }
        public string recovery_model { get; set; }
        public Boolean is_copy_only { get; set; }
    }
}