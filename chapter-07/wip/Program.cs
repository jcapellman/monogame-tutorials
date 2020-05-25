using chapter_07.Engine;
using chapter_07.States;
using System;

namespace chapter_07
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new MainGame(1280, 720, new SplashState()))
                game.Run();
        }
    }
#endif
}
