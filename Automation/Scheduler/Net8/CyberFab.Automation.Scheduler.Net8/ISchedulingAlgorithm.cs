using CyberFab.Automation.Scheduler.Net8.Models;

namespace CyberFab.Automation.Scheduler.Net8
{
    public interface ISchedulingAlgorithm
    {
        public Schedule? Schedule(IReadOnlySet<SchedulableJob> jobs); 
    }
}
