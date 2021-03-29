using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlBasesDesol.Models
{
    public class BackupSchemaModel
    {
        public string Instance { get; set; }
        public string BD { get; set; }
        public int BackupFullFrecDays { get; set; }
        public int DailyBackupDif { get; set; }
    }
}