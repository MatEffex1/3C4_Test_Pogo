using System.Collections.Generic;

namespace Generics
{
    public static class ListExtensions
    {
        public static void Swap<T>(this List<T> list, T nb1, T nb2)
        {
            int idx1 = list.IndexOf(nb1);
            int idx2 = list.IndexOf(nb2);

            list[idx1] = nb2;
            list[idx2] = nb1;
        }

        public static void RemoveDuplicates<T>(this List<T> list)
        {
            var listTemp = list;

            for (int i = 0; i < listTemp.Count; ++i)
            {
                for (int j = i + 1; j < listTemp.Count; ++j)
                {
                    if (listTemp[j].Equals(listTemp[i]))
                    {
                        list.RemoveAt(j);
                    }
                }
            }
        }
    }
}
