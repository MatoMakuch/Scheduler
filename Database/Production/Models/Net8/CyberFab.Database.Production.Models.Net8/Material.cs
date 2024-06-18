#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class Material
    {
        [Key] 
        public string? MaterialTypeName { get; set; }

        /// <summary>
        /// Specification of the material for more accurate definition.
        /// </summary>
        [Key] 
        public string Specification { get; set; } = "Regular";

        /// <summary>
        /// Density of the material type in kilograms per cubic meters.
        /// </summary>
        public int? Density { get; set; }

        [ForeignKey(nameof(MaterialTypeName))]
        [InverseProperty(nameof(MaterialType.Materials))]
        public MaterialType? MaterialType { get; set; }

        [InverseProperty(nameof(Template.Material))]
        public ICollection<Template> Templates { get; set; } = [];
    }
}
