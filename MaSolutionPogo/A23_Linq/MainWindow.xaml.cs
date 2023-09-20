using System.Collections.Generic;
using System.Linq;
// Écrire une commande Linq (ex: dataList.Max() et faire Ctrl+. Enter sur le .Max pour importer
using System.Windows;
using static A23_Linq.App;

namespace A23_Linq
{
    public class Data
    {
        public int Id;
        public List<int> Numbers = new List<int>();
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Premier avec un Id > 3
            App.Players.FirstOrDefault(KeyValuePair => KeyValuePair.Value.Id > 3);

            Player? player = App.Players.Values.FirstOrDefault(player => player.Id > 3);
            player = App.Players.Values.FirstOrDefault(player => player.Username.Length > 10);

            // Nombre d'inventaires qui ont au moins 1 item
            int count = App.Inventories.Values.Count(x => x.ItemIds.Count > 0);

            IEnumerable<Inventory> inventoriesWithAtLeastOneItem = App.Inventories.Values.Where(x => x.ItemIds.Count > 0);

            foreach (var inventory in inventoriesWithAtLeastOneItem)
            {

            }

            Exercice01();
            Exercice02();
            Exercice03();
            Exercice04();
            Exercice05();
            Exercice06();
            Exercice07();
            Exercice08();
            Exercice09();
            Exercice10();
            Exercice11();
            Exercice12();
            Exercice13();
            Exercice14();
            Exercice15();
            Exercice16();
            Exercice17();
            Exercice18();
            Exercice19();
            Exercice20();
        }

        private void Exercice01()
        {
            // TODO: Find the username of the first player in the players dictionary.

        }

        private void Exercice02()
        {
            // TODO: Find the name of the character with the highest Id in the characters dictionary.
        }

        private void Exercice03()
        {
            // TODO: Find the average of items in each inventory.
        }

        private void Exercice04()
        {
            // TODO: Find the name of the character with the longuest name in the characters dictionary.
        }

        private void Exercice05()
        {
            //TODO: Order the players in ascending order of their usernames.
        }

        private void Exercice06()
        {
            // TODO: Order the players in descending order of their usernames.
        }

        private void Exercice07()
        {
            // TODO: Find the players who have the item with Id 101 in their inventory.
        }

        private void Exercice08()
        {
            // TODO: Find the names of characters owned by "Bob123".
        }

        private void Exercice09()
        {
            // TODO: Find the total number of items in all player inventories.
        }

        private void Exercice10()
        {
            // TODO: Find the usernames of players who own at least one item in their inventories.
        }

        private void Exercice11()
        {
            // TODO: Find the distinct character names across all player inventories.
        }

        private void Exercice12()
        {
            // TODO: Order the players by the total number of items in their inventories in descending order.
        }

        private void Exercice13()
        {
            // TODO: Find the players who have the most items in their inventories.
        }

        private void Exercice14()
        {
            // TODO: Find the total number of items owned by players of type "Warrior."
        }

        private void Exercice15()
        {
            // TODO: Find the players who own items of type "Sword" and order them by the number of swords they own.
        }

        private void Exercice16()
        {
            // TODO: Find the total number of distinct items owned by App.players.
        }

        private void Exercice17()
        {
            // TODO: Find the players who own characters of type "Mage" or "Warrior."
        }

        private void Exercice18()
        {
            // TODO: Find the player with the highest total number of items in their inventories.
        }

        private void Exercice19()
        {
            // TODO: Find the total number of players who own a character of type "Mage."
        }

        private void Exercice20()
        {
            // TODO: Find the players who own more characters than Player "Bob123".
        }
    }
}
