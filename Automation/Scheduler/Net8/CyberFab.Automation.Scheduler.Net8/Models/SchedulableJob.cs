using CyberFab.Utils.Graph.Net8;

namespace CyberFab.Automation.Scheduler.Net8.Models
{
    public class SchedulableJob
    {
        public required string Id { get; init; }

        public IGraph<SchedulableJobOperation, UnitWeight>? JobOperationGraph { get; set; }
    }
}
