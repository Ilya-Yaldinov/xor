namespace xor;

public class TableInfo
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Scale { get; set; }

    public TableInfo(int width, int height, int scale)
    {
        Width = width;
        Height = height;
        Scale = scale;
    }
}