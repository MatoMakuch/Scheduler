#region Usings for CyberFab Code Analyzer
using System;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class JobOperation
    {
        [Key]
        public int JobId { get; set; }

        [Key]
        public string MachineSerialNumber { get; set; } = "0000";

        public int Duration { get; set; }


        [ForeignKey(nameof(JobId))]
        [InverseProperty(nameof(Job.JobOperations))]
        public Job? Job { get; set; }

        [ForeignKey(nameof(MachineSerialNumber))]
        [InverseProperty(nameof(Machine.JobOperations))]
        public Machine? Machine { get; set; }

        [InverseProperty(nameof(JobOperationSuccession.PredcedingJobOperation))]
        public ICollection<JobOperationSuccession> PrecedingJobOperationSuccessions { get; set; } = [];

        [InverseProperty(nameof(JobOperationSuccession.SucceedingJobOperation))]
        public ICollection<JobOperationSuccession> SucceedingJobOperationSuccessions { get; set; } = [];
    }
}
