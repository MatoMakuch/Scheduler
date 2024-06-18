using CyberFab.Utils.Enumerators.Net8;

namespace CyberFab.Utils.Test.Enumerators.Net8
{
    [TestClass]
    public class CartesianProductEnumeratorTest
    {
        [TestMethod]
        public void Test_CartesianProduct_3x2()
        {
            List<List<char>> input =
            [
                ['1', '2'],
                ['a', 'b'],
                ['A', 'B']
            ];

            List<List<int>> expected =
            [
                ['1', 'a', 'A'],
                ['1', 'a', 'B'],
                ['1', 'b', 'A'],
                ['1', 'b', 'B'],
                ['2', 'a', 'A'],
                ['2', 'a', 'B'],
                ['2', 'b', 'A'],
                ['2', 'b', 'B']
            ];

            var actual = new List<List<int>>();
            foreach (var combination in new CartesianProductEnumerator<char>(input))
            {
                actual.Add([.. combination]);
            }

            Assert.IsTrue(Utils.AreListsEqual(expected, actual));
        }

        [TestMethod]
        public void Test_CartesianProduct_EnumerableRange_2x2()
        {
            List<List<int>> input =
            [
                Enumerable.Range(1, 2).ToList(),
                Enumerable.Range(1, 2).ToList()
            ];

            List<List<int>> expected =
            [
                [1, 1],
                [1, 2],
                [2, 1],
                [2, 2]
            ];

            var actual = new List<List<int>>();
            foreach (var combination in new CartesianProductEnumerator<int>(input))
            {
                actual.Add([.. combination]);
            }

            Assert.IsTrue(Utils.AreListsEqual(expected, actual));
        }
    }
}
