using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberFab.Database.Production.Models.Net8
{
    public class Template
    {
        [Key]
        public string? BlueprintName { get; set; }

        [Key]
        public string? MaterialTypeName { get; set; }

        [Key]
        public string? MaterialSpecificationName { get; set; }

        [ForeignKey(nameof(BlueprintName))]
        [InverseProperty(nameof(Blueprint.Templates))]
        public Blueprint? Blueprint { get; set; }

        [ForeignKey(nameof(MaterialTypeName) + ", " + nameof(MaterialSpecificationName))]
        [InverseProperty(nameof(Material.Templates))]
        public Material? Material { get; set; }

        [InverseProperty(nameof(Stock.Template))]
        public ICollection<Stock> Stocks { get; set; } = [];
    }
}
