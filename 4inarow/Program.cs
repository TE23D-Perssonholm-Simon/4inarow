List<string>[] columns = new List<string>[7];

bool FourInARowCheck(int xpos,string character)
{
    int ypos = columns[xpos].Count() -1;
    

}
bool DirectionCheck(int xpos,int ypos,string character, int xchange, int ychange){
    int Count = 0;
    int currentxpos = xpos;
    int currentypos = ypos;
    while(CheckCordinate(xpos,ypos,character)){
        currentxpos += xchange;
        currentypos += ychange;
        Count++;
    }
    currentxpos = xpos;
    currentypos = ypos;
    while(CheckCordinate(xpos,ypos,character)){
        currentxpos -= xchange;
        currentypos -= ychange;
        Count++;
    }
    if(Count >= 5){
        return true;
    }
    return false;
    

}

bool CheckCordinate(int xpos, int ypos,string character){
    if(xpos > columns.Count()){
        if(columns[xpos].Count > ypos){
            if(columns[xpos][ypos] == character){
                return true;
            }
        }
    }
    return false;
}