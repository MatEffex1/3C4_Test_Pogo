using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace A23_Linq
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Create dictionaries for four classes: Player, Character, Item, and Inventory
        public static Dictionary<int, Player> Players = new Dictionary<int, Player>();

        public static Dictionary<int, Character> Characters = new Dictionary<int, Character>();

        public static Dictionary<int, Item> Items = new Dictionary<int, Item>();

        public static Dictionary<int, Inventory> Inventories = new Dictionary<int, Inventory>();

        public App()
        {
            // Populate the dictionaries with sample data
            Players.Add(1, new Player { Id = 1, Username = "Bob123" });
            Players.Add(2, new Player { Id = 2, Username = "PogoLover" });
            Players.Add(3, new Player { Id = 3, Username = "MagicGuy_QC" });
            Players.Add(4, new Player { Id = 4, Username = "XxX_Slayer_xXx" });

            Characters.Add(101, new Character { Id = 101, PlayerId = 1, Name = "Warrior" });
            Characters.Add(102, new Character { Id = 102, PlayerId = 2, Name = "Mage" });
            Characters.Add(103, new Character { Id = 103, PlayerId = 2, Name = "Warrior" });
            Characters.Add(104, new Character { Id = 104, PlayerId = 3, Name = "Warrior" });
            Characters.Add(105, new Character { Id = 105, PlayerId = 3, Name = "Thief" });
            Characters.Add(106, new Character { Id = 106, PlayerId = 4, Name = "Warrior" });
            Characters.Add(107, new Character { Id = 107, PlayerId = 4, Name = "Warrior" });
            Characters.Add(108, new Character { Id = 108, PlayerId = 2, Name = "Mage" });
            Characters.Add(109, new Character { Id = 109, PlayerId = 2, Name = "Thief" });
            Characters.Add(110, new Character { Id = 110, PlayerId = 3, Name = "Mage" });

            Items.Add(1001, new Item { Id = 1001, Name = "Sword" });
            Items.Add(1002, new Item { Id = 1002, Name = "Staff" });
            Items.Add(1003, new Item { Id = 1003, Name = "Mace of gods" });

            Inventories.Add(10001, new Inventory { Id = 10001, CharacterId = 101, ItemIds = new List<int>() { 1001 } });
            Inventories.Add(10002, new Inventory { Id = 10002, CharacterId = 102, ItemIds = new List<int>() { 1001, 1002 } });
            Inventories.Add(10003, new Inventory { Id = 10003, CharacterId = 102, ItemIds = new List<int>() { 1002, 1002, 1003 } });
            Inventories.Add(10004, new Inventory { Id = 10004, CharacterId = 105, ItemIds = new List<int>() { 1001, 1001 } });
            Inventories.Add(10005, new Inventory { Id = 10005, CharacterId = 101, ItemIds = new List<int>() { } });
            Inventories.Add(10006, new Inventory { Id = 10006, CharacterId = 106, ItemIds = new List<int>() { 1001 } });
            Inventories.Add(10007, new Inventory { Id = 10007, CharacterId = 101, ItemIds = new List<int>() { 1001 } });
            Inventories.Add(10008, new Inventory { Id = 10008, CharacterId = 110, ItemIds = new List<int>() { 1001, 1001 } });
            Inventories.Add(10009, new Inventory { Id = 10009, CharacterId = 101, ItemIds = new List<int>() { } });
            Inventories.Add(10010, new Inventory { Id = 10010, CharacterId = 102, ItemIds = new List<int>() { 1001 } });
        }

        public class Player
        {
            public int Id { get; set; }
            public string Username { get; set; } = "";

            // TODO: Trouver tous les Characters du Player
            public IEnumerable<Character> Characters => null;

            // TODO: Faire un ToString()
            // Player ID_PLAYER - NOM_PLAYER
        }

        public class Character
        {
            public int Id { get; set; }
            public int PlayerId { get; set; }
            public string Name { get; set; } = "";

            // TODO: Trouver le Player à l'aide du PlayerId
            public Player Player => null;

            // TODO: Trouver les Inventory à l'aide du CharacterId
            public IEnumerable<Inventory> Inventories => App.Inventories.Values.Where(x => x.CharacterId == Id);

            // TODO: Faire un ToString()
            // Character ID_CHARACTER - NOM_CHARACTER - Player NOM_DU_PLAYER
        }

        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";

            // TODO: Faire un ToString()
            // Item ID_ITEM - NOM_ITEM
        }

        public class Inventory
        {
            public int Id { get; set; }
            public int CharacterId { get; set; }
            public List<int> ItemIds { get; set; } = new List<int>();

            // TODO: Trouver le Character à l'aide du CharacterId
            public Character Character => null;

            // TODO: Trouver tous les Items de l'inventory
            public IEnumerable<Item> Items => null;

            // TODO: Faire un ToString()
            // Inventory ID_INVENTORY - Character NOM_CHARACTER - Contains NOMBRE_ITEMS items
        }
    }
}
