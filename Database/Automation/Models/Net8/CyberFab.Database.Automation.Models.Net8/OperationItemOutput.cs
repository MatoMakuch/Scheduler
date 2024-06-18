using CyberFab.Attributes.Net8;
#region Usings for CyberFab Code Analyzer
using System;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Automation.Models.Net8
{
    public class OperationItemOutput
    {
        [Key]
        public string? ItemName { get; set; }

        [Key]
        public string? OperationName { get; set; }

        public int? Quantity { get; set; }

        [ForeignKey(nameof(ItemName))]
        [InverseProperty(nameof(Item.OperationItemOutputs))]
        public Item? Item { get; set; }

        [ForeignKey(nameof(OperationName))]
        [InverseProperty(nameof(Operation.OperationItemOutputs))]
        public Operation? Operation { get; set; }
    }
}
