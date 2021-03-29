namespace ControlBasesDesol.Models
{
    public class BackupSchemaModelRequest
    {
        public string Instance { get; set; }
        public string Name { get; set; }
        public int BackupFullFrecDays { get; set; }
        public bool DailyBackupDif { get; set; }
    }
}