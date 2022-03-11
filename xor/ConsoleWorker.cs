namespace xor;

class ConsoleWorker
{
    public void DrawTable(string path)
    {
        FileWorker fileWorker = new FileWorker();
        TableInfo tableInfo =  fileWorker.GetTableInfo(path);
            
        for (int i = 1; i <= tableInfo.Width * tableInfo.Height; i++)
        {
            LampInfo lampInfo = fileWorker.GetLampInfo(path, i);
            DrawLamp(lampInfo, tableInfo.Scale);
        }
    }
        
    private void DrawLamp(LampInfo lampInfo, int scale)
    {
        string lamp = "█";
        Console.ForegroundColor = lampInfo.Color.ToConsoleColor();
        int verticalScale = scale < 2 ? scale : scale / 2; 
        for (int j = 0; j < verticalScale; j++)
        {
            Console.SetCursorPosition(lampInfo.Location.X * scale, lampInfo.Location.Y * verticalScale + j);
            for (int i = 0; i < scale; i++)
            {
                Console.Write(lamp);
            }
        }
    }
}