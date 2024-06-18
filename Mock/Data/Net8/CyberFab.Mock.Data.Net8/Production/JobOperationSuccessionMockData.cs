using CyberFab.Database.Production.Models.Net8;
using Machine = CyberFab.Database.Production.Models.Net8.Machine;

namespace CyberFab.Mock.Data.Net8.Production
{
    public static class JobOperationSuccessionMockData
    {
        public static IEnumerable<JobOperationSuccession> GetJobOperationSuccessions(
                IEnumerable<Job>? jobs = null, 
                IEnumerable<Machine>? machines = null, 
                IEnumerable<JobOperation>? jobOperations = null)
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

            jobOperations ??= JobOperationMockData.GetJobOperations();

            JobOperation operation11 = jobOperations.First(j => j.JobId == job1.Id && j.MachineSerialNumber == cuttingMachine.SerialNumber);
            JobOperation operation12 = jobOperations.First(j => j.JobId == job1.Id && j.MachineSerialNumber == drillingMachine.SerialNumber);
            JobOperation operation13 = jobOperations.First(j => j.JobId == job1.Id && j.MachineSerialNumber == bendingMachine.SerialNumber);
            JobOperation operation21 = jobOperations.First(j => j.JobId == job2.Id && j.MachineSerialNumber == cuttingMachine.SerialNumber);
            JobOperation operation22 = jobOperations.First(j => j.JobId == job2.Id && j.MachineSerialNumber == drillingMachine.SerialNumber);
            JobOperation operation31 = jobOperations.First(j => j.JobId == job3.Id && j.MachineSerialNumber == cuttingMachine.SerialNumber);

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
                succession112,
                succession123,
                succession212
            ];
        }
    }
}
