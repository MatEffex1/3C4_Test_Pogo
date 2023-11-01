using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace Generics
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Effectuer les exercices suivants
            // Décommenter fonction par fonction les Tests (Ctrl+K,U) et ajouter le code nécessaire 
            Exercice01_Extensions();
            Exercice02_DatabaseValue();
            Exercice03_Calculator();
            Exercice04_MultiStack();

            // À faire au prochain cours
            Exercice05_CustomLinkedList();
            // Bonus, créer une CustomDoubleLinkedList ou chaque Node a un pointeur Next et Previous
        }

        private void Exercice01_Extensions()
        {
            // Créer une class static ListExtensions avec fonction suivantes
            // Test 01 - Swap doit inverser 2 valeurs si elles existent
            {
                var listInt = new List<int>() { 10, 20, 30, 40, 50 };
                listInt.Swap(10, 50);

                Debug.Assert(listInt.Count == 5);
                Debug.Assert(listInt[0] == 50);
                Debug.Assert(listInt[1] == 20);
                Debug.Assert(listInt[2] == 30);
                Debug.Assert(listInt[3] == 40);
                Debug.Assert(listInt[4] == 10);

                // Invalide
                // listInt.Swap(10, "a");

                var listString = new List<string>() { "a", "b", "c", "d" };
                listString.Swap("b", "c");

                Debug.Assert(listString.Count == 4);
                Debug.Assert(listString[0] == "a");
                Debug.Assert(listString[1] == "c");
                Debug.Assert(listString[2] == "b");
                Debug.Assert(listString[3] == "d");

                // Invalide
                // listString.Swap("a", 20);
            }

            // Test 02 - RemoveDuplicates doit converser uniquement la première ocurrence de la valeur
            {
                var listInt = new List<int>() { 10, 20, 10, 10, 30, 20, 10, 10 };
                listInt.RemoveDuplicates();

                Debug.Assert(listInt.Count == 3);
                Debug.Assert(listInt[0] == 10);
                Debug.Assert(listInt[1] == 20);
                Debug.Assert(listInt[2] == 30);

                var listString = new List<string>() { "b", "b", "a", "c", "c", "b", "a" };
                listString.RemoveDuplicates();

                Debug.Assert(listString.Count == 3);
                Debug.Assert(listString[0] == "b");
                Debug.Assert(listString[1] == "a");
                Debug.Assert(listString[2] == "c");
            }

            // Créer une class static DictionaryExtensions avec fonction suivantes
            // Test 03 - Merge doit ajouter au premier Dictionary le contenu du deuxième, si la key n'est pas déjà utilisée
            {
                var dictionaryInt1 = new Dictionary<int, int>() { { 10, 1000 }, { 20, 2000 }, { 30, 3000 } };
                var dictionaryInt2 = new Dictionary<int, int>() { { 40, 4567 }, { 10, 1234 }, { 50, 5678 } };
                dictionaryInt1.Merge(dictionaryInt2);

                Debug.Assert(dictionaryInt1.Count == 5);
                Debug.Assert(dictionaryInt1[10] == 1000);
                Debug.Assert(dictionaryInt1[20] == 2000);
                Debug.Assert(dictionaryInt1[30] == 3000);
                Debug.Assert(dictionaryInt1[40] == 4567);
                Debug.Assert(dictionaryInt1[50] == 5678);
                Debug.Assert(dictionaryInt2.Count == 3);
            }

            // Test 04 - IsEqual doit vérifier que les dictionnaires contiennent les mêmes clés avec les mêmes valeurs
            {
                var dictionaryInt1 = new Dictionary<int, int>() { { 10, 1000 }, { 20, 2000 }, { 30, 3000 } };
                var dictionaryInt2 = new Dictionary<int, int>() { { 10, 1000 }, { 20, 2000 }, { 30, 3000 } };
                var dictionaryInt3 = new Dictionary<int, int>() { { 10, 1000 }, { 20, 2000 } };
                var dictionaryInt4 = new Dictionary<int, int>() { { 10, 1000 }, { 20, 2000 }, { 30, 3000 }, { 40, 4000 } };
                var dictionaryInt5 = new Dictionary<int, int>() { { 10, 2000 }, { 20, 1000 }, { 30, 3000 } };
                var dictionaryInt6 = new Dictionary<int, int>() { { 10, 1000 }, { 20, 2000 }, { 30, 9999 } };

                Debug.Assert(dictionaryInt1.Count == 3);
                Debug.Assert(dictionaryInt2.Count == 3);
                Debug.Assert(dictionaryInt3.Count == 2);
                Debug.Assert(dictionaryInt4.Count == 4);
                Debug.Assert(dictionaryInt5.Count == 3);
                Debug.Assert(dictionaryInt6.Count == 3);

                Debug.Assert(dictionaryInt1.IsEqual(dictionaryInt2));
                Debug.Assert(!dictionaryInt1.IsEqual(dictionaryInt3));
                Debug.Assert(!dictionaryInt1.IsEqual(dictionaryInt4));
                Debug.Assert(!dictionaryInt1.IsEqual(dictionaryInt5));
                Debug.Assert(!dictionaryInt1.IsEqual(dictionaryInt6));
            }
        }

        private void Exercice02_DatabaseValue()
        {
            // Test 01 - Créer class avec generics
            {
                var databaseValueInt = new DatabaseValue<int>(100);
                var databaseValueString = new DatabaseValue<string>("hello");
            }

            // Test 02 - Revert() doit revenir à l'ancienne valeur
            {
                var databaseValueInt = new DatabaseValue<int>(100);

                databaseValueInt.Current = 200;
                databaseValueInt.Revert();

                // Doit revenir à 100
                Debug.Assert(databaseValueInt.Current == 100);

                var databaseValueString = new DatabaseValue<string>("hello");
                databaseValueString.Current = "bye";
                databaseValueString.Revert();

                // Doit revenir à "hello"
                Debug.Assert(databaseValueString.Current == "hello");
            }

            // Test 03 - Save() doit changer la valeur à laquelle revenir
            {
                var databaseValueInt = new DatabaseValue<int>(999);

                databaseValueInt.Current = 7777;
                databaseValueInt.Save();

                databaseValueInt.Current = 8888;
                databaseValueInt.Revert();

                // Doit revenir à 7777
                Debug.Assert(databaseValueInt.Current == 7777);

                var databaseValueString = new DatabaseValue<string>("pogo");

                databaseValueString.Current = "poutine";
                databaseValueString.Save();

                databaseValueString.Current = "patate";
                databaseValueString.Revert();

                // Doit revenir à "poutine"
                Debug.Assert(databaseValueString.Current == "poutine");
            }

            // Test 04 - Ajouter un opérateur de conversion implicite
            {
                var databaseValueInt = new DatabaseValue<int>(100);
                var databaseValueString = new DatabaseValue<string>("allo");

                Debug.Assert(databaseValueInt == databaseValueInt.Current);
                Debug.Assert(databaseValueString == databaseValueString.Current);

                databaseValueInt.Current = 200;
                Debug.Assert(databaseValueInt != databaseValueInt.Database);

                databaseValueString.Current = "bye";
                Debug.Assert(databaseValueString != databaseValueString.Database);
            }
        }

        private void Exercice03_Calculator()
        {
            // Test 01 - Créer classe avec generics seulement pour les nombres
            {
                var calculatorInt = new Calculator<int>();
                var calculatorByte = new Calculator<byte>();

                var calculatorInt2 = new Calculator<int>(100);
                var calculatorByte2 = new Calculator<byte>(16);

                // Ne doit pas être valide
                //var calculatorBool = new Calculator<bool>();

                // Ne doit pas être valide
                //var calculatorApp = new Calculator<App>();
            }

            // Test 02 - Ajouter les opérations de base
            // Truc : Ajouter des contraintes I...Operators sur le type generics
            // ex. IAdditionOperators force l'existance des opérateurs +
            //     ISubtractOperators force l'existance des opérateurs -, etc.
            {
                var calculatorInt = new Calculator<int>(100);
                Debug.Assert(calculatorInt.Result == 100);

                calculatorInt.Add(10);
                Debug.Assert(calculatorInt.Result == (100 + 10));

                calculatorInt.Subtract(20);
                Debug.Assert(calculatorInt.Result == (100 + 10 - 20));

                calculatorInt.Multiply(4);
                Debug.Assert(calculatorInt.Result == (100 + 10 - 20) * 4);

                calculatorInt.Divide(2);
                Debug.Assert(calculatorInt.Result == (100 + 10 - 20) * 4 / 2);
            }

            // Test 03 - Ajouter les surchages d'opérateurs +, -, *, /
            //{
            //    var calculatorInt = new Calculator<int>(100);
            //    Debug.Assert(calculatorInt.Result == 100);

            //    calculatorInt += 10;
            //    Debug.Assert(calculatorInt.Result == (100 + 10));

            //    calculatorInt -= 20;
            //    Debug.Assert(calculatorInt.Result == (100 + 10 - 20));

            //    calculatorInt *= 4;
            //    Debug.Assert(calculatorInt.Result == (100 + 10 - 20) * 4);

            //    calculatorInt /= 2;
            //    Debug.Assert(calculatorInt.Result == (100 + 10 - 20) * 4 / 2);
            //}

            // Test 04 - Permettre les opérations en chaîne
            // Truc : Retourner l'objet lui-même comme valeur de retour des fonctions
            //{
            //    var calculatorInt = new Calculator<int>(100);
            //    Debug.Assert(calculatorInt.Result == 100);

            //    calculatorInt
            //        .Add(10)
            //        .Subtract(20)
            //        .Multiply(4)
            //        .Divide(2);

            //    Debug.Assert(calculatorInt.Result == (100 + 10 - 20) * 4 / 2);
            //}

            //// Test 05 - Ajouter la conversion implicite
            //{
            //    var calculatorInt = new Calculator<int>(100);
            //    Debug.Assert(calculatorInt == calculatorInt.Result);
            //}
        }

        private void Exercice04_MultiStack()
        {
            //// Test 01 - Créer classe avec generics avec une Valeur et un type de Collection
            //{
            //    var multiStackListInt = new MultiStack<int, List<int>>();
            //    var multiStackCollectionInt = new MultiStack<int, ICollection<int>>();

            //    var multiStackListApp = new MultiStack<App, List<App>>();
            //    var multiStackApp = new MultiStack<App, ICollection<App>>();

            //    // Ne doit pas être valide, Collection doit contenir le même type que la valeur
            //    //var multiStackIntError = new MultiStack<int, List<App>>();
            //    //var multiStackAppError = new MultiStack<App, List<int>>();
            //}

            //// Test 02 - Doit pouvoir ajouter/supprimer différents types de données
            //{
            //    var multiStackInt = new MultiStack<int, ICollection<int>>();

            //    var list1 = new List<int>();
            //    var list2 = new List<int>();
            //    var hashSet = new HashSet<int>();
            //    var sortedSet = new SortedSet<int>();

            //    Debug.Assert(multiStackInt.StackCount == 0);

            //    multiStackInt.Add(list1);
            //    multiStackInt.Add(list2);
            //    multiStackInt.Add(hashSet);
            //    multiStackInt.Add(sortedSet);

            //    Debug.Assert(multiStackInt.StackCount == 4);

            //    multiStackInt.Remove(list1);
            //    multiStackInt.Remove(hashSet);

            //    Debug.Assert(multiStackInt.StackCount == 2);

            //    multiStackInt.Remove(list2);
            //    multiStackInt.Remove(sortedSet);

            //    Debug.Assert(multiStackInt.StackCount == 0);
            //}

            //// Test 03 - Pop() doit trouver la stack avec le plus d'éléments, retire le dernier élément et le renvoyer
            //{
            //    var multiStackInt = new MultiStack<int, ICollection<int>>();

            //    var list1 = new List<int>() { 10 };
            //    var list2 = new List<int>() { 20, 30, 40 };
            //    var list3 = new List<int>() { 50, 60 };

            //    multiStackInt.Add(list1);
            //    multiStackInt.Add(list2);
            //    multiStackInt.Add(list3);

            //    Debug.Assert(multiStackInt.Pop() == 40);
            //    Debug.Assert(multiStackInt.Pop() == 30);
            //    Debug.Assert(multiStackInt.Pop() == 60);
            //    Debug.Assert(multiStackInt.Pop() == 10);
            //    Debug.Assert(multiStackInt.Pop() == 20);
            //    Debug.Assert(multiStackInt.Pop() == 50);
            //}

            //// Test 04 - Pop() doit créer un nouvel élément sans crasher si tous les stacks sont vides
            //// Truc : Forcer une contrainte pour qu'on puisse créer un nouvel élément
            //{
            //    var multiStackInt = new MultiStack<int, ICollection<int>>();

            //    var list1 = new List<int>() { 10 };
            //    var list2 = new List<int>() { 20 };

            //    multiStackInt.Add(list1);
            //    multiStackInt.Add(list2);

            //    Debug.Assert(multiStackInt.Pop() == 10);
            //    Debug.Assert(multiStackInt.Pop() == 20);
            //    Debug.Assert(multiStackInt.Pop() == default);
            //    Debug.Assert(multiStackInt.Pop() == default);
            //    Debug.Assert(multiStackInt.Pop() == default);
            //}

            //// Test 05 - On doit pouvoir avoir le compte d'éléments total
            //{
            //    var multiStackInt = new MultiStack<int, ICollection<int>>();

            //    var list1 = new List<int>() { 10 };
            //    var list2 = new List<int>() { 20, 30, 40 };
            //    var list3 = new List<int>() { 50, 60 };

            //    multiStackInt.Add(list1);
            //    multiStackInt.Add(list2);
            //    multiStackInt.Add(list3);

            //    Debug.Assert(multiStackInt.Count == 6);

            //    multiStackInt.Pop();
            //    Debug.Assert(multiStackInt.Count == 5);

            //    multiStackInt.Pop();
            //    multiStackInt.Pop();
            //    multiStackInt.Pop();
            //    multiStackInt.Pop();
            //    multiStackInt.Pop();
            //    Debug.Assert(multiStackInt.Count == 0);

            //    multiStackInt.Pop();
            //    multiStackInt.Pop();
            //    multiStackInt.Pop();
            //    Debug.Assert(multiStackInt.Count == 0);
            //}
        }

        private void Exercice05_CustomLinkedList()
        {
            //// Test 01 - Créer classe avec generics et une sous classe pour chaque noeud de la liste
            //{
            //    var linkedListInt = new CustomLinkedList<int>();
            //    var linkedListString = new CustomLinkedList<string>();
            //    var linkedListApp = new CustomLinkedList<App>();

            //    var linkedListIntNode = new CustomLinkedList<int>.Node(100);
            //    var linkedListIntString = new CustomLinkedList<string>.Node("hello");
            //}

            //// Test 02 - Doit pouvoir ajouter des éléments
            //// Conserver le nombre d'éléments et un pointeur vers premier/dernier Node (null lorsque vide)
            //{
            //    var linkedListInt = new CustomLinkedList<int>();

            //    Debug.Assert(linkedListInt.Count == 0);
            //    Debug.Assert(linkedListInt.First == null);
            //    Debug.Assert(linkedListInt.Last == null);

            //    linkedListInt.Add(10);

            //    Debug.Assert(linkedListInt.Count == 1);
            //    Debug.Assert(linkedListInt.First.Value == 10);
            //    Debug.Assert(linkedListInt.First.Next == null);
            //    Debug.Assert(linkedListInt.Last.Value == 10);
            //    Debug.Assert(linkedListInt.Last.Next == null);

            //    linkedListInt.Add(20);

            //    Debug.Assert(linkedListInt.Count == 2);
            //    Debug.Assert(linkedListInt.First.Value == 10);
            //    Debug.Assert(linkedListInt.First.Next == linkedListInt.Last);
            //    Debug.Assert(linkedListInt.Last.Value == 20);
            //    Debug.Assert(linkedListInt.Last.Next == null);

            //    linkedListInt.Add(30);

            //    Debug.Assert(linkedListInt.Count == 3);
            //    Debug.Assert(linkedListInt.First.Value == 10);
            //    Debug.Assert(linkedListInt.First.Next.Value == 20);
            //    Debug.Assert(linkedListInt.First.Next.Next.Value == 30);
            //    Debug.Assert(linkedListInt.First.Value == 10);
            //    Debug.Assert(linkedListInt.Last.Value == 30);
            //}

            //// Test 03 - Doit pouvoir supprimer des éléments
            //// Mettre à jour le nombre d'éléments et les pointeurs vers premier/dernier Node
            //// Mettre à jour les liens entres les Node
            //{
            //    var linkedListInt = new CustomLinkedList<int>();
            //    linkedListInt.Add(10);
            //    linkedListInt.Add(20);
            //    linkedListInt.Add(30);
            //    linkedListInt.Add(40);
            //    linkedListInt.Add(50);

            //    Debug.Assert(linkedListInt.Count == 5);
            //    Debug.Assert(linkedListInt.First.Value == 10);
            //    Debug.Assert(linkedListInt.Last.Value == 50);

            //    // (premier) 10 -­> 20 -> 30 -> 40 -> 50 (dernier)
            //    // (premier) 20 -> 30 -> 40 -> 50 (dernier)
            //    linkedListInt.Remove(10);

            //    Debug.Assert(linkedListInt.Count == 4);
            //    Debug.Assert(linkedListInt.First.Value == 20);
            //    Debug.Assert(linkedListInt.Last.Value == 50);

            //    // (premier) 20 -> 30 -> 40 -> 50 (dernier)
            //    // (premier) 20 -> 40 -> 50 (dernier)
            //    linkedListInt.Remove(30);

            //    Debug.Assert(linkedListInt.Count == 3);
            //    Debug.Assert(linkedListInt.First.Value == 20);
            //    Debug.Assert(linkedListInt.First.Next.Value == 40);
            //    Debug.Assert(linkedListInt.First.Next.Next.Value == 50);
            //    Debug.Assert(linkedListInt.Last.Value == 50);

            //    // (premier) 20 -> 40 -> 50 (dernier)
            //    // (premier) 20 -> 40 (dernier)
            //    linkedListInt.Remove(50);

            //    Debug.Assert(linkedListInt.Count == 2);
            //    Debug.Assert(linkedListInt.First.Value == 20);
            //    Debug.Assert(linkedListInt.First.Next.Value == 40);
            //    Debug.Assert(linkedListInt.Last.Value == 40);

            //    // (premier) 20 -> 40 (dernier)
            //    // (premier) null (dernier)
            //    linkedListInt.Remove(20);
            //    linkedListInt.Remove(40);

            //    Debug.Assert(linkedListInt.Count == 0);
            //    Debug.Assert(linkedListInt.First == null);
            //    Debug.Assert(linkedListInt.Last == null);

            //    linkedListInt.Remove(1);
            //    linkedListInt.Remove(10);

            //    Debug.Assert(linkedListInt.Count == 0);
            //    Debug.Assert(linkedListInt.First == null);
            //    Debug.Assert(linkedListInt.Last == null);
            //}

            //// Test 03 - Doit pouvoir supprimer des éléments
            //// Mettre à jour le nombre d'éléments et les pointeurs vers premier/dernier Node
            //// Mettre à jour les liens entres les Node
            //{
            //    var linkedListInt = new CustomLinkedList<int>();
            //    linkedListInt.Add(10);
            //    linkedListInt.Add(20);
            //    linkedListInt.Add(30);
            //    linkedListInt.Add(40);
            //    linkedListInt.Add(50);

            //    Debug.Assert(linkedListInt.ToString() == "5 Node(s) : 10 -> 20 -> 30 -> 40 -> 50");

            //    linkedListInt.Remove(10);
            //    linkedListInt.Remove(30);
            //    linkedListInt.Remove(50);

            //    Debug.Assert(linkedListInt.ToString() == "2 Node(s) : 20 -> 40");

            //    linkedListInt.Remove(40);

            //    Debug.Assert(linkedListInt.ToString() == "1 Node(s) : 20");

            //    linkedListInt.Remove(20);

            //    Debug.Assert(linkedListInt.ToString() == "0 Node(s) : empty");
            //}
        }
    }
}

