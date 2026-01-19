using CreationalPatterns.Domain;
using CreationalPatterns.Factory;

namespace CreationalPatterns.Client
{
    public class GameClient
    {
        public void Run()
        {

            DemonstreSingleton();
            DemonstrateFactoryMethod();
            DemonstrateBuilder();
        }

        private void DemonstreSingleton()
        {
            Console.WriteLine("--- PATTERN 1: SINGLETON ---");
            
            var config1 = GameConfig.Instance;
            var config2 = GameConfig.Instance;

            config1.DisplayConfig();
            
            Console.WriteLine($"Same instance? {ReferenceEquals(config1, config2)}");
            Console.WriteLine();
        }

        private void DemonstrateFactoryMethod()
        {
            Console.WriteLine("--- PATTERN 2: FACTORY METHOD ---");

            CharacterFactory warriorFactory = new WarriorFactory();
            var warrior = warriorFactory.CreateCharacter("Aragorn");
            warrior.DisplayInfo();

            CharacterFactory mageFactory = new MageFactory();
            var mage = mageFactory.CreateCharacter("Gandalf");
            mage.DisplayInfo();

            CharacterFactory archerFactory = new ArcherFactory();
            var archer = archerFactory.CreateCharacter("Legolas");
            archer.DisplayInfo();
        }

        private void DemonstrateBuilder()
        {
            Console.WriteLine("--- PATTERN 3: BUILDER ---");

            var builder = new CharacterBuilder();
            
            var customCharacter = builder
                .SetName("Custom Hero")
                .SetClass("Paladin")
                .SetHealth(130)
                .SetMana(120)
                .SetWeapon("Holy Sword")
                .SetArmor("Blessed Armor")
                .SetAccessory("Divine Amulet")
                .Build();

            customCharacter.DisplayInfo();
        }
    }
}
