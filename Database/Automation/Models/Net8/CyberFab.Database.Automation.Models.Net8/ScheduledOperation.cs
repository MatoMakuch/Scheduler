#region Usings for CyberFab Code Analyzer
using System;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Automation.Models.Net8
{
    public class ScheduledOperation
    {
        [Key]
        public string? OperationName { get; set; }

        [Key]
        public string? WorkstationName { get; set; }

        [Key]
        public int Start { get; set; }

        public string? JobName { get; set; }

        [ForeignKey(nameof(WorkstationName) + ", " + nameof(OperationName))]
        [InverseProperty(nameof(OperationWorkstation.ScheduledOperations))]
        public OperationWorkstation? OperationWorkstation { get; set; }

        [ForeignKey(nameof(JobName))]
        [InverseProperty(nameof(Job.ScheduledOperations))]
        public Job? Job { get; set; }
    }
}
