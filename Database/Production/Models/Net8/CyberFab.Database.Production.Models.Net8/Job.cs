#region Usings for CyberFab Code Analyzer
using System;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "New Job";

        [InverseProperty(nameof(JobOperation.Job))]
        public ICollection<JobOperation> JobOperations { get; set; } = [];

        [InverseProperty(nameof(JobOperationSuccession.Job))]
        public ICollection<JobOperationSuccession> JobOperationSuccessions { get; set; } = [];
    }
}
