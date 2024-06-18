using CyberFab.Attributes.Net8;
#region Usings for CyberFab Code Analyzer
using System;
using System.Linq;
#endregion
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberFab.Database.Production.Models.Net8
{
    public class Blueprint
    {
        [Key] 
        public string Name { get; set; } = "New Template";

        /// <summary>
        /// Image containing small preview picture of the stock template.
        /// Standard format is PNG with dimensions 102x64px.
        /// </summary>
        public string? SmallImageName { get; set; }

        /// <summary>
        /// Image containing large preview picture of the stock template.
        /// Standard format is PNG with dimensions 320x240px.
        /// </summary>
        public string? LargeImageName { get; set; }

        /// <summary>
        /// Dimensions of the stock template depending on the template type of its template.
        /// </summary>
        public double? Width { get; set; }

        public double? Height { get; set; }

        [Lazy]
        [ForeignKey(nameof(SmallImageName))]
        [InverseProperty(nameof(Image.TemplateSmallImages))]
        public Image? SmallImage { get; set; }

        [Lazy]
        [ForeignKey(nameof(LargeImageName))]
        [InverseProperty(nameof(Image.TemplateLargeImages))]
        public Image? LargeImage { get; set; }

        [InverseProperty(nameof(Template.Blueprint))]
        public ICollection<Template> Templates { get; set; } = [];
    }
}
