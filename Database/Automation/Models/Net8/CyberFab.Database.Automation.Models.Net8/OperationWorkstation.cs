#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Automation.Models.Net8
{
    public class OperationWorkstation
    {
        [Key]
        public string? OperationName { get; set; }

        [Key]
        public string? WorkstationName { get; set; }

        public int Duration { get; set; }

        [ForeignKey(nameof(OperationName))]
        [InverseProperty(nameof(Operation.OperationWorkstations))]
        public Operation? Operation { get; set; }

        [ForeignKey(nameof(WorkstationName))]
        [InverseProperty(nameof(WorkStation.OperationWorkstations))]
        public WorkStation? WorkStation { get; set; }

        [InverseProperty(nameof(ScheduledOperation.OperationWorkstation))]
        public ICollection<ScheduledOperation> ScheduledOperations { get; set; } = [];
    }
}
