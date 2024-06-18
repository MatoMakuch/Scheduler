using CyberFab.Utils.Graph.Net8;

namespace CyberFab.Automation.Scheduler.Net8.Models
{
    public class SchedulableJobOperation : INode, IEquatable<SchedulableJobOperation>
    {
        public required SchedulableJob Job { get; init; }

        public required SchedulableMachine Machine { get; init; }

        private int _startTime;
        public int StartTime 
        {
            get => _startTime;
            set
            {
                _startTime = value;
                IsScheduled = true;
            }
        }

        public required int Duration { get; init; }

        public bool IsScheduled { get; set; }

        public override string ToString()
        {
            return !IsScheduled 
                ? $"{{ Job: {Job.Id}; Machine: {Machine.Id}; Duration: {Duration} }}"
                : $"{{ Job: {Job.Id}; Machine: {Machine.Id}; Start time: {StartTime}; Duration: {Duration} }}";
        }

        public bool Equals(SchedulableJobOperation? other)
        {
            if (other is null)
                return false;

            return Job.Equals(other.Job) &&
                Machine.Equals(other.Machine);
        }

        public override bool Equals(object? obj)
        {
            return obj is SchedulableJobOperation operation && Equals(operation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Job, Machine);
        }
    }
}