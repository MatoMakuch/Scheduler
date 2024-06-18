using CyberFab.Automation.Scheduler.Net8;
using CyberFab.Automation.Scheduler.Net8.Models;

namespace CyberFab.Automation.Test.Scheduler.Net8
{
    internal class Utils
    {
        internal static bool CompareStartTimes(IReadOnlyDictionary<SchedulableJobOperation, int> scheduledOperations, IReadOnlyDictionary<SchedulableJobOperation, int> startTimes)
        {
            foreach (var scheduledOperation in scheduledOperations)
            {
                if (scheduledOperation.Value != startTimes[scheduledOperation.Key])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
