#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class Supplier
    {
        [Key]
        public string Name { get; set; } = "New Supplier";

        [InverseProperty(nameof(Stock.Supplier))]
        public ICollection<Stock> Stocks { get; set; } = [];
    }
}
