using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{

    class MapGenerator
    {
        public enum MapType
        {
            SMALL = 50, // 500x500 
            MEDIUM = 1000, // 1000x1000
            LARGE = 1500  //1500x1500
        }
        public static String MapGenerate(MapType type)
        {
            Random rnd = new Random();
            int x;
            int next;
            int mapLength = (int)type;
            String[,] mapField = new string[mapLength, mapLength];
            string mapCode = "";
            for (int i = 0; i < mapLength; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {
                    if (mapField[i,j] == null )
                    {
                        x = rnd.Next(0, 100);
                        if (x < 5)
                        {
                            mapField[i, j] = "s";
                        }
                        if (x >= 5 && x < 15)
                        {
                            mapField[i, j] = "w";
                        }
                        if (x >= 15 && x < 50)
                        {
                            mapField[i, j] = "t";
                        }
                        if (x >= 50)
                        {
                            mapField[i, j] = "g";
                        }
                    }
                    next = rnd.Next(10);
                    if (next < 9)
                    {
                        if  (j != mapLength-1)
                        {
                            mapField[i,j+1] = mapField[i, j];
                        } 
                    }

                }

            }
            for (int i = 0; i < mapLength; i++)
            {
                for (int j = 0; j < mapLength; j++)
                {
                    mapCode += mapField[i, j];
                }
            }
            return mapCode;
        }
        
    }
}
