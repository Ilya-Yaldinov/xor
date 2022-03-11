using System;
using System.Drawing;

namespace xor
{
    class MyClass
    {
        public static void Main()
        {
            string path = "..//Lamp.txt";
            FileWorker.GetTableInfo(path);
        }
    }

    class FileWorker // TODO х и у надо сюда 
    {
        private static string[] FIleReader(string path)
        {
            string[] file = File.ReadAllLines(path);
            return file;
        }

        public static (string, string, string) GetTableInfo(string path)
        {
            string[] file = FIleReader(path);
            string[] tableInfo = file[0].Split('x', 'X', 'х', 'Х', ':');
            string x = tableInfo[0];
            string y = tableInfo[1];
            string scale = tableInfo[2];
            
            return (x, y, scale);
        }
    }

    class ConsoleWorker
    {
        public void DrawTable(string path)
        {
            string[] file = File.ReadAllLines(path);
            string[] table = file[0].Split('x', 'X', 'х', 'Х');
            string x = table[0];
            string y = table[1];
            
            for (int i = 1; i < file.Length; i++)
            {
                string lamp = file[i];
                int curX = Convert.ToInt32(lamp.Substring(0, x.Length));
                int curY = Convert.ToInt32(lamp.Substring(x.Length, y.Length));
                string rgb = lamp.Substring(x.Length + y.Length, 3);
                ColourChanger(curX, curY, rgb);
            }
            
        }
        
        private static ConsoleColor ConvertFromRGB(byte r, byte g, byte b)
        {
            ConsoleColor trueColor = 0;
            double red = r;
            double green = g;
            double blue = b;
            double delta = double.MaxValue;

            foreach (ConsoleColor consoleColor in Enum.GetValues(typeof(ConsoleColor)))
            {
                string name = Enum.GetName(typeof(ConsoleColor), consoleColor);
                Color color = System.Drawing.Color.FromName(name == "DarkYellow" ? "Orange" : name); // bug fix
                double toConsoleColor = Math.Pow(color.R - red, 2.0) + Math.Pow(color.G - green, 2.0) + Math.Pow(color.B - blue, 2.0);
                
                if (toConsoleColor == 0.0)
                    return consoleColor;
                
                if (toConsoleColor < delta)
                {
                    delta = toConsoleColor;
                    trueColor = consoleColor;
                }
                
            }
            
            return trueColor;
        }

        public void ColourChanger(int x, int y, string rgb)
        {
            string a = "█";
            Color color = Color.FromArgb();
            Console.ForegroundColor = color.ToArgb();
            switch (rgb) //TODO rgb вынеси
            {
                case "111":
                    break;
                case "100":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "010":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "000":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "001":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
            
            for (int j = 0; j < 2; j++)
            {
                Console.SetCursorPosition(x * 4, y * 4 / 2 + j); //TODO 
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(a);
                }
            }
            
        }
    }
}