using System.Collections.Generic;

namespace Generics
{
    public static class DictionaryExtensions
    {
        public static void Merge<T>(this Dictionary<int, T> dictionary1, Dictionary<int, T> dictionary2)
        {
            foreach (var key in dictionary2.Keys)
            {
                if (!dictionary1.ContainsKey(key))
                {
                    dictionary1.Add(key, dictionary2[key]);
                }
            }
        }

        public static bool IsEqual(this Dictionary<int, int> dictionary1, Dictionary<int, int> dictionary2)
        {
            // Si le nombre d'éléments n'est pas égal, retourne false
            if (dictionary1.Count != dictionary2.Count)
            {
                return false;
            }

            // Pour chaque paire du dictionaire1,
            foreach (var pair in dictionary1)
            {
                int value;

                // Si la key du dictionaire1 n'est pas présente dans le dictionaire2, retourne false
                // value est updaté avec la value trouvée ou avec 0 (valeur par défaut d'une value int de dictionaire)
                if (!dictionary2.TryGetValue(pair.Key, out value))
                {
                    return false;
                }

                // Si la value du dictionaire1 n'est pas égale à la value du dictionaire2, retourne false
                if (pair.Value != value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
