// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string warningMessage = "";

int[,] grid = new int[4, 4];

StartGame();

void StartGame()
{
    bool quit = false;

    while (!quit)
    {
        UpdateDisplay();
        HandleInput();
    }
}

void UpdateDisplay()
{

}

bool HandleInput()
{
    var ch = Console.ReadKey(false).Key;

    switch (ch)
    {
        case ConsoleKey.UpArrow:
            Console.WriteLine("Up");
            break;
        case ConsoleKey.LeftArrow:
            Console.WriteLine("Left");
            break;
        case ConsoleKey.RightArrow:
            Console.WriteLine("Right");
            break;
        case ConsoleKey.DownArrow:
            Console.WriteLine("Down");
            break;
        case ConsoleKey.R:
            //Restart the game
            Console.WriteLine("Restarting");
            break;
        case ConsoleKey.Q:
            //Quit the application
            Environment.Exit(0);
            break;
        default:
            warningMessage = "";

            return false;
    }

    return true;
}