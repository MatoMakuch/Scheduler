using CyberFab.Database.Production.Models.Net8;

namespace CyberFab.Mock.Data.Net8.Production
{
    public static class JobMockData
    {
        public static IEnumerable<Job> GetJobs() =>
        [
            new()
            {
                Id = 1,
                Name = "Job000001"
            },
            new()
            {
                Id = 2,
                Name = "Job000002"
            },
            new()
            {
                Id = 3,
                Name = "Job000003"
            }
        ];
    }
}
