using CyberFab.Automation.Scheduler.Net8.Models;
using CyberFab.Database.Production.Models.Net8;
using CyberFab.Mock.Data.Net8.Production;
using CyberFab.Utils.Graph.Net8;
using CyberFab.Utils.Structures.Net8;

namespace CyberFab.Automation.Test.Scheduler.Net8
{
    public static class Tests
    {
        public readonly struct Test1
        {
            public SchedulableJob SchedulableJob1 { get; init; }
            public SchedulableJob SchedulableJob2 { get; init; }
            public SchedulableJob SchedulableJob3 { get; init; }

            public SchedulableMachine SchedulableCuttingMachine { get; init; }
            public SchedulableMachine SchedulableDrillingMachine { get; init; }
            public SchedulableMachine SchedulableBendingMachine { get; init; }
            public SchedulableMachine SchedulableAssemblingMachine { get; init; }

            public SchedulableJobOperation SchedulableOperation11 { get; init; }
            public SchedulableJobOperation SchedulableOperation12 { get; init; }
            public SchedulableJobOperation SchedulableOperation13 { get; init; }
            public SchedulableJobOperation SchedulableOperation21 { get; init; }
            public SchedulableJobOperation SchedulableOperation22 { get; init; }
            public SchedulableJobOperation SchedulableOperation31 { get; init; }

            public IGraph<SchedulableJobOperation, UnitWeight> SchedulableJobOperationGraph1 { get; init; }
            public IGraph<SchedulableJobOperation, UnitWeight> SchedulableJobOperationGraph2 { get; init; }
            public IGraph<SchedulableJobOperation, UnitWeight> SchedulableJobOperationGraph3 { get; init; }

            public IReadOnlySet<SchedulableJob> SchedulableJobs { get; init; }

            public Dictionary<SchedulableJobOperation, int> ExpectedStartTimes { get; init; }
        }

        public static Test1 Test1_Arrange()
        {
            var jobs = JobMockData.GetJobs();
            Job job1 = jobs.First(j => j.Name == "Job000001");
            Job job2 = jobs.First(j => j.Name == "Job000002");
            Job job3 = jobs.First(j => j.Name == "Job000003");

            var machines = MachineMockData.GetMachines();

            Machine cuttingMachine = machines.First(m => m.Name == "CuttingMachine0001");
            Machine drillingMachine = machines.First(m => m.Name == "DrillingMachine0001");
            Machine bendingMachine = machines.First(m => m.Name == "BendingMachine0001");
            Machine assemblingMachine = machines.First(m => m.Name == "AssemblingMachine0001");

            var jobOperations = JobOperationMockData.GetJobOperations(jobs);
            JobOperation operation11 = jobOperations.First(j => j.JobId == job1.Id && j.MachineSerialNumber == cuttingMachine.SerialNumber);
            JobOperation operation12 = jobOperations.First(j => j.JobId == job1.Id && j.MachineSerialNumber == drillingMachine.SerialNumber);
            JobOperation operation13 = jobOperations.First(j => j.JobId == job1.Id && j.MachineSerialNumber == bendingMachine.SerialNumber);
            JobOperation operation21 = jobOperations.First(j => j.JobId == job2.Id && j.MachineSerialNumber == cuttingMachine.SerialNumber);
            JobOperation operation22 = jobOperations.First(j => j.JobId == job2.Id && j.MachineSerialNumber == drillingMachine.SerialNumber);
            JobOperation operation31 = jobOperations.First(j => j.JobId == job3.Id && j.MachineSerialNumber == cuttingMachine.SerialNumber);

            // Convert to schedulable objects.

            SchedulableJob schedulableJob1 = new()
            {
                Id = $"{job1.Name}"
            };
            SchedulableJob schedulableJob2 = new()
            {
                Id = $"{job2.Name}"
            };
            SchedulableJob schedulableJob3 = new()
            {
                Id = $"{job3.Name}"
            };

            SchedulableMachine schedulableCuttingMachine = new()
            {
                Id = $"{cuttingMachine.Name}"
            };
            SchedulableMachine schedulableDrillingMachine = new()
            {
                Id = $"{drillingMachine.Name}"
            };
            SchedulableMachine schedulableBendingMachine = new()
            {
                Id = $"{bendingMachine.Name}"
            };
            SchedulableMachine schedulableAssemblingMachine = new()
            {
                Id = $"{assemblingMachine.Name}"
            };

            SchedulableJobOperation schedulableOperation11 = new()
            {
                Job = schedulableJob1,
                Machine = schedulableCuttingMachine,
                Duration = operation11.Duration
            };
            SchedulableJobOperation schedulableOperation12 = new()
            {
                Job = schedulableJob1,
                Machine = schedulableDrillingMachine,
                Duration = operation12.Duration
            };
            SchedulableJobOperation schedulableOperation13 = new()
            {
                Job = schedulableJob1,
                Machine = schedulableBendingMachine,
                Duration = operation13.Duration
            };
            SchedulableJobOperation schedulableOperation21 = new()
            {
                Job = schedulableJob2,
                Machine = schedulableCuttingMachine,
                Duration = operation21.Duration
            };
            SchedulableJobOperation schedulableOperation22 = new()
            {
                Job = schedulableJob2,
                Machine = schedulableDrillingMachine,
                Duration = operation22.Duration
            };
            SchedulableJobOperation schedulableOperation31 = new()
            {
                Job = schedulableJob3,
                Machine = schedulableCuttingMachine,
                Duration = operation31.Duration
            };

            IMatrixFactory<SchedulableJobOperation> matrixFactory =
                new MatrixFactory<SchedulableJobOperation>(MatrixType.BiDirectional);

            IGraphRepresentationFactory<SchedulableJobOperation, UnitWeight> graphRepresentationFactory =
                new GraphRepresentationFactory<SchedulableJobOperation, UnitWeight>(GraphMultiplicity.Simple, matrixFactory);

            IGraph<SchedulableJobOperation, UnitWeight> schedulableJobOperationGraph1 = new DirectedGraph<SchedulableJobOperation, UnitWeight>(
                new HashSet<SchedulableJobOperation>()
                {
                    schedulableOperation11,
                    schedulableOperation12,
                    schedulableOperation13
                },
                new HashSet<IEdge<SchedulableJobOperation, UnitWeight>>()
                {
                    new SimpleEdge<SchedulableJobOperation, UnitWeight>()
                    {
                        Start = schedulableOperation11,
                        End = schedulableOperation12,
                        Weight = new()
                    },
                    new SimpleEdge<SchedulableJobOperation, UnitWeight>()
                    {
                        Start = schedulableOperation12,
                        End = schedulableOperation13,
                        Weight = new()
                    }
                },
                graphRepresentationFactory);
            schedulableJob1.JobOperationGraph = schedulableJobOperationGraph1;

            IGraph<SchedulableJobOperation, UnitWeight> schedulableJobOperationGraph2 = new DirectedGraph<SchedulableJobOperation, UnitWeight>(
                new HashSet<SchedulableJobOperation>()
                {
                    schedulableOperation21,
                    schedulableOperation22
                },
                new HashSet<IEdge<SchedulableJobOperation, UnitWeight>>()
                {
                    new SimpleEdge<SchedulableJobOperation, UnitWeight>()
                    {
                        Start = schedulableOperation21,
                        End = schedulableOperation22,
                        Weight = new()
                    }
                },
                graphRepresentationFactory);
            schedulableJob2.JobOperationGraph = schedulableJobOperationGraph2;

            IGraph<SchedulableJobOperation, UnitWeight> schedulableJobOperationGraph3 = new DirectedGraph<SchedulableJobOperation, UnitWeight>(
                new HashSet<SchedulableJobOperation>()
                {
                    schedulableOperation31
                },
                new HashSet<IEdge<SchedulableJobOperation, UnitWeight>>(),
                graphRepresentationFactory);
            schedulableJob3.JobOperationGraph = schedulableJobOperationGraph3;

            // Operation ID, Start time.
            Dictionary<SchedulableJobOperation, int> expectedStartTimes = new()
            {
                { schedulableOperation11, 0 },
                { schedulableOperation12, 1 },
                { schedulableOperation13, 2 },
                { schedulableOperation21, 1 },
                { schedulableOperation22, 2 },
                { schedulableOperation31, 2 }
            };

            return new()
            {
                SchedulableJob1 = schedulableJob1,
                SchedulableJob2 = schedulableJob2,
                SchedulableJob3 = schedulableJob3,

                SchedulableCuttingMachine = schedulableCuttingMachine,
                SchedulableDrillingMachine = schedulableDrillingMachine,
                SchedulableBendingMachine = schedulableBendingMachine,
                SchedulableAssemblingMachine = schedulableAssemblingMachine,

                SchedulableOperation11 = schedulableOperation11,
                SchedulableOperation12 = schedulableOperation12,
                SchedulableOperation13 = schedulableOperation13,
                SchedulableOperation21 = schedulableOperation21,
                SchedulableOperation22 = schedulableOperation22,
                SchedulableOperation31 = schedulableOperation31,

                SchedulableJobOperationGraph1 = schedulableJobOperationGraph1,
                SchedulableJobOperationGraph2 = schedulableJobOperationGraph2,
                SchedulableJobOperationGraph3 = schedulableJobOperationGraph3,

                SchedulableJobs = new HashSet<SchedulableJob>()
                {
                    schedulableJob1,
                    schedulableJob2,
                    schedulableJob3
                },

                ExpectedStartTimes = expectedStartTimes
            };
        }
    }
}
