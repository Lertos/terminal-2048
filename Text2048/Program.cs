
bool gameOver;
bool checkGameOver;
string warningMessage = "";

int[,] grid = new int[4, 4];

StartGame();

void StartGame()
{
    SetupGame();

    bool quit = false;

    gameOver = false;
    checkGameOver = false;

    while (!quit)
    {
        UpdateDisplay();
        HandleInput();

        if (!gameOver)
            InsertTwo();
    }
}

void SetupGame()
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
            grid[i, j] = 0;
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

    if (GetEmptyCells().Count == 0)
        CheckGameOver();
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
    List<(int, int)> emptyCells = GetEmptyCells();

    if (emptyCells.Count == 0)
    {
        checkGameOver = true;
        return;
    }

    Random random = new();

    int index = random.Next(0, emptyCells.Count());
    (int, int) cell = emptyCells[index];

    grid[cell.Item1, cell.Item2] = 2;
}

List<(int, int)> GetEmptyCells()
{
    List<(int, int)> emptyCells = new();

    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            if (grid[i, j] == 0)
                emptyCells.Add((i, j));
        }
    }

    return emptyCells;
}

void CheckGameOver()
{


    //Reset the flag
    checkGameOver = false;
}