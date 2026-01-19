using CreationalPatterns.Models;

namespace CreationalPatterns.Factory
{
    public abstract class CharacterFactory
    {
        public abstract Character CreateCharacter(string name);
    }

    public class WarriorFactory : CharacterFactory
    {
        public override Character CreateCharacter(string name)
        {
            return new Character
            {
                Name = name,
                Class = "Warrior",
                Health = 150,
                Mana = 50,
                Weapon = "Sword",
                Armor = "Heavy Armor",
                Accessory = "Shield"
            };
        }
    }

    public class MageFactory : CharacterFactory
    {
        public override Character CreateCharacter(string name)
        {
            return new Character
            {
                Name = name,
                Class = "Mage",
                Health = 80,
                Mana = 200,
                Weapon = "Staff",
                Armor = "Robe",
                Accessory = "Magic Ring"
            };
        }
    }

    public class ArcherFactory : CharacterFactory
    {
        public override Character CreateCharacter(string name)
        {
            return new Character
            {
                Name = name,
                Class = "Archer",
                Health = 100,
                Mana = 100,
                Weapon = "Bow",
                Armor = "Leather Armor",
                Accessory = "Quiver"
            };
        }
    }
}
