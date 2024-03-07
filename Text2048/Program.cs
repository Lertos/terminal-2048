
string warningMessage = "";

int[,] grid = new int[4, 4];

StartGame();

void StartGame()
{
    SetupGame();

    bool quit = false;

    while (!quit)
    {
        UpdateDisplay();
        HandleInput();
        InsertTwo();
    }
}

void SetupGame()
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            grid[i, j] = 0;
        }
    }

    //Insert 2 random "2"s
    InsertTwo();
    InsertTwo();
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
        case ConsoleKey.LeftArrow:
            UpdateGrid(Enums.DIR.LEFT);
            break;
        case ConsoleKey.UpArrow:
            UpdateGrid(Enums.DIR.UP);
            break;
        case ConsoleKey.RightArrow:
            UpdateGrid(Enums.DIR.RIGHT);
            break;
        case ConsoleKey.DownArrow:
            UpdateGrid(Enums.DIR.DOWN);
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

void UpdateGrid(Enums.DIR direction)
{
    switch (direction)
    {
        case Enums.DIR.LEFT: HandleLeftMove(); break;
        case Enums.DIR.UP: HandleUpMove(); break;
        case Enums.DIR.RIGHT: HandleRightMove(); break;
        case Enums.DIR.DOWN: HandleDownMove(); break;
    }

    //TODO: Check for win/loss
}

void HandleLeftMove()
{
    
}

void HandleUpMove()
{

}

void HandleRightMove()
{

}

void HandleDownMove()
{

}

void InsertTwo()
{
    //TODO: Create a list and store all of the tuples of "0" cells.
    //  Then make a random number and pick that cell from the list and update the value to two.
}