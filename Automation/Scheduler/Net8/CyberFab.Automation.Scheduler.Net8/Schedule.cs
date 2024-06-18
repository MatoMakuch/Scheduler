using CyberFab.Automation.Scheduler.Net8.Models;

namespace CyberFab.Automation.Scheduler.Net8
{
    public readonly struct Schedule
    {
        public IReadOnlyDictionary<SchedulableJobOperation, int> ScheduledJobOperations { get; init; }

        public IReadOnlyDictionary<SchedulableMachine, int> MachineAvailabilities { get; init; }
    }
}
