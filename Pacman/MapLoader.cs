using System;
using System.Drawing; 
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pacman
{
    public class MapLoader
    {
        public static Map Load(String filename)
        {
            StreamReader sr;
            Map rv;
            int width, height, i, j;
            String line;
            char[] chars;
            List<String> lines = new List<String>();
            
            // Load the file into a lines vector
            sr = File.OpenText(filename);
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line.Length > 0)
                {
                    lines.Add(line);
                }
            }

            // Initialize the map given the size we know
            Debug.Assert(lines.Count > 0, "Map file with length 0 found");
            width = lines[0].Length;
            height = lines.Count;
            rv = new Map(new Size(width, height));

            // Use the line vector to build the map
            for (i = 0; i < height; i++)
            {
                chars = lines[i].ToCharArray();
                for (j = 0; j < width; j++)
                {
                    rv[j, i] = TileFromChar(chars[j]);
                }
            }
            return rv; 
        }

        private static TileType TileFromChar(char c)
        {
            switch(c)
            {
                case ' ':
                    return TileType.Empty;
                case '.':
                    return TileType.Pill;
                case 'P':
                    return TileType.PowerPill;
                case 'F':
                    return TileType.Fruit;
                case '1':
                    return TileType.Wall;
                case '-':
                    return TileType.BadguyDoor;
            }
            throw new Exception("Invalid tile character in map file: " + c);
        }
    }
}
