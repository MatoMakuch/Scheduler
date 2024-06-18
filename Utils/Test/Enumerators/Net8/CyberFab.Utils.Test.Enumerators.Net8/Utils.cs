namespace CyberFab.Utils.Test.Enumerators.Net8
{
    internal class Utils
    {
        internal static bool AreListsEqual(List<List<int>> list1, List<List<int>> list2)
        {
            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].SequenceEqual(list2[i]))
                    return false;
            }

            return true;
        }
    }
}
