using CyberFab.Automation.Scheduler.Net8.Models;
using CyberFab.Utils.Enumerators.Net8;

namespace CyberFab.Automation.Scheduler.Net8
{
    public class BruteForceSchedulingAlgorithm : ISchedulingAlgorithm
    {
        public Schedule? Schedule(IReadOnlySet<SchedulableJob> jobs)
        {
            var bestMakespan = int.MaxValue;
            Schedule? bestSchedule = null;

            IEnumerable<IList<SchedulableJobOperation>> machinesJobOperations = jobs
                .SelectMany(job => job.JobOperationGraph!.EnumerateNodes())
                .GroupBy(operation => operation.Machine)
                .Select(group => group.ToList());

            foreach (IEnumerable<IList<SchedulableJobOperation>> machineJobOperationsCombination
                in new CartesianProductEnumerator<IList<SchedulableJobOperation>>(machinesJobOperations
                        .Select(machineJobOperation 
                            => new PermutationIterator<SchedulableJobOperation>(machineJobOperation)))
            )
            {
                Schedule schedule = Scheduler.Schedule(machineJobOperationsCombination
                    .ToDictionary
                    (
                        operations => operations.First().Machine!,
                        operations => new Queue<SchedulableJobOperation>(operations)
                    ));

                var allMachinesAvailableAfter = schedule.MachineAvailabilities.Values.Max();

                if (allMachinesAvailableAfter < bestMakespan)
                {
                    bestMakespan = allMachinesAvailableAfter;

                    bestSchedule = schedule;
                }
            }

            return bestSchedule;
        }
    }
}
