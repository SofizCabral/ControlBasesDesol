using System;

namespace ControlBasesDesol.Models
{
    public class LastBackupsModel
    {
        public string Instance { get; set; }
        public string Database { get; set; }
        public DateTime FechaBackup { get; set; }
        public float BackupSizeMB { get; set; }
        public string BackupType { get; set; }
        public string BackupFile { get; set; }
        public string RecoveryModel { get; set; }
        public int IsCopyOnly { get; set; }
    }

}