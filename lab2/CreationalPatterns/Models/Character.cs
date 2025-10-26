namespace CreationalPatterns.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public string Weapon { get; set; }
        public string Armor { get; set; }
        public string Accessory { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n=== Character Info ===");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Weapon: {Weapon}");
            Console.WriteLine($"Armor: {Armor}");
            Console.WriteLine($"Accessory: {Accessory}");
            Console.WriteLine($"====================\n");
        }
    }
}
