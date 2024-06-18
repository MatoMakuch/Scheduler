using CyberFab.Attributes.Net8;
#region Usings for CyberFab Code Analyzer
using System;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class Machine
    {
        [Key]
        public string SerialNumber { get; set; } = "0000";

        public string Name { get; set; } = "New Machine";

        [InverseProperty(nameof(JobOperation.Job))]
        public ICollection<JobOperation> JobOperations { get; set; } = [];
    }
}