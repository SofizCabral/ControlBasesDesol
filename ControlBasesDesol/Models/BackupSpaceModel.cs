using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlBasesDesol.Models
{
    public class BackupSpaceModel
    {
        public string Intance { get; set; }
        public string PathBUFull { get; set; }
        public string PathBUDif { get; set; }
        public string PathBULog { get; set; }
        public float PesoGbDif { get; set; }
        public float PesoGbFull { get; set; }
        public float PesoGbLog { get; set; }
        public string Disco { get; set; }
        public float? EspacioTotalDisco { get; set; }
        public float? EspacioLibreDisco { get; set; }
    }
}