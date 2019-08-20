using System;

namespace OptimusPrime.Server.Extensions
{
    public static class ConsoleExtension
    {
        private static ConsoleColor _bgColor;
        private static ConsoleColor _fgColor;

        public static void PrintLine(string text, ConsoleColor? foregroundColor = null, ConsoleColor? backgroundColor = null)
        {
            if (foregroundColor.HasValue)
            {
                _fgColor = Console.ForegroundColor;
                Console.ForegroundColor = foregroundColor.Value;
            }

            if (backgroundColor.HasValue)
            {
                _bgColor = Console.BackgroundColor;
                Console.BackgroundColor = backgroundColor.Value;
            }

            Console.WriteLine(text);

            if (foregroundColor.HasValue)
            {
                Console.ForegroundColor = _fgColor;
            }

            if (backgroundColor.HasValue)
            {
                Console.BackgroundColor = _bgColor;
            }
        }
    }
}
