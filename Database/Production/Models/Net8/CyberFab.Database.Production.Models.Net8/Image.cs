using CyberFab.Attributes.Net8;
#region Usings for CyberFab Code Analyzer
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class Image
    {
        [Key] 
        public string? Name { get; set; }

        /// <summary>
        /// Content of the file in binary format.
        /// </summary>
        public byte[]? Content { get; set; }

        [InverseProperty(nameof(Blueprint.SmallImage))]
        public ICollection<Blueprint> TemplateSmallImages { get; set; } = [];

        [InverseProperty(nameof(Blueprint.LargeImage))]
        public ICollection<Blueprint> TemplateLargeImages { get; set; } = [];
    }
}
