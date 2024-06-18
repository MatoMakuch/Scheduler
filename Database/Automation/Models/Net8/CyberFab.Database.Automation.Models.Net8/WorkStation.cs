#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Automation.Models.Net8
{
    public class WorkStation
    {
        [Key]
        public string Name { get; set; } = "New Workstation";

        /// <summary>
        /// Colection of operations executed on this machine.
        /// </summary>
        [InverseProperty(nameof(OperationWorkstation.WorkStation))]
        public ICollection<OperationWorkstation> OperationWorkstations { get; set; } = [];
    }
}
