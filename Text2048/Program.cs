
string warningMessage = "";

int[,] grid = new int[4, 4];

StartGame();

void StartGame()
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            grid[i, j] = 0;
        }
    }

    bool quit = false;

    while (!quit)
    {
        UpdateDisplay();
        HandleInput();
    }
}

void UpdateDisplay()
{
    Console.Clear();

    for (int i = 0; i < grid.GetLength(0); i++)
    {
        Console.Write("[    ");
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            if (j == grid.GetLength(1) - 1)
                Console.Write(grid[i, j] == 0 ? "--" : grid[i, j]);
            else
                Console.Write(grid[i, j] == 0 ? "--".PadRight(6) : grid[i, j].ToString().PadRight(6));
        }
        Console.Write("    ]");
        Console.WriteLine();
    }

    if (warningMessage != "")
    {
        Console.WriteLine();
        Console.WriteLine(warningMessage);
            
        warningMessage = "";
    }
}

bool HandleInput()
{
    var ch = Console.ReadKey(true).Key;

    switch (ch)
    {
        case ConsoleKey.UpArrow:
            break;
        case ConsoleKey.LeftArrow:
            break;
        case ConsoleKey.RightArrow:
            break;
        case ConsoleKey.DownArrow:
            break;
        //Restart the game
        case ConsoleKey.R:
            Console.WriteLine("Restarting");
            break;
        //Quit the application
        case ConsoleKey.Q:
            Environment.Exit(0);
            break;
        //Any other key war pressed
        default:
            warningMessage = "That key was not valid. Please press any arrow key, WASD, (q)uit, or (r)estart.";

            return false;
    }

    return true;
}