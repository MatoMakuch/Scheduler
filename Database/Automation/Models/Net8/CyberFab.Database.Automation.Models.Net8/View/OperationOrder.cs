using System.ComponentModel.DataAnnotations;

namespace CyberFab.Database.Automation.Models.Net8.View
{
    public class OperationOrder
    {
        [Key]
        public string? PrecedingOperationName { get; set; }

        [Key]
        public string? FollowingOperationName { get; set; }

        // TODO: Add navigation properties.
    }
}
