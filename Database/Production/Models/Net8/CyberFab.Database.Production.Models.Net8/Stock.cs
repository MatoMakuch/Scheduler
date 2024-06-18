#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class Stock
    {
        [Key]
        public string? SerialNumber { get; set; }

        public string? SupplierName { get; set; }

        public string? MaterialTypeName { get; set; }

        public string? MaterialSpecificationName { get; set; }

        public string? BlueprintName { get; set; }

        [ForeignKey(nameof(MaterialTypeName) + ", " + 
            nameof(MaterialSpecificationName) + ", " + nameof(BlueprintName))]
        [InverseProperty(nameof(Template.Stocks))]
        public Template? Template { get; set; }

        [ForeignKey(nameof(SupplierName))]
        [InverseProperty(nameof(Supplier.Stocks))]
        public Supplier? Supplier { get; set; }
    }
}
