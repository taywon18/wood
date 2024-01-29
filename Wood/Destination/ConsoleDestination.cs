using System;

namespace Wood.Destination
{

    /// <summary>
    /// Display log message in the console.
    /// </summary>
    public class ConsoleDestination
        : Destination
    {
        public override void Log(int thread, DateTime moment, Gravity gravity, string message)
        {
            System.ConsoleColor background = System.Console.BackgroundColor;
            System.ConsoleColor foreground = System.Console.ForegroundColor;

            if (gravity == Gravity.Emergency)
            {
                System.Console.BackgroundColor = System.ConsoleColor.Red;
                System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            }
            else if (gravity == Gravity.Alert)
            {
                System.Console.BackgroundColor = System.ConsoleColor.Red;
                System.Console.ForegroundColor = System.ConsoleColor.White;
            }
            else if (gravity == Gravity.Critical)
            {
                System.Console.BackgroundColor = System.ConsoleColor.Red;
                System.Console.ForegroundColor = System.ConsoleColor.Black;
            }
            else if (gravity == Gravity.Error)
            {
                System.Console.BackgroundColor = System.ConsoleColor.Black;
                System.Console.ForegroundColor = System.ConsoleColor.Red;
            }
            else if (gravity == Gravity.Warning)
            {
                System.Console.BackgroundColor = System.ConsoleColor.Black;
                System.Console.ForegroundColor = System.ConsoleColor.DarkYellow;
            }
            else if (gravity == Gravity.Notice)
            {
                System.Console.BackgroundColor = System.ConsoleColor.Black;
                System.Console.ForegroundColor = System.ConsoleColor.Blue;
            }
            else if (gravity == Gravity.Informational)
            {
                System.Console.BackgroundColor = System.ConsoleColor.Black;
                System.Console.ForegroundColor = System.ConsoleColor.White;
            }
            else if (gravity == Gravity.Debugging)
            {
                System.Console.BackgroundColor = System.ConsoleColor.Black;
                System.Console.ForegroundColor = System.ConsoleColor.Gray;
            }

            System.Console.WriteLine("[" + gravity.ToString() + "] " + moment.ToString("HH:mm:ss.ff") +", "+thread+ ": " + message);

            System.Console.BackgroundColor = background;
            System.Console.ForegroundColor = foreground;
        }
    }
}
