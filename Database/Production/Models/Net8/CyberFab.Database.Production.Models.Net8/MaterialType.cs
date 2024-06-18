#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class MaterialType
    {
        /// <summary>
        /// Name of the material (e.g. MST, SST, AL).
        /// </summary>
        [Key]
        public string Name { get; set; } = "New Material";

        [InverseProperty(nameof(Material.MaterialType))]
        public ICollection<Material> Materials { get; set; } = [];
    }
}
