//List<string>[] columns = new List<string>[7];
//List<string>[] columns = [[],[],[],[],[],[],[]];
List<string>[] columns = [["x"],["x"],["x"],[""],["o"],["x"],[]];
try{
while(true){
    Console.Clear();
    for(int i = 0; i < columns.Count(); i++){
        int g = 0;
        for(int j = columns[i].Count - 1; j >= 0; j--){
            Console.SetCursorPosition(i+3,9-g);
            Console.Write(columns[i][j]);
        }
    }
    Console.ReadLine();
    
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