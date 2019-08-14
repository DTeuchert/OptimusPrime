using System;

namespace OptimusPrime.Server.Extensions
{
     public static class ConsoleExtension
    {
        private static ConsoleColor bgColor;
        private static ConsoleColor fgColor;

        public static void PrintLine(string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            if (foregroundColor.HasValue)
            {
                fgColor = Console.ForegroundColor;
                Console.ForegroundColor = foregroundColor.Value;
            }

            if (backgroundColor.HasValue)
            {
                bgColor = Console.BackgroundColor;
                Console.BackgroundColor = backgroundColor.Value;
            }

            Console.WriteLine(text);

            if (foregroundColor.HasValue)
            {
                Console.ForegroundColor = fgColor;
            }

            if (backgroundColor.HasValue)
            {
                Console.BackgroundColor = bgColor;
            }
        }
    }
}