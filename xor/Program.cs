using System;
using System.Drawing;
using System.Xml.Schema;

namespace xor
{
    class MyClass
    {
        public static void Main()
        {
            string path = "..//Lamp.txt";
            ConsoleWorker.DrawTable(path);
        }
    }

    class FileWorker 
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

        public static (int, int, string) GetLampInfo(string path, int i)
        {
            string[] file = FIleReader(path);
            (string x, string y, string scale) = GetTableInfo(path);
            
            string lampInfo = file[i];
            
            int lampX = Convert.ToInt32(lampInfo.Substring(0, x.Length));
            int lampY = Convert.ToInt32(lampInfo.Substring(x.Length, y.Length));
            string rgb = lampInfo.Substring(x.Length + y.Length, 3);

            return (lampX, lampY, rgb);
        }
    }

    class ConsoleWorker
    {
        public static void DrawTable(string path)
        {
            (string x, string y, string scale) = FileWorker.GetTableInfo(path);
            
            for (int i = 1; i < Convert.ToInt32(x) * Convert.ToInt32(y); i++)
            {
                (int lampX, int lampY, string rgb) = FileWorker.GetLampInfo(path, i);
                ColourChanger(lampX, lampY, rgb, Convert.ToInt32(scale));
            }
        }
        
        private static ConsoleColor ConvertFromRGB(byte r, byte g, byte b)
        {
            ConsoleColor ret = 0;
            double red = r;
            double green = g;
            double blue = b;
            double delta = double.MaxValue;

            foreach (ConsoleColor consoleColor in Enum.GetValues(typeof(ConsoleColor)))
            {
                string n = Enum.GetName(typeof(ConsoleColor), consoleColor);
                Color color = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); 
                double t = Math.Pow(color.R - red, 2.0) + Math.Pow(color.G - green, 2.0) + Math.Pow(color.B - blue, 2.0);
                if (t == 0.0)
                    return consoleColor;
                if (t < delta)
                {
                    delta = t;
                    ret = consoleColor;
                }
            }
            
            return ret;
        }

        public static void ColourChanger(int x, int y, string rgb, int scale)
        {
            string lamp = "█";
            char[] ground = rgb.ToCharArray();
            Color color = Color.FromArgb(Convert.ToInt32(ground[0].ToString()), Convert.ToInt32(ground[1].ToString()), Convert.ToInt32(ground[2].ToString()));
            Console.ForegroundColor = ConvertFromRGB(color.R, color.G, color.B);
            
            for (int j = 0; j < scale/2; j++)
            {
                Console.SetCursorPosition(x * scale, y * scale / 2 + j);
                for (int i = 0; i < scale; i++)
                {
                    Console.Write(lamp);
                }
            }
            
        }
    }
}