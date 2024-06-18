using CyberFab.Database.Production.Models.Net8;

namespace CyberFab.Mock.Data.Net8.Production
{
    public static class MachineMockData
    {
        public static IEnumerable<Machine> GetMachines() =>
        [
            new()
            {
                SerialNumber = "0001",
                Name = "CuttingMachine0001"
            },
            new()
            {
                SerialNumber = "0002",
                Name = "CuttingMachine0002"
            },
            new()
            {
                SerialNumber = "0003",
                Name = "DrillingMachine0001"
            },
            new()
            {
                SerialNumber = "0004",
                Name = "BendingMachine0001"
            },
            new()
            {
                SerialNumber = "0005",
                Name = "AssemblingMachine0001"
            }
        ];
    }
}
