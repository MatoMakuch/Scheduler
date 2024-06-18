using CyberFab.Attributes.Net8;
#region Usings for CyberFab Code Analyzer
using System;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Automation.Models.Net8
{
    public class Item
    {
        [Key] 
        public string Name { get; set; } = "New Item";

        [InverseProperty(nameof(OperationItemInput.Item))]
        public ICollection<OperationItemInput> OperationItemInputs { get; set; } = [];

        [InverseProperty(nameof(OperationItemOutput.Item))]
        public ICollection<OperationItemOutput> OperationItemOutputs { get; set; } = [];
    }
}
