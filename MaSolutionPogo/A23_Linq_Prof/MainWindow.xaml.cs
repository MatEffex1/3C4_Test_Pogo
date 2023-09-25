using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
// Écrire une commande Linq (ex: dataList.Max() et faire Ctrl+. Enter sur le .Max pour importer
using System.Windows;

namespace A23_Linq
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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
            var firstPlayer = App.Players.Values.FirstOrDefault();
            if (firstPlayer == null)
                return;

            var firstPlayerName = firstPlayer.Username;
        }

        private void Exercice02()
        {
            // TODO: Find the name of the character with the highest Id in the characters dictionary.
            if (App.Characters.Count <= 0)
                return;

            var maxId = App.Characters.Keys.Max();
            //var maxId = App.Characters.Values.Max(player => player.Id);
            var character = App.Characters[maxId];
            var characterNameWithMaxId = character.Name;
        }

        private void Exercice03()
        {
            // TODO: Find the average of items in each inventory.
            var averageInventoryItems = App.Inventories.Values.Average(x => x.ItemIds.Count);
        }

        private void Exercice04()
        {
            // TODO: Find the name of the character with the longest name in the characters dictionary.
            var charactersByLongestNameLength = App.Characters.Values.OrderByDescending(x => x.Name.Length);
            var characterWithLongestName = charactersByLongestNameLength.FirstOrDefault();
            if (characterWithLongestName == null)
                return;

            var longestCharacterName = characterWithLongestName.Name;
        }

        private void Exercice05()
        {
            //TODO: Order the players in ascending order of their usernames.
            var charactersByName = App.Characters.Values.OrderBy(x => x.Name);
        }

        private void Exercice06()
        {
            // TODO: Order the players in descending order of their usernames.
            var playersByNameDescending = App.Players.Values.OrderByDescending(x => x.Username);
        }

        private void Exercice07()
        {
            // TODO: Find the players who have the item with Id 101 in their inventory.
            var playersWithItem101 = App.Players.Values
                .Where(player => player.Characters
                .Any(character => character.Inventories
                .Any(inventory => inventory.ItemIds.Contains(101))));
        }

        private void Exercice08()
        {
            // TODO: Find the names of characters owned by "Bob123".
            var playerBob123 = App.Players.Values.FirstOrDefault(x => x.Username == "Bob123");
            if (playerBob123 != null)
            {
                var characters = playerBob123.Characters;
                var characterNames = characters.Select(character => character.Name);
            }
        }

        private void Exercice09()
        {
            // TODO: Find the total number of items in all player inventories.
            var totalItemCountOfAllInventories = App.Inventories.Values.Sum(x => x.ItemIds.Count);
        }

        private void Exercice10()
        {
            // TODO: Find the usernames of players who own at least one item in their inventories.
            var playersWithAtLeastOneItem = App.Players.Values
                .Where(x => x.Characters
                .Any(character => character.Inventories
                .Any(x => x.ItemIds.Count > 0)));
        }

        private void Exercice11()
        {
            // TODO: Find the distinct character names across all players.
            var distinctCharacterNames = App.Characters.Values
                .Select(x => x.Name)
                .Distinct();
        }

        private void Exercice12()
        {
            // TODO: Order the players by the total number of items in their inventories in descending order.
            var playersByInventoryItemCount = App.Players.Values
                .OrderByDescending(player => player.Characters
                .Sum(character => character.Inventories
                .Sum(inventory => inventory.ItemIds.Count)));
        }

        private void Exercice13()
        {
            // TODO: Find the player who owns the most items in their inventories.
            if (App.Players.Values.Count <= 0)
                return;

            var playersByInventoryItemCount = App.Players.Values
                .OrderByDescending(player => player.Characters
                .Sum(character => character.Inventories
                .Sum(inventory => inventory.ItemIds.Count)));

            var playerWithMostItems = playersByInventoryItemCount.FirstOrDefault();
        }

        private void Exercice14()
        {
            // TODO: Find the total number of items owned by characters of type "Warrior"
            var inventoryItemCountOwnedByWarriorCharacters = App.Inventories.Values
                .Sum(inventory =>
                (inventory.Character != null
                && inventory.Character.Name == "Warrior")
                ? inventory.ItemIds.Count
                : 0);
        }

        private void Exercice15()
        {
            // TODO: Find the players who own items of type "Sword" and order them by the number of swords they own.
            var playersWithItemSword = App.Players.Values
                .Where(player => player.Characters
                .Any(character => character.Inventories
                .Any(inventory => inventory.Items
                .Any(item => item.Name == "Sword"))));

            var playersWithSwordsBySwordCount = playersWithItemSword
                .OrderByDescending(player => player.Characters
                .Sum(character => character.Inventories
                .Sum(inventory => inventory.Items
                .Count(item => item.Name == "Sword"))));
        }

        private void Exercice16()
        {
            // TODO: Find the total number of distinct items owned by all players
            var distinctItemsOwned = App.Inventories.Values
                .SelectMany(inventory => inventory.ItemIds)
                .Distinct();
        }

        private void Exercice17()
        {
            // TODO: Find the players who own characters of type "Mage" or "Warrior"
            var playersWithCharacterMageOrWarrior = App.Players.Values
               .Where(player => player.Characters
               .Any(character => character.Name == "Mage"
               || character.Name == "Warrior"));
        }

        private void Exercice18()
        {
            // TODO: Find the player with the highest total number of items in their inventories.
            // Oops, same as Exercice13
        }

        private void Exercice19()
        {
            // TODO: Find the total number of players who own a character of type "Mage"
            int playerCountWithCharacterMage = App.Players.Values
               .Count(player => player.Characters
               .Any(character => character.Name == "Mage"));
        }

        private void Exercice20()
        {
            // TODO: Find the players who own more characters than Player "Bob123"
            var playerBob123 = App.Players.Values.FirstOrDefault(x => x.Username == "Bob123");
            if (playerBob123 == null)
                return;

            var playerBob123CharacterCount = playerBob123.Characters.Count();
            var playersWhoOwnMoreCharacters = App.Players.Values
                .Where(player => player != playerBob123
                && player.Characters.Count() > playerBob123CharacterCount);
        }
    }
}
