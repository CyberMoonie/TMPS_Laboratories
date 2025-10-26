using CreationalPatterns.Models;

namespace CreationalPatterns.Domain
{
    public class CharacterBuilder
    {
        private Character _character;

        public CharacterBuilder()
        {
            _character = new Character();
        }

        public CharacterBuilder SetName(string name)
        {
            _character.Name = name;
            return this;
        }

        public CharacterBuilder SetClass(string characterClass)
        {
            _character.Class = characterClass;
            return this;
        }

        public CharacterBuilder SetHealth(int health)
        {
            _character.Health = health;
            return this;
        }

        public CharacterBuilder SetMana(int mana)
        {
            _character.Mana = mana;
            return this;
        }

        public CharacterBuilder SetWeapon(string weapon)
        {
            _character.Weapon = weapon;
            return this;
        }

        public CharacterBuilder SetArmor(string armor)
        {
            _character.Armor = armor;
            return this;
        }

        public CharacterBuilder SetAccessory(string accessory)
        {
            _character.Accessory = accessory;
            return this;
        }

        public Character Build()
        {
            return _character;
        }

        public void Reset()
        {
            _character = new Character();
        }
    }
}
