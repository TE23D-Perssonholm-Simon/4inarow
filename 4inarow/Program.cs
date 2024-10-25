//List<string>[] columns = new List<string>[7];
//List<string>[] columns = [[],[],[],[],[],[],[]];
using System.Transactions;

List<string>[] columns = [["x"],["x"],["x"],[],["o"],["x"],[]];
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
try{
    int playerPos = 0;
    string playerChar = "x";
    Console.CursorVisible = false;
    ConsoleKey input;
while(true){
    Console.Clear();
    Console.SetCursorPosition(0,0);
    System.Console.WriteLine(border);
    for(int i = 0; i < columns.Count(); i++){
        for(int j = columns[i].Count - 1; j >= 0; j--){
            Console.SetCursorPosition(i+1,7-j);
            Console.Write(columns[i][j]);
        }
    }
    Console.SetCursorPosition(playerPos + 1,2);
    Console.Write(playerChar);
    input = Console.ReadKey().Key;
    if(input == ConsoleKey.A || input == ConsoleKey.LeftArrow){
        while(true){
        playerPos--;
        if(playerPos < 0){
            playerPos = 7;
        }
        else if(columns[playerPos].Count() >= 6){
            playerPos--;
        }
        else{
            break;
        }
        }

    }
    if(input == ConsoleKey.D || input == ConsoleKey.RightArrow){
        while(true){
        playerPos++;
        if(playerPos > 6){
            playerPos = -1;
        }
        else if(columns[playerPos].Count() >= 6){
            playerPos++;
        }
        else{
            break;
        }
        }
        
    }
    if(input == ConsoleKey.Enter){
        if(columns[playerPos].Count < 6){
        columns[playerPos].Add(playerChar);
        //checkif4inarow
        //drawcheck
        //switchplayer
        //move if full
        }
    }
    
    
}
}
catch(Exception e){
    System.Console.WriteLine(e);
    Console.ReadLine();
}

bool FourInARowCheck(int xpos,string character)
{
    int ypos = columns[xpos].Count() -1;
    System.Console.WriteLine(xpos);
    System.Console.WriteLine(ypos);
    if(DirectionCheck(xpos, ypos,character,0,1)){
        return true;
    }
    if(DirectionCheck(xpos, ypos,character,1,1)){
        return true;
    }
    if(DirectionCheck(xpos, ypos,character,1,0)){
        return true;
    }
    return false;
    

}
bool DirectionCheck(int xpos,int ypos,string character, int xchange, int ychange){
    int Count = 0;
    int currentxpos = xpos;
    int currentypos = ypos;
    while(CheckCordinate(currentxpos,currentypos,character)){
        currentxpos += xchange;
        currentypos += ychange;
        Count++;
    }
    System.Console.WriteLine(Count);
    currentxpos = xpos;
    currentypos = ypos;
    while(CheckCordinate(currentxpos,currentypos,character)){
        currentxpos -= xchange;
        currentypos -= ychange;
        Count++;
    }
    System.Console.WriteLine(Count);
    if(Count >= 5){
        return true;
    }
    return false;
    

}

bool CheckCordinate(int xpos, int ypos,string character){
    if(xpos < columns.Count() && xpos >= 0){
        if(columns[xpos].Count > ypos && ypos >= 0){
            System.Console.WriteLine("hi");
            if(columns[xpos][ypos] == character){
                return true;
            }
        }
    }
    return false;
}