using CyberFab.Utils.Enumerators.Net8;

namespace CyberFab.Utils.Test.Enumerators.Net8
{
    [TestClass]
    public class PermutationTest
    {
        [TestMethod]
        public void Test_Permutations_3()
        {
            List<List<int>> expected = [
                [ 1, 2, 3 ],
                [ 1, 3, 2 ],
                [ 2, 1, 3 ],
                [ 2, 3, 1 ],
                [ 3, 1, 2 ],
                [ 3, 2, 1 ]
            ];

            List<List<int>> actual = [];
            foreach (var permutation in new PermutationIterator<int>([1, 2, 3]))
            {
                actual.Add([.. permutation]);
            }

            Assert.IsTrue(Utils.AreListsEqual(expected, actual));
        }
    }
}