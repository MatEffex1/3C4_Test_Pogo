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
    }
}
