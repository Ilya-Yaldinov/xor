using System.Drawing;

namespace xor;

class FileWorker 
{
    public TableInfo GetTableInfo(string path)
    {
        string[] file = File.ReadAllLines(path);
        string[] table = file[0].Split('x', 'X', 'х', 'Х', ':');
        int x = Convert.ToInt32(table[0]);
        int y = Convert.ToInt32(table[1]);
        int scale = Convert.ToInt32(table[2]);
            
        return new TableInfo(x, y, scale);
    }

    public LampInfo GetLampInfo(string path, int i)
    {
        string[] file = File.ReadAllLines(path);
        TableInfo tableInfo = GetTableInfo(path);

        string lampInfo = file[i];

        int xLength = tableInfo.Width.ToString().Length;
        int yLength = tableInfo.Height.ToString().Length;

        int lampX = Convert.ToInt32(lampInfo.Substring(0, xLength));
        int lampY = Convert.ToInt32(lampInfo.Substring(xLength, yLength));
        string rgb = lampInfo.Substring(xLength + yLength, 3);

        Point point = new Point(lampX, lampY);

        return new LampInfo(point, new Color(rgb));
    }
}