using System.Collections.Generic;

namespace ControlBasesDesol.Models
{
    public class BackupSpaceModelRequest : BackupSpaceModel
    {
        public List<DiscModel> Discos { get; set; }
    }
}