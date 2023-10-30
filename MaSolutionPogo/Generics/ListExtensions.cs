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
            // Pour chaque élément 'i' de la liste,
            for (int i = 0; i < list.Count; ++i)
            {
                // Pour chaque élément 'j' de la liste en partant du dernier jusqu'à 1 élément après i,
                for (int j = list.Count - 1; j >= i + 1; --j)
                {
                    // Si les éléments sont égaux, l'enlève de la liste
                    if (list[j].Equals(list[i]))
                    {
                        list.RemoveAt(j);
                    }
                }
            }
        }
    }
}
