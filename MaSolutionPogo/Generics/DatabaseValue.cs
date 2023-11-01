using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    // Classe
    internal class DatabaseValue<T>
    {
        // Constructor
        public DatabaseValue(T value)
        {
            // Crée une nouvelle liste et y assigne la value pour la propriété Value
            Values = new List<T> { value };
        }

        public void Revert()
        {
            // S'il y a plus d'une valeur dans la liste de Values,
            if (Values.Count > 1)
            {
                if (Database != null)
                {
                    Current = Database;
                }
            }
        }

        public void Save()
        {
            Database = Current;
        }



        public static implicit operator T(DatabaseValue<T> databaseValue)
        {
            return databaseValue.Current;
        }

        public static implicit operator List<T>(DatabaseValue<T> databaseValue)
        {
            return databaseValue.Values;
        }



        public List<T> Values { get; set; }
        public T Current
        {
            // Retourne le dernier élément de la liste Values
            get { return Values.Last(); }
            // 
            set
            {
                Save();
                Values.Add(value);
            }
        }

        public T? Database;
    }
}
