using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class JobOperationSuccession
    {
        [Key]
        public int JobId { get; set; }

        [Key]
        public string PredcedingJobOperationMachineSerialNumber { get; set; } = "0000";

        [Key]
        public string SucceedingJobOperationMachineSerialNumber { get; set; } = "0000";

        [ForeignKey(nameof(JobId))]
        public Job? Job { get; set; }

        [ForeignKey(nameof(JobId) + ", " + nameof(PredcedingJobOperationMachineSerialNumber))]
        [InverseProperty(nameof(JobOperation.PrecedingJobOperationSuccessions))]
        public JobOperation? PredcedingJobOperation { get; set; }

        [ForeignKey(nameof(JobId) + ", " + nameof(SucceedingJobOperationMachineSerialNumber))]
        [InverseProperty(nameof(JobOperation.SucceedingJobOperationSuccessions))]
        public JobOperation? SucceedingJobOperation { get; set; }
    }
}
