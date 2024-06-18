using CyberFab.Automation.Scheduler.Net8.Models;
using CyberFab.Utils.Graph.Net8;

namespace CyberFab.Automation.Scheduler.Net8
{
    internal class Scheduler
    {
        internal static Schedule Schedule(
                IReadOnlyDictionary<SchedulableMachine, Queue<SchedulableJobOperation>> machineOperationQueues)
        {
            HashSet<SchedulableJobOperation> scheduledJobOperations = [];

            Dictionary<SchedulableJobOperation, int> scheduledJobOperationsStartTimes = [];

            Dictionary<SchedulableMachine, int> machineAvailabilities = machineOperationQueues.Keys.ToDictionary
                (
                    machine => machine,
                    machine => 0
                );

            while(machineOperationQueues.Any(machineOperationQueue => machineOperationQueue.Value.Count > 0))
            {
                foreach (var machineOperationQueue in machineOperationQueues)
                {
                    while (machineOperationQueue.Value.Count > 0)
                    {
                        var operation = machineOperationQueue.Value.Dequeue();

                        var precedingJobOperations = operation.Job.JobOperationGraph!
                            .EnumerateIncomingEdges(operation)
                            .Select(edge => edge.Start);

                        // All preceding operations of the current operation must be scheduled before this operation.
                        if (!scheduledJobOperations.IsSupersetOf(precedingJobOperations))
                        {
                            // Opertion is not ready to be scheduled.
                            // Return the operation back to the queue; go to next machine.

                            machineOperationQueue.Value.Enqueue(operation);

                            break;
                        }

                        // Operation is ready to be scheduled.

                        var lastPrecedingOperationFinishTime = precedingJobOperations
                            .Any()
                                ? precedingJobOperations
                                    .Max(operation => scheduledJobOperationsStartTimes[operation] + operation.Duration)
                                : 0;

                        var startTime = Math.Max
                        (
                            machineAvailabilities[machineOperationQueue.Key], 
                            lastPrecedingOperationFinishTime
                        );

                        scheduledJobOperations.Add(operation);

                        scheduledJobOperationsStartTimes[operation] = startTime;

                        machineAvailabilities[machineOperationQueue.Key] = startTime + operation.Duration;
                    }
                }
            }

            return new()
            {
                ScheduledJobOperations = scheduledJobOperationsStartTimes,
                MachineAvailabilities = machineAvailabilities
            };
        }
    }
}
