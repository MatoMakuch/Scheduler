#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Automation.Models.Net8
{
    public class Job
    {
        [Key]
        public string Name { get; set; } = "New Job";

        [InverseProperty(nameof(JobOperation.Job))] 
        public ICollection<JobOperation> JobOperations { get; set; } = [];


        [InverseProperty(nameof(ScheduledOperation.Job))]
        public ICollection<ScheduledOperation> ScheduledOperations { get; set; } = [];


    }
}