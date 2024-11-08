//List<string>[] columns = new List<string>[7];
//List<string>[] columns = [[],[],[],[],[],[],[]];
using System.Transactions;
List<string>[] columns = [[], [], [], [], [], [], []];


string border =
@"
#-------#
|       |
|       |
|       |
|       |
|       |
|       |
#-------#";

while (true)
{
    System.Console.WriteLine("Press any key to start game");
    Console.ReadKey();
    Console.Clear();
    Match();
    Console.Clear();
}
void Match()
{
    columns = [[], [], [], [], [], [], []];
    int tokensAmount = 0;
    int playerPos = 0;
    string playerChar = "x";
    string xPerson = GenerateName();

    string oPerson = GenerateName();
    Console.CursorVisible = false;
    ConsoleKey input;
    while (true)
    {
        Console.Clear();
        generateBoard();
        Console.SetCursorPosition(playerPos + 1, 2);
        Console.Write(playerChar);
        input = Console.ReadKey(true).Key;
        if (input == ConsoleKey.A || input == ConsoleKey.LeftArrow)
        {
            playerPos = MoveChar(-1, playerPos);
        }
        if (input == ConsoleKey.D || input == ConsoleKey.RightArrow)
        {
            playerPos = MoveChar(1, playerPos);
        }
        if (input == ConsoleKey.Enter)
        {
            if (columns[playerPos].Count < 6)
            {
                columns[playerPos].Add(playerChar);
                tokensAmount += 1;
                if (FourInARowCheck(playerPos, playerChar))
                {
                    Console.SetCursorPosition(9, 0);
                    if (playerChar == "x")
                    {
                        System.Console.WriteLine($"{xPerson} won");
                        Console.ReadKey();
                        return;
                    }
                    if (playerChar == "o")
                    {
                        System.Console.WriteLine($"{oPerson} won");
                        Console.ReadKey();
                        return;
                    }
                }
                if (tokensAmount == 42)
                {
                    Console.SetCursorPosition(9, 0);
                    System.Console.WriteLine($"Draw :I");
                    Console.ReadKey();
                    return;
                }

                playerChar = switchChar(playerChar);
            }
        }
        if (columns[playerPos].Count() >= 6)
        {
            playerPos = MoveChar(1, playerPos);
        }

    }
}
string switchChar(string playerChar)
{
    if (playerChar == "x")
    {
        playerChar = "o";
    }
    else
    {
        playerChar = "x";
    }
    return playerChar;
}

int MoveChar(int direction, int playerPos)
{
    playerPos += direction;
    while (true)
    {

        if (playerPos > 6 || playerPos < 0)
        {
            playerPos = 6 - playerPos;
        }
        if (columns[playerPos].Count() >= 6)
        {
            playerPos += direction;
        }
        else
        {
            break;
        }
    }
    return playerPos;
}

void generateBoard()
{
    Console.SetCursorPosition(0, 0);
    System.Console.WriteLine(border);
    for (int i = 0; i < columns.Count(); i++)
    {
        for (int j = columns[i].Count - 1; j >= 0; j--)
        {
            Console.SetCursorPosition(i + 1, 7 - j);
            Console.Write(columns[i][j]);
        }
    }
}
string GenerateName()
{
    string returnString;
    System.Console.WriteLine("Write your name between 1-10 characters");
    returnString = Console.ReadLine();
    while (returnString == "" || returnString.Length > 10)
    {
        System.Console.WriteLine("You did not follow da rules");
        returnString = Console.ReadLine();
    }
    return returnString;

}
bool FourInARowCheck(int xpos, string character)
{
    int ypos = columns[xpos].Count() - 1;
    if (DirectionCheck(xpos, ypos, character, 0, 1))
    {
        return true;
    }
    if (DirectionCheck(xpos, ypos, character, 1, 1))
    {
        return true;
    }
    if (DirectionCheck(xpos, ypos, character, 1, 0))
    {
        return true;
    }
    if (DirectionCheck(xpos, ypos, character, 1, -1))
    {
        return true;
    }
    return false;


}
bool DirectionCheck(int xpos, int ypos, string character, int xchange, int ychange)
{
    int Count = 0;
    int currentxpos = xpos;
    int currentypos = ypos;
    while (CheckCordinate(currentxpos, currentypos, character))
    {
        currentxpos += xchange;
        currentypos += ychange;
        Count++;
    }
    currentxpos = xpos;
    currentypos = ypos;
    while (CheckCordinate(currentxpos, currentypos, character))
    {
        currentxpos -= xchange;
        currentypos -= ychange;
        Count++;
    }
    if (Count >= 5)
    {
        return true;
    }
    return false;


}

bool CheckCordinate(int xpos, int ypos, string character)
{
    if (xpos < columns.Count() && xpos >= 0)
    {
        if (columns[xpos].Count > ypos && ypos >= 0)
        {
            if (columns[xpos][ypos] == character)
            {
                return true;
            }
        }
    }
    return false;
}
