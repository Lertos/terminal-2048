
bool quit;
bool gameOver;
bool lastChance;
bool checkGameOver;

string belowMessage = "";

int[,] grid = new int[4, 4];

StartGame();

void StartGame()
{
    quit = false;
    gameOver = false;
    lastChance = false;
    checkGameOver = false;

    SetupGame();

    bool validInput;

    while (!quit)
    {
        UpdateDisplay();

        validInput = HandleInput();

        if (!gameOver && validInput)
            InsertTwo();
    }

    StartGame();
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
            Console.Write(grid[i, j] == 0 ? "--".PadRight(6) : grid[i, j].ToString().PadRight(6));

        Console.Write("]");
        Console.WriteLine();
    }

    if (belowMessage != "")
    {
        Console.WriteLine();
        Console.WriteLine(belowMessage);
            
        belowMessage = "";
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
            quit = true;
            break;
        //Quit the application
        case ConsoleKey.Q:
            Environment.Exit(0);
            break;
        //Any other key war pressed
        default:
            belowMessage = "That key was not valid. Please press any arrow key, WASD, (q)uit, or (r)estart.";

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

    if (checkGameOver)
        CheckGameOver();
}

void HandleLeftMove()
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        int index = 1; //No need to check index 0 as it cannot move nor combine

        while (index < grid.GetLength(1))
        {
            int currentValue = grid[i, index];

            //Skip empty cells
            if (currentValue == 0) { index++; continue; }

            //Reset the current column so we can move the value around
            grid[i, index] = 0;

            //Iterate over possible slots to move the value to
            int currentCol = index - 1;

            while (currentCol >= 0)
            {
                //Check if the neighbor is empty
                if (grid[i, currentCol] == 0)
                {
                    //If it is empty but is the last slot to move to, just move it
                    if (currentCol == 0)
                    {
                        grid[i, currentCol] = currentValue;
                        break;
                    }
                }
                //If it has a value, can it combine with the value
                else if (currentValue == grid[i, currentCol])
                {
                    grid[i, currentCol] = CombineCells(grid[i, currentCol], currentValue);
                    break;
                }
                //If it can't move nor can combine, just place it in the current column
                else
                {
                    grid[i, currentCol + 1] = currentValue;
                    break;
                }

                currentCol--;
            }

            index++;
        }
    }
}


void HandleUpMove()
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        int index = 1; //No need to check index 0 as it cannot move nor combine

        while (index < grid.GetLength(1))
        {
            int currentValue = grid[index, i];

            //Skip empty cells
            if (currentValue == 0) { index++; continue; }

            //Reset the current column so we can move the value around
            grid[index, i] = 0;

            //Iterate over possible slots to move the value to
            int currentCol = index - 1;

            while (currentCol >= 0)
            {
                //Check if the neighbor is empty
                if (grid[currentCol, i] == 0)
                {
                    //If it is empty but is the last slot to move to, just move it
                    if (currentCol == 0)
                    {
                        grid[currentCol, i] = currentValue;
                        break;
                    }
                }
                //If it has a value, can it combine with the value
                else if (currentValue == grid[currentCol, i])
                {
                    grid[currentCol, i] = CombineCells(grid[currentCol, i], currentValue);
                    break;
                }
                //If it can't move nor can combine, just place it in the current column
                else
                {
                    grid[currentCol + 1, i] = currentValue;
                    break;
                }

                currentCol--;
            }

            index++;
        }
    }
}

void HandleRightMove()
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        int index = grid.GetLength(1) - 2; //No need to check the last index as it cannot move nor combine

        while (index >= 0)
        {
            int currentValue = grid[i, index];

            //Skip empty cells
            if (currentValue == 0) { index--; continue; }

            //Reset the current column so we can move the value around
            grid[i, index] = 0;

            //Iterate over possible slots to move the value to
            int currentCol = index + 1;

            while (currentCol < grid.GetLength(1))
            {
                //Check if the neighbor is empty
                if (grid[i, currentCol] == 0)
                {
                    //If it is empty but is the last slot to move to, just move it
                    if (currentCol == grid.GetLength(1) - 1)
                    {
                        grid[i, currentCol] = currentValue;
                        break;
                    }
                }
                //If it has a value, can it combine with the value
                else if (currentValue == grid[i, currentCol])
                {
                    grid[i, currentCol] = CombineCells(grid[i, currentCol], currentValue);
                    break;
                }
                //If it can't move nor can combine, just place it in the current column
                else
                {
                    grid[i, currentCol - 1] = currentValue;
                    break;
                }

                currentCol++;
            }

            index--;
        }
    }
}

void HandleDownMove()
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        int index = grid.GetLength(1) - 2; //No need to check the last index as it cannot move nor combine

        while (index >= 0)
        {
            int currentValue = grid[index, i];

            //Skip empty cells
            if (currentValue == 0) { index--; continue; }

            //Reset the current column so we can move the value around
            grid[index, i] = 0;

            //Iterate over possible slots to move the value to
            int currentCol = index + 1;

            while (currentCol < grid.GetLength(1))
            {
                //Check if the neighbor is empty
                if (grid[currentCol, i] == 0)
                {
                    //If it is empty but is the last slot to move to, just move it
                    if (currentCol == grid.GetLength(1) - 1)
                    {
                        grid[currentCol, i] = currentValue;
                        break;
                    }
                }
                //If it has a value, can it combine with the value
                else if (currentValue == grid[currentCol, i])
                {
                    grid[currentCol, i] = CombineCells(grid[currentCol, i], currentValue);
                    break;
                }
                //If it can't move nor can combine, just place it in the current column
                else
                {
                    grid[currentCol - 1, i] = currentValue;
                    break;
                }

                currentCol++;
            }

            index--;
        }
    }
}

int CombineCells(int cellValue, int currentValue)
{
    int newValue = currentValue * 2;

    //Check for the win condition
    if (newValue == 2048)
    {
        belowMessage = "---You won---\n\n Press 'r' to start a new game, or 'q' to quit";
        gameOver = true;
    }

    return newValue;
}

void InsertTwo()
{
    List<(int, int)> emptyCells = GetEmptyCells();

    if (emptyCells.Count == 0)
    {
        checkGameOver = true;
        return;
    }
    else if (checkGameOver)
    {
        //Reset the flag
        checkGameOver = false;
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
    //If they already had a full board and still have no empty spaces, they lose
    if (lastChance)
    {
        belowMessage = "---You lost---\n\n Press 'r' to start a new game, or 'q' to quit";
        gameOver = true;
    }
    //When they have no empty spaces, they still have one more try to make a move
    else
    {
        lastChance = true;
    }
}