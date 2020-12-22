using System;

namespace ImMonoGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SampleProject())
                game.Run();
        }
    }
}

