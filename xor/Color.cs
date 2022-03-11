namespace xor;

public class Color
{
    public LampColors LampColor { get; set; }

    public Color(string rgb)
    {
        byte colorByNum = Convert.ToByte(rgb, 2);
        LampColor = (LampColors)colorByNum;
    }

    public ConsoleColor ToConsoleColor()
    {
        ConsoleColor.TryParse(LampColor.ToString(), true, out ConsoleColor consoleColor);
        return consoleColor;
    }

    public enum LampColors
    {
        Red = 4,
        Green = 2,
        Blue = 1,
        White = 7,
        Black = 0
    }
}