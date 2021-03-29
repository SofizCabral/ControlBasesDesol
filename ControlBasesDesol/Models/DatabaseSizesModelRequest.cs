using System;

namespace ControlBasesDesol.Models
{
    public class DatabaseSizesModelRequest
    {
        public string Instance { get; set; }
        public string Base { get; set; }
        public float SizeMB { get; set; }
        public float FreeSpaceMB { get; set; }
        public int MaxSize { get; set; }
        public float Growth { get; set; }
        public bool IsPercentGrowth { get; set; }
        public string LogicName { get; set; }
        public string PhysicName { get; set; }
        public string Type { get; set; }
        public DateTime Fecha { get; set; }
    }
}