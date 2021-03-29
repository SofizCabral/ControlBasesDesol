using System;

namespace ControlBasesDesol.Models
{
    public class LastBackupsModelRequest
    {
        public string ServerOrigin { get; set; }
        public string TargetDatabase { get; set; }
        public DateTime Operation_Date { get; set; }
        public float BackupSizeMB { get; set; }
        public string BackupType { get; set; }
        public string BackupFile { get; set; }
        public string recovery_model { get; set; }
        public bool is_copy_only { get; set; }
    }
}