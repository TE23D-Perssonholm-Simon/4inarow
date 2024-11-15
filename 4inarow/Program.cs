//List<string>[] columns = new List<string>[7];
//List<string>[] columns = [[],[],[],[],[],[],[]];
using System.Transactions;
MatchClass match = new MatchClass();
while (true)
{
    System.Console.WriteLine("Press any key to start game");
    Console.ReadKey();
    Console.Clear();
    match.Match();
    Console.Clear();
}
public class MatchClass
{
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
    //GameLoopen fortsätter förevigt


    public void Match()
    {
        //columns är spelplanen
        columns = [[], [], [], [], [], [], []];
        //mängd brickor
        int tokensAmount = 0;
        //Vilken position spelaren hoverar över
        int playerPos = 0;
        //vilken karaktär spelaren kommer lägga
        string playerChar = "x";
        string xPerson = GenerateName();
        string oPerson = GenerateName();
        Console.CursorVisible = false;
        ConsoleKey input;

        //den här loopen fortsätter tills spelet är över
        while (true)
        {
            Console.Clear();
            GenerateBoard();
            //skriver ut ett x eller o där spelaren befinner sig
            Console.SetCursorPosition(playerPos + 1, 2);
            Console.Write(playerChar);
            //console.readkey(true) gör så att man inte displayar inputen
            input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.A || input == ConsoleKey.LeftArrow)
            {
                //Flytar till närmaste öppna position åt vänster
                playerPos = MoveChar(-1, playerPos);
            }
            if (input == ConsoleKey.D || input == ConsoleKey.RightArrow)
            {
                //Flytar till närmaste öppna position åt höger
                playerPos = MoveChar(1, playerPos);
            }
            if (input == ConsoleKey.Enter)
            {
                //Ska inte kunna lägga till en 
                if (columns[playerPos].Count < 6)
                {
                    columns[playerPos].Add(playerChar);
                    tokensAmount += 1;
                    //FourInARowCheck kollar om det är fyra i rad där man la brickan
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
                    // 42 är totala mängden brickor det kan vara på brädet
                    if (tokensAmount == 42)
                    {
                        Console.SetCursorPosition(9, 0);
                        System.Console.WriteLine($"Draw :I");
                        Console.ReadKey();
                        return;
                    }
                    //Byter spelare
                    playerChar = SwitchChar(playerChar);
                }
            }
            //Flyttar iväg spelaren om raden är full
            if (columns[playerPos].Count() >= 6)
            {
                playerPos = MoveChar(1, playerPos);
            }

        }
    }
    //Byter playerChar från x till o eller från o till x
    string SwitchChar(string playerChar)
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
    //Flyttar playerPos till förstiga lediga plats åt riktningen
    int MoveChar(int direction, int playerPos)
    {
        playerPos += direction;
        //Fortsätter tills den hittar en ledig plats loopar inte förevigt pågrund av att start positionen alltid är ledig
        while (true)
        {
            //om den är utanför max storleken går den till andra sidan 
            if (playerPos > 6)
            {
                playerPos = 0;

            }
            if (playerPos < 0)
            {
                playerPos = 6;
            }
            //om den är i en full column går den till nästa
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
    //skriver ut innehållet av brädet och gränsen runt om
    void GenerateBoard()
    {
        Console.SetCursorPosition(0, 0);
        System.Console.WriteLine(border);
        //skriver utt värdet på columns på skärmen
        for (int i = 0; i < columns.Count(); i++)
        {
            for (int j = columns[i].Count - 1; j >= 0; j--)
            {
                Console.SetCursorPosition(i + 1, 7 - j);
                Console.Write(columns[i][j]);
            }
        }
    }
    //Logiken för att göre ett namn mellan 1-10 karaktärer
    string GenerateName()
    {
        string returnString;
        System.Console.WriteLine("Write a name between 1-10 characters");
        returnString = Console.ReadLine();
        //fortsätter till det blir ett ok namn
        while (returnString == "" || returnString.Length > 10)
        {
            System.Console.WriteLine("You did not follow da rules");
            returnString = Console.ReadLine();
        }
        return returnString;

    }
    //kollar om det är fyra i rad vid en spesifik position
    bool FourInARowCheck(int xPos, string character)
    {
        int yPos = columns[xPos].Count() - 1;
        //gör en directioncheck åt halva hållen pga att directioncheck vänder.
        if (DirectionCheck(xPos, yPos, character, 0, 1))
        {
            return true;
        }
        if (DirectionCheck(xPos, yPos, character, 1, 1))
        {
            return true;
        }
        if (DirectionCheck(xPos, yPos, character, 1, 0))
        {
            return true;
        }
        if (DirectionCheck(xPos, yPos, character, 1, -1))
        {
            return true;
        }
        return false;


    }
    //Kollar om det finns en fyra i rad åt ett vist håll
    bool DirectionCheck(int xPos, int yPos, string character, int xChange, int yChange)
    {
        int count = 0;
        int currentXPos = xPos;
        int currentYPos = yPos;
        //fortsätter kolla åt en riktning tills kordinaten är utanför brädet eller inte innehåller bokstaven
        while (CheckCordinate(currentXPos, currentYPos, character))
        {
            currentXPos += xChange;
            currentYPos += yChange;
            count++;
        }
        currentXPos = xPos;
        currentYPos = yPos;
        //Gör samma som förra men åt andra hålet
        while (CheckCordinate(currentXPos, currentYPos, character))
        {
            currentXPos -= xChange;
            currentYPos -= yChange;
            count++;
        }
        //count ska vara mer eller lika med fem på grund av att start värdet räknas två gånger
        if (count >= 5)
        {
            return true;
        }
        return false;


    }
    //Kollar om en kordinat är innuti brädet och är lika med bokstaven
    bool CheckCordinate(int xPos, int yPos, string character)
    {
        if (xPos < columns.Count() && xPos >= 0)
        {
            if (columns[xPos].Count > yPos && yPos >= 0)
            {
                if (columns[xPos][yPos] == character)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
