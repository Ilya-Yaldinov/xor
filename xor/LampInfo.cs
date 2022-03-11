using System.Drawing;

namespace xor;

public class LampInfo
{
    public Point Location { get; set; }
    public Color Color { get; set; }
        
    public LampInfo(Point location, Color color)
    {
        this.Location = location;
        Color = color;
    }
}