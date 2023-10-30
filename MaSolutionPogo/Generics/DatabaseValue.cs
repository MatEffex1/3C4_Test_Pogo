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
            Database = new List<T> { value };
        }

        public void Revert()
        {
            // S'il y a plus d'une valeur dans la liste de Values,
            if (Database.Count > 1)
            {
                if (Previous != null)
                {
                    Current = Previous;
                }
            }
        }

        public void Save()
        {
            Previous = Current;
        }



        public static implicit operator T(DatabaseValue<T> databaseValue)
        {
            return databaseValue.Current;
        }

        public static implicit operator List<T>(DatabaseValue<T> databaseValue)
        {
            return databaseValue.Database;
        }



        public List<T> Database { get; set; }
        public T Current
        {
            // Retourne le dernier élément de la liste Values
            get { return Database.Last(); }
            // 
            set
            {
                Save();
                Database.Add(value);
            }
        }

        public T? Previous;
    }
}
