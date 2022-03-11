namespace xor
{
    class MyClass
    {
        public static void Main()
        {
            string path = "..//Lamp.txt";
            ConsoleWorker consoleWorker = new ConsoleWorker();
            consoleWorker.DrawTable(path);
        }
    }
}