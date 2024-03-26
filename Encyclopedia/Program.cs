using System;
using static System.Console;

namespace EncyclopediaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgumentNullException.ThrowIfNull(args);

            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;
            Clear();

            Encyclopedia myEncyclopedia = new();
            myEncyclopedia.Run();
        }
    }
}