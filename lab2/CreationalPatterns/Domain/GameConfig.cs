namespace CreationalPatterns.Domain
{
    public sealed class GameConfig
    {
        private static GameConfig _instance;
        private static readonly object _lock = new object();

        public string GameName { get; private set; }
        public string Version { get; private set; }
        public int MaxPlayers { get; private set; }

        private GameConfig()
        {
            GameName = "Fantasy RPG";
            Version = "1.0.0";
            MaxPlayers = 4;
        }

        public static GameConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new GameConfig();
                        }
                    }
                }
                return _instance;
            }
        }

        public void DisplayConfig()
        {
            Console.WriteLine($"Game: {GameName} v{Version}");
            Console.WriteLine($"Max Players: {MaxPlayers}");
        }
    }
}
