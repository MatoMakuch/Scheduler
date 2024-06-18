using CyberFab.Database.Production.Models.Net8;
using Machine = CyberFab.Database.Production.Models.Net8.Machine;

namespace CyberFab.Mock.Data.Net8.Production
{
    public static class JobOperationMockData
    {
        public static IEnumerable<JobOperation> GetJobOperations(IEnumerable<Job>? jobs = null, IEnumerable<Machine>? machines = null)
        {
            jobs ??= JobMockData.GetJobs();

            Job job1 = jobs.First(j => j.Name == "Job000001");
            Job job2 = jobs.First(j => j.Name == "Job000002");
            Job job3 = jobs.First(j => j.Name == "Job000003");

            machines ??= MachineMockData.GetMachines();

            Machine cuttingMachine = machines.First(m => m.Name == "CuttingMachine0001");
            Machine drillingMachine = machines.First(m => m.Name == "DrillingMachine0001");
            Machine bendingMachine = machines.First(m => m.Name == "BendingMachine0001");
            Machine assemblingMachine = machines.First(m => m.Name == "AssemblingMachine0001");

            JobOperation operation11 = new()
            {
                JobId = job1.Id,
                Job = job1,
                MachineSerialNumber = cuttingMachine.SerialNumber,
                Machine = cuttingMachine,
                Duration = 1
            };
            job1.JobOperations.Add(operation11);
            cuttingMachine.JobOperations.Add(operation11);

            JobOperation operation12 = new()
            {
                JobId = job1.Id,
                Job = job1,
                MachineSerialNumber = drillingMachine.SerialNumber,
                Machine = drillingMachine,
                Duration = 1
            };
            job1.JobOperations.Add(operation12);
            drillingMachine.JobOperations.Add(operation12);

            JobOperation operation13 = new()
            {
                JobId = job1.Id,
                Job = job1,
                MachineSerialNumber = bendingMachine.SerialNumber,
                Machine = bendingMachine,
                Duration = 1
            };
            job1.JobOperations.Add(operation13);
            bendingMachine.JobOperations.Add(operation13);

            JobOperation operation21 = new()
            {
                JobId = job2.Id,
                Job = job2,
                MachineSerialNumber = cuttingMachine.SerialNumber,
                Machine = cuttingMachine,
                Duration = 1
            };
            job2.JobOperations.Add(operation21);
            cuttingMachine.JobOperations.Add(operation21);

            JobOperation operation22 = new()
            {
                JobId = job2.Id,
                Job = job2,
                MachineSerialNumber = drillingMachine.SerialNumber,
                Machine = drillingMachine,
                Duration = 1
            };
            job2.JobOperations.Add(operation22);
            drillingMachine.JobOperations.Add(operation22);

            JobOperation operation31 = new()
            {
                JobId = job3.Id,
                Job = job3,
                MachineSerialNumber = cuttingMachine.SerialNumber,
                Machine = cuttingMachine,
                Duration = 1
            };
            job3.JobOperations.Add(operation31);
            cuttingMachine.JobOperations.Add(operation31);

            JobOperationSuccession succession112 = new()
            {
                JobId = job1.Id,
                Job = job1,
                PredcedingJobOperationMachineSerialNumber = operation11.MachineSerialNumber,
                PredcedingJobOperation = operation11,
                SucceedingJobOperationMachineSerialNumber = operation12.MachineSerialNumber,
                SucceedingJobOperation = operation12
            };

            JobOperationSuccession succession123 = new()
            {
                JobId = job1.Id,
                Job = job1,
                PredcedingJobOperationMachineSerialNumber = operation12.MachineSerialNumber,
                PredcedingJobOperation = operation12,
                SucceedingJobOperationMachineSerialNumber = operation13.MachineSerialNumber,
                SucceedingJobOperation = operation13
            };

            JobOperationSuccession succession212 = new()
            {
                JobId = job2.Id,
                Job = job2,
                PredcedingJobOperationMachineSerialNumber = operation21.MachineSerialNumber,
                PredcedingJobOperation = operation21,
                SucceedingJobOperationMachineSerialNumber = operation22.MachineSerialNumber,
                SucceedingJobOperation = operation22
            };

            return
            [
                operation11,
                operation12,
                operation13,
                operation21,
                operation22,
                operation31
            ];
        }
    }
}
