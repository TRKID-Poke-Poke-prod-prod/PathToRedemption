using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using System.Threading;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.Linq.Expressions;
namespace HelloWorld
{
  public enum State{True,False,Undefined}
  public enum Tiles{Wall,Floor,Platform,Roof,Space,Undefined,Flag}
  public class Player{
    public Tiles[] findSurround(string[][] map, int xPos, int yPos){
      Tiles foot = Tiles.Undefined;
      Tiles head = Tiles.Undefined;
      Tiles right = Tiles.Undefined;
      Tiles left = Tiles.Undefined;
      string flag = "▒▒";
      string Red = "[31m";
      string GREEN = "[32m";
      string White = "[37m";
      string Blue = "[34m";
      if (xPos+1<30){// right
        if (map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="  " || map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="<>"){
          right = Tiles.Space;
        }
        if (map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="▐ " || map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="|r" || map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")==" ▌" || map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="l|"){
          right = Tiles.Wall;
        }
        if (map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="▀▀"){
          right = Tiles.Platform;
        }
        if (map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="ˉˉ"){
          right = Tiles.Floor;
        }
        if (map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")==flag){
          right = Tiles.Flag;
        }
        if (map[yPos][xPos+1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="__"){
          right = Tiles.Roof;
        } 
      }
      if (xPos-1>=0){// left
        if (map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="  " || map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="<>"){
          left = Tiles.Space;
        }
        if (map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="▐ " || map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="|r" || map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")==" ▌" || map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="l|"){
          left = Tiles.Wall;
        }
        if (map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="▀▀"){
          left = Tiles.Platform;
        }
        if (map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="ˉˉ"){
          left = Tiles.Floor;
        }
        if (map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")==flag){
          left = Tiles.Flag;
        }
        if (map[yPos][xPos-1].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="__"){
          left = Tiles.Roof;
        } 
      }
      if (yPos+1<30){// foot
        if (map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="  " || map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="<>"){
          foot = Tiles.Space;
        }
        if (map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="▐ " || map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="|r" || map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")==" ▌" || map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="l|"){
          foot = Tiles.Wall;
        }
        if (map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="▀▀"){
          foot = Tiles.Platform;
        }
        if (map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="ˉˉ"){
          foot = Tiles.Floor;
        }
        if (map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")==flag){
          foot = Tiles.Flag;
        }
        if (map[yPos+1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="__"){
          foot = Tiles.Roof;
        } 
      }
      if (yPos-1>=0){// head
        if (map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="  " || map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="<>"){
          head = Tiles.Space;
        }
        if (map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="▐ " || map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="|r" || map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")==" ▌" || map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="l|"){
          head = Tiles.Wall;
        }
        if (map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="▀▀"){
          head = Tiles.Platform;
        }
        if (map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="ˉˉ"){
          head = Tiles.Floor;
        }
        if (map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")==flag){
          head = Tiles.Flag;
        }
        if (map[yPos-1][xPos].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="__"){
          head = Tiles.Roof;
        } 
      }
      return [head,foot,left,right];
    }
  }
  
  public class Map{
    public class Holder{
      public required string[][] Layer {get; set;}
      public required int[][] Collision {get; set;}
    }

    public string[][] changeToAdmin(string[][] input){
      string[][] ins = input;
      string AwallR = "|r";
      string AwallL = "l|";
      string space = "<>";
      string[][] newmap = input;
      for (int Y = 0; Y < input.Length; Y++)
      {
        for (int X = 0; X < input[0].Length; X++)
        {
          if (newmap[Y][X]=="  "){
            newmap[Y][X] = space;
          } 
          if (newmap[Y][X]=="▐ "){
            newmap[Y][X] = AwallR;
          } 
          if (newmap[Y][X]==" ▌"){
            newmap[Y][X] = AwallL;
          } 
          if (newmap[Y][X]=="╞╡"){
            newmap[Y][X] = "[34m"+space+"[37m";
          } 
        }
      }
      return newmap;
    }
    public string[][] changeFromAdmin(string[][] input){
      string[][] ins = input;
      string space = "  ";
      string wallR = "▐ ";
      string wallL = " ▌";
      string player = "╞╡";
      string platform = "▀▀";
      string Red = "[31m";
      string GREEN = "[32m";
      string White = "[37m";
      string Blue = "[34m";
      string[][] newmap = input;
      for (int Y = 0; Y < input.Length; Y++)
      {
        for (int X = 0; X < input[0].Length; X++)
        {
          if (newmap[Y][X].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="<>"){
            newmap[Y][X] = space;
          } 
          else if (newmap[Y][X].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="|r"){
            newmap[Y][X] = wallR;
          } 
          else if (newmap[Y][X].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="l|"){
            newmap[Y][X] = wallL;
          } 
          else if (newmap[Y][X].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="[34m"+space+"[37m"){
            newmap[Y][X] = player;
          } 
          else if (newmap[Y][X].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="[34m"+wallL+"[37m"){
            newmap[Y][X] = player;
          } 
          else if (newmap[Y][X].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="[34m"+wallR+"[37m"){
            newmap[Y][X] = player;
          } 
          else if (newmap[Y][X].Replace(Blue,"").Replace(GREEN,"").Replace(White,"").Replace(Red,"")=="[34m"+platform+"[37m"){
            newmap[Y][X] = player;
          } 
        }
      }
      return newmap;
    }
  }
    class Program
    {
      static void Main(string[] args)
      {
        Map map = new Map();
        Player player = new Player();
        Tiles[] pSurround;
        string createMap(string[] map, int pyPos, int pxPos,State touchingGround, State admin, string cSel, int slot, Tiles[] pSur){
          string[] spSur = new string[]{"","","",""};
          for (int i = 0; i < pSur.Length; i++)
          {
            if (pSur[i] == Tiles.Wall){
              spSur[i] = "W";
            }
            if (pSur[i] == Tiles.Platform){
              spSur[i] = "P";
            }
            if (pSur[i] == Tiles.Space){
              spSur[i] = "S";
            }
            if (pSur[i] == Tiles.Floor){
              spSur[i] = "F";
            }
            if (pSur[i] == Tiles.Roof){
              spSur[i] = "R";
            }
            if (pSur[i] == Tiles.Undefined){
              spSur[i] = "!";
            }
            if (pSur[i] == Tiles.Flag){
              spSur[i] = "V";
            }
          }
          if (admin == State.True){
            return map[0]+"    Press g to select player start point\n"+map[1]+"    Press C to reset map\n"+map[2]+"    Press F to select floor '__'\n"+map[3]+"    Press l to select left wall 'l|'\n"+map[4]+"    Press r to select right wall '|r'\n"+map[5]+"    Press a to select roof '--'\n"+map[6]+"    Press s to select platform '▀▀'\n"+map[7]+"    Press d to select space '  '\n"+map[8]+"    Press H to select flag '֎'\n"+map[9]+"    Current brush: '"+cSel+"'\n"+map[10]+"\n"+map[11]+"    Press space to change the blue object\n"+map[12]+"        to the selected one\n"+map[13]+"    Press  X to save map to Map slot: "+slot+"\n"+map[14]+"    use number keys to change slots\n"+map[15]+"    Press V to load selected map\n"+map[16]+"\n"+map[17]+"\n"+map[18]+"      "+spSur[0]+"\n"+map[19]+"    "+spSur[2]+" O "+spSur[3]+"\n"+map[20]+"      "+spSur[1]+"\n"+map[21]+"\n"+map[22]+"\n"+map[23]+"\n"+map[24]+"\n"+map[25]+"\n"+map[26]+"\n"+map[27]+"\n"+map[28]+"\n"+map[29]+"     X: "+pxPos+"; Y "+pyPos+" touchingGround: "+touchingGround;
          }else{
            return map[0]+"\n"+map[1]+"\n"+map[2]+"      "+spSur[0]+"\n"+map[3]+"    "+spSur[2]+" O "+spSur[3]+"\n"+map[4]+"      "+spSur[1]+"\n"+map[5]+"\n"+map[6]+"\n"+map[7]+"\n"+map[8]+"\n"+map[9]+"\n"+map[10]+"\n"+map[11]+"\n"+map[12]+"\n"+map[13]+"\n"+map[14]+"\n"+map[15]+"\n"+map[16]+"\n"+map[17]+"\n"+map[18]+"\n"+map[19]+"\n"+map[20]+"\n"+map[21]+"\n"+map[22]+"\n"+map[23]+"\n"+map[24]+"\n"+map[25]+"\n"+map[26]+"\n"+map[27]+"\n"+map[28]+"\n"+map[29]+"     X: "+pxPos+"; Y "+pyPos+" touchingGround: "+touchingGround;
          }
        }
        string[] RefreshMap(string [][] layerVar, int pyPos, int pxPos, string player)
          {
              string[] mainMap = new string[]{"","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","","",""};
          
              for (int i = 0; i < 30; i++)
              {
                  mainMap[i] = layerVar[i][0]+layerVar[i][1]+layerVar[i][2]+layerVar[i][3]+layerVar[i][4]+layerVar[i][5]+layerVar[i][6]+layerVar[i][7]+layerVar[i][8]+layerVar[i][9]+layerVar[i][10]+layerVar[i][11]+layerVar[i][12]+layerVar[i][13]+layerVar[i][14]+layerVar[i][15]+layerVar[i][16]+layerVar[i][17]+layerVar[i][18]+layerVar[i][19]+layerVar[i][20]+layerVar[i][21]+layerVar[i][22]+layerVar[i][23]+layerVar[i][24]+layerVar[i][25]+layerVar[i][26]+layerVar[i][27]+layerVar[i][28]+layerVar[i][29];
              }

              string [] temp = new string[] {
                  mainMap[0], mainMap[1], mainMap[2],
                  mainMap[3], mainMap[4], mainMap[5],
                  mainMap[6], mainMap[7], mainMap[8],
                  mainMap[9], mainMap[10], mainMap[11],
                  mainMap[12], mainMap[13], mainMap[14],
                  mainMap[15], mainMap[16], mainMap[17],
                  mainMap[18], mainMap[19], mainMap[20],
                  mainMap[21], mainMap[22], mainMap[23],
                  mainMap[24], mainMap[25], mainMap[26],
                  mainMap[27], mainMap[28], mainMap[29]
              };

              return temp;
          }
        int[][] updateCollision(int[][] collMap, string[][] map){
          int[][] newMap = collMap;
          for (int X = 0; X < map[0].Length; X++)
          {
            for (int Y = 0; Y < map.Length; Y++)
            {
            if(map[Y][X]=="  "){
              collMap[Y][X] = 0;
            } else if (map[Y][X]=="<>"){
              collMap[Y][X] = 0;
            }else{
              collMap[Y][X] = 1;
            }
            }
          }
          return newMap;
        }
        State updateGroundContact(State input, int[][] collMap, int x, int y){
          try
          {
            if (collMap[y+1][x]==1){
              input = State.True;
            }
            else{
              input = State.False;
            }
          }
          catch (System.Exception)
          {
            input = State.Undefined;
            throw;
          }
          return input;
        }
        string floor = "ˉˉ";
        //string roof = "__";
        State True = State.True;
        string wallR = "▐ ";
        string wallL = " ▌";
        int pStartX = 1;
        int pStartY = 1;
        int flagPosX = 1;
        int flagPosY = 1;
        string playerChar = "╞╡";
        string platform = "▀▀";
        string flag = "[32m"+"▒▒"+"[37m";
        string cSel = "<>";
        int saveSlots = 1;
        string dir = Directory.GetCurrentDirectory()+"\\game_data";
        State touchingGround = State.False;
        State admin = State.False;
        int mapsizeX = 30;
        int mapsizeY = 30;
        int pyPos = 0;// work on player movement; done - no collision; done with collision?;
        int pxPos = 1;// work on gravity and collision; Done, With collision
        int OpyPos = 0;
        int OpxPos = 1;
        int pGravity = 200;
        bool holder = true;
        Console.Title = "PathToRedemption";// work on game line; create Finish and start cube
        string[][] mainMap;
        int[][] collisionMap;
        var holder1 = File.ReadAllText(dir+"\\maps\\map1.json");
        Map.Holder jsonMap = JsonSerializer.Deserialize<Map.Holder>(holder1)!;// error showing up under hol telling me i cant convert from string to Newtonsoft.Json
        collisionMap = jsonMap.Collision;
        mainMap = jsonMap.Layer;
        for (int X = 0; X < mainMap[0].Length; X++)
        {
          for (int Y = 0; Y < mainMap.Length; Y++)
          {
            if (mainMap[Y][X] == "|r"){
              mainMap[Y][X] = wallR;
            }
            if (mainMap[Y][X] == "l|"){
              mainMap[Y][X] = wallL;
            }
            if (mainMap[Y][X] == " "){
              mainMap[Y][X] = "  ";
            }
            if (mainMap[Y][X] == "-"){
              mainMap[Y][X] = floor;
            }
            if (mainMap[Y][X] == "_"){
              mainMap[Y][X] = platform;
            }
          }
        }
        System.Threading.Timer gametick = new System.Threading.Timer((e) =>
        {
          OpxPos = pxPos;
          OpyPos = pyPos;
          pyPos++;
          if (pxPos>mapsizeY){
            pyPos--;
          }
          else if (collisionMap[pyPos][pxPos]!=0){
            pyPos--;
          }
          mainMap[OpyPos][OpxPos] = "  ";   // remove player from map
          mainMap[pyPos][pxPos] = playerChar;   // integrate player into map
          collisionMap = updateCollision(collisionMap,mainMap);
          pSurround = player.findSurround(mainMap,pxPos,pyPos);
          pGravity = 150;
        }, null, 0,  pGravity);
        
        while(holder){
          if (admin==State.Undefined){
              pxPos = pStartX;
              pyPos = pStartY;
              OpxPos = pxPos;
              OpyPos = pyPos;
              mainMap[OpyPos][OpxPos] = "  ";   // remove player from map
              mainMap[pyPos][pxPos] = playerChar;   // integrate player into map
              admin = State.False;
          }
          if (admin!=True){  
            gametick.Change(0,pGravity);
            while(Console.KeyAvailable==false){// game tick
              mainMap = map.changeFromAdmin(mainMap);
              pSurround = player.findSurround(mainMap,pxPos,pyPos);
              Console.Clear();
              Console.Write(createMap(RefreshMap(mainMap, pyPos, pxPos, playerChar),pyPos,pxPos,touchingGround,admin,cSel,saveSlots,pSurround));
              Thread.Sleep(1);
              touchingGround = updateGroundContact(touchingGround, collisionMap,pxPos,pyPos);
            }
            while(Console.KeyAvailable){// player tick
              OpxPos = pxPos;
              OpyPos = pyPos;
              var pInput = Console.ReadKey(true);
              if (pInput.Key == ConsoleKey.Escape){
                holder = false;
              }
              if (pInput.Key == ConsoleKey.Delete){
                admin = State.True;
              }
              if (pInput.Key == ConsoleKey.DownArrow){
                pyPos++;
                if (pxPos>mapsizeY){
                  pyPos--;
                }
                else if (collisionMap[pyPos][pxPos]!=0){
                  pyPos--;
                }
              } 
              if (pInput.Key == ConsoleKey.UpArrow && touchingGround == True){
                gametick.Change(450,pGravity);
                OpxPos = pxPos;
                OpyPos = pyPos;
                pyPos--;
                if (pyPos<0){
                  pyPos++;
                }
                else if (collisionMap[pyPos][pxPos]!=0){
                  pyPos++;
                }
                mainMap[OpyPos][OpxPos] = "  ";   // remove player from map
                mainMap[pyPos][pxPos] = playerChar;   // integrate player into map
                collisionMap = updateCollision(collisionMap,mainMap);
                pSurround = player.findSurround(mainMap,pxPos,pyPos);
                Console.Clear();
                Console.Write(createMap(RefreshMap(mainMap, pyPos, pxPos, playerChar),pyPos,pxPos,touchingGround,admin,cSel,saveSlots,pSurround));
                Thread.Sleep(200);
                OpxPos = pxPos;
                OpyPos = pyPos;
                pyPos--;
                if (pyPos<0){
                  pyPos++;
                }
                else if (collisionMap[pyPos][pxPos]!=0){
                  pyPos++;
                }
                mainMap[OpyPos][OpxPos] = "  ";   // remove player from map
                mainMap[pyPos][pxPos] = playerChar;   // integrate player into map
                collisionMap = updateCollision(collisionMap,mainMap);
                pSurround = player.findSurround(mainMap,pxPos,pyPos);
                Console.Clear();
                Console.Write(createMap(RefreshMap(mainMap, pyPos, pxPos, playerChar),pyPos,pxPos,touchingGround,admin,cSel,saveSlots,pSurround));
                Thread.Sleep(1);
                gametick.Change(200,pGravity);
              } 
              if (pInput.Key == ConsoleKey.RightArrow){
                pxPos++;
                if (pxPos>mapsizeX){
                  pxPos--;
                }
                else if (collisionMap[pyPos][pxPos]!=0){
                  pxPos--;
                }
              } 
              if (pInput.Key == ConsoleKey.LeftArrow){
                pxPos--;
                if (pxPos<0){
                  pxPos++;
                }
                else if (collisionMap[pyPos][pxPos]!=0){
                  pxPos++;
                }
              } 
              mainMap[OpyPos][OpxPos] = "  ";   // remove player from map
              mainMap[pyPos][pxPos] = playerChar;   // integrate player into map
              collisionMap = updateCollision(collisionMap,mainMap);
              pSurround = player.findSurround(mainMap,pxPos,pyPos);
              touchingGround = updateGroundContact(touchingGround, collisionMap,pxPos,pyPos);
              Console.Clear();
              Console.Write(createMap(RefreshMap(mainMap, pyPos, pxPos, playerChar),pyPos,pxPos,touchingGround,admin,cSel,saveSlots,pSurround));
              Thread.Sleep(1);
            }
          } else if (admin==True) { 
            gametick.Change(4294967294,4294967294); 
            while(Console.KeyAvailable==false){// game tick
              pSurround = player.findSurround(mainMap,pxPos,pyPos);
              Console.Clear();
              Console.Write(createMap(RefreshMap(map.changeToAdmin(mainMap), pyPos, pxPos, playerChar),pyPos,pxPos,touchingGround,admin,cSel,saveSlots,pSurround));
              Thread.Sleep(1);
            }
            while(Console.KeyAvailable){// player tick ===============> to do ==> change player movement var
              OpxPos = pxPos;
              OpyPos = pyPos;
              var pInput = Console.ReadKey(true);
              if (pInput.Key == ConsoleKey.D0){
                saveSlots = 0;
              }
              if (pInput.Key == ConsoleKey.D1){
                saveSlots = 1;
              }
              if (pInput.Key == ConsoleKey.D2){
                saveSlots = 2;
              }
              if (pInput.Key == ConsoleKey.D3){
                saveSlots = 3;
              }
              if (pInput.Key == ConsoleKey.D4){
                saveSlots = 4;
              }
              if (pInput.Key == ConsoleKey.D5){
                saveSlots = 5;
              }
              if (pInput.Key == ConsoleKey.D6){
                saveSlots = 6;
              }
              if (pInput.Key == ConsoleKey.D7){
                saveSlots = 7;
              }
              if (pInput.Key == ConsoleKey.D8){
                saveSlots = 8;
              }
              if (pInput.Key == ConsoleKey.D9){
                saveSlots = 9;
              }
              if (pInput.Key == ConsoleKey.Escape){
                holder = false;
              }
              if (pInput.Key == ConsoleKey.F){
                cSel = "--";
              }
              if (pInput.Key == ConsoleKey.L){
                cSel = "l|";
              }
              if (pInput.Key == ConsoleKey.R){
                cSel = "|r";
              }
              if (pInput.Key == ConsoleKey.A){
                cSel = "__";
              }
              if (pInput.Key == ConsoleKey.S){
                cSel = platform;
              }
              if (pInput.Key == ConsoleKey.D){
                cSel = "<>";
              }
              if (pInput.Key == ConsoleKey.H){
                cSel = flag;
              }
              if (pInput.Key == ConsoleKey.G){
                cSel = "SP";
              }
              if (pInput.Key == ConsoleKey.X){
                jsonMap.Collision = collisionMap;
                jsonMap.Layer = map.changeFromAdmin(mainMap);
                File.WriteAllText(dir+"\\maps\\map"+Convert.ToSingle(saveSlots)+".json",JsonSerializer.Serialize<Map.Holder>(jsonMap));
              }
              if (pInput.Key == ConsoleKey.C){
                holder1 = File.ReadAllText(dir+"\\maps\\emptyMap.json");
                jsonMap = JsonSerializer.Deserialize<Map.Holder>(holder1)!;// error showing up under hol telling me i cant convert from string to Newtonsoft.Json
                collisionMap = jsonMap.Collision;
                mainMap = jsonMap.Layer;
                for (int X = 0; X < mainMap[0].Length; X++)
                {
                  for (int Y = 0; Y < mainMap.Length; Y++)
                  {
                    if (mainMap[Y][X] == "|r"){
                      mainMap[Y][X] = wallR;
                    }
                    if (mainMap[Y][X] == "l|"){
                      mainMap[Y][X] = wallL;
                    }
                    if (mainMap[Y][X] == " "){
                      mainMap[Y][X] = "  ";
                    }
                    if (mainMap[Y][X] == "-"){
                      mainMap[Y][X] = floor;
                    }
                    if (mainMap[Y][X] == "_"){
                      mainMap[Y][X] = platform;
                    }
                  }
                }
                mainMap = map.changeToAdmin(mainMap);
              }
              if (pInput.Key == ConsoleKey.V){
                holder1 = File.ReadAllText(dir+"\\maps\\map"+Convert.ToSingle(saveSlots)+".json");
                jsonMap = JsonSerializer.Deserialize<Map.Holder>(holder1)!;// error showing up under hol telling me i cant convert from string to Newtonsoft.Json
                collisionMap = jsonMap.Collision;
                mainMap = jsonMap.Layer;
                for (int X = 0; X < mainMap[0].Length; X++)
                {
                  for (int Y = 0; Y < mainMap.Length; Y++)
                  {
                    if (mainMap[Y][X] == "|r"){
                      mainMap[Y][X] = wallR;
                    }
                    if (mainMap[Y][X] == "l|"){
                      mainMap[Y][X] = wallL;
                    }
                    if (mainMap[Y][X] == " "){
                      mainMap[Y][X] = "  ";
                    }
                    if (mainMap[Y][X] == "-"){
                      mainMap[Y][X] = floor;
                    }
                    if (mainMap[Y][X] == "_"){
                      mainMap[Y][X] = platform;
                    }
                  }
                }
                mainMap = map.changeToAdmin(mainMap);
              }
              if (pInput.Key == ConsoleKey.Spacebar){
                if(cSel!=flag && cSel!="SP"){
                  mainMap[pyPos][pxPos] = "[34m"+cSel+"[37m";   // integrate player into map
                } else if (cSel == "SP"){
                  mainMap[pStartY][pStartX] = "<>";
                  mainMap[pyPos][pxPos] = "[34m"+cSel+"[37m";   // integrate player into map
                  pStartY = pyPos;
                  pStartX = pxPos;
                } else{
                  mainMap[flagPosY][flagPosX] = "<>";
                  mainMap[pyPos][pxPos] = "[34m"+cSel+"[37m";   // integrate player into map
                  flagPosY = pyPos;
                  flagPosX = pxPos;
                }
              }
              if (pInput.Key == ConsoleKey.Delete){
                admin = State.Undefined;
              }
              if (pInput.Key == ConsoleKey.DownArrow){
                pyPos++;
                if (pyPos==mapsizeY){
                  pyPos--;
                }
              } 
              if (pInput.Key == ConsoleKey.UpArrow){
                pyPos--;
                if (pyPos<0){
                  pyPos++;
                }
              } 
              if (pInput.Key == ConsoleKey.RightArrow){
                pxPos++;
                if (pxPos==mapsizeX){
                  pxPos--;
                }
              } 
              if (pInput.Key == ConsoleKey.LeftArrow){
                pxPos--;
                if (pxPos<0){
                  pxPos++;
                }
              } 
              mainMap[OpyPos][OpxPos] = mainMap[OpyPos][OpxPos].Replace("[34m","");   // remove player from map
              mainMap[pyPos][pxPos] = "[34m"+mainMap[pyPos][pxPos]+"[37m";   // integrate player into map
            }
          }
        }
        Console.Read(); 
      }
    
  }
}