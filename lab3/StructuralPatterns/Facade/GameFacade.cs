namespace StructuralPatterns.Facade;

// Facade that simplifies the complex subsystems
public class GameFacade
{
    private readonly GraphicsEngine _graphics;
    private readonly AudioSystem _audio;
    private readonly InputManager _input;
    private readonly NetworkManager _network;

    public GameFacade()
    {
        _graphics = new GraphicsEngine();
        _audio = new AudioSystem();
        _input = new InputManager();
        _network = new NetworkManager();
    }

    // Simple method that hides complex initialization
    public void StartGame()
    {
        Console.WriteLine("\n[Facade] Starting game - simplified interface");
        _graphics.Initialize();
        _graphics.LoadTextures();
        _audio.Initialize();
        _audio.LoadSounds();
        _input.Initialize();
        _input.DetectControllers();
        _network.Initialize();
        _network.ConnectToServer();
        Console.WriteLine("[Facade] Game started successfully!\n");
    }

    // Simple method for game loop
    public void RunGameFrame()
    {
        _graphics.Render();
        _audio.PlayBackgroundMusic();
    }
}
