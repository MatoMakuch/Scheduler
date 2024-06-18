#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Automation.Models.Net8
{
    public class JobOperation
    {
        [Key]
        public string? JobName { get; set; }
        
        [Key]
        public string? OperationName { get; set; }

        [ForeignKey(nameof(JobName))]
        [InverseProperty(nameof(Job.JobOperations))]
        public Job? Job { get; set; }

        [ForeignKey(nameof(OperationName))]
        [InverseProperty(nameof(Operation.JobOperations))]
        public Operation? Operation { get; set; }

    }
}