using System;

namespace ControlBasesDesol.Models
{
    public class TablesSizesModel
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

}