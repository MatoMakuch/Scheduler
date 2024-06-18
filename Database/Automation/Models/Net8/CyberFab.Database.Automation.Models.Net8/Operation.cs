#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Automation.Models.Net8
{
    public class Operation
    {
        [Key]
        public string? Name { get; set; } = "New Operation";

        [InverseProperty(nameof(JobOperation.Operation))]
        public ICollection<JobOperation> JobOperations { get; set; } = [];


        [InverseProperty(nameof(OperationWorkstation.Operation))]
        public ICollection<OperationWorkstation> OperationWorkstations { get; set; } = [];


        [InverseProperty(nameof(OperationItemInput.Operation))]
        public ICollection<OperationItemInput> OperationItemInputs { get; set; } = [];


        [InverseProperty(nameof(OperationItemOutput.Operation))]
        public ICollection<OperationItemOutput> OperationItemOutputs { get; set; } = [];
    }
}
