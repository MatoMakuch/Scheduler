using CyberFab.Automation.Scheduler.Net8;
using CyberFab.Automation.Scheduler.Net8.Models;

namespace CyberFab.Automation.Test.Scheduler.Net8
{
    [TestClass]
    public class BruteForceSchedulingAlgorithmTest
    {
        [TestMethod]
        public void Test_BruteForceSchedulingAlgorithm_3()
        {
            #region Arrange

            Tests.Test1 test1 = Tests.Test1_Arrange();

            #endregion

            #region Act

            Schedule? schedule =
                new BruteForceSchedulingAlgorithm()
                    .Schedule(test1.SchedulableJobs);

            #endregion

            #region Assert

            Assert.IsTrue(schedule.HasValue);
            Assert.IsTrue(Utils.CompareStartTimes(schedule.Value.ScheduledJobOperations, test1.ExpectedStartTimes));

            #endregion
        }
    }
}