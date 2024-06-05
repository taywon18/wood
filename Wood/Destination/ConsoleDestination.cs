using System;
using System.Collections.Generic;
using System.Text;

namespace Wood.Destination
{

    /// <summary>
    /// Display log message in the console.
    /// </summary>
    public class ConsoleDestination
        : Destination
    {
        public static ConsoleColor DefaultBackgroundColor { get; } = ConsoleColor.Black;
        public static ConsoleColor DefaultForegroundColor { get; } = ConsoleColor.Gray;

        bool Inited = false;

        public ConsoleDestination()
            : this(false)
        {

        }

        public ConsoleDestination(bool setUtf8)
        {
            Inited = !setUtf8;
        }

        public override void Log(int thread, DateTime moment, Severity severity, Message message)
        {
            if(!Inited)
            {
                Inited = true;
                Console.OutputEncoding = UTF8Encoding.UTF8;
            }

            System.ConsoleColor oldbackground = System.Console.BackgroundColor;
            System.ConsoleColor oldforeground = System.Console.ForegroundColor;

            SetConsoleColorBySeverity(severity);

            System.Console.Write("[" + severity.ToString() + "] " + moment.ToString("HH:mm:ss.ff") + ", " + thread + ": ");
            foreach (object arg in message.Parameters)
            {
                if (arg is Flavor flavor)
                {
                    if (flavor == Flavor.Normal)
                        SetConsoleColorBySeverity(severity);
                    else
                        SetConsoleColorbyFlavor(flavor);

                    continue;
                }

                PrintFormated(arg);
            }

            Console.Write(Environment.NewLine);

            System.Console.BackgroundColor = oldbackground;
            System.Console.ForegroundColor = oldforeground;
        }

        private static void PrintFormated(object obj)
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor foreground = Console.ForegroundColor;

            if (obj is null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("🚫 null");
            }
            else if (obj is string s)
            {
                if (s == "")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("(empty)");
                }
                else
                    Console.Write(s);
            }
            else if(obj is char c)
            {
                Console.Write(c);
            }
            else if (obj is bool b)
            {
                if (b)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("✔️ true");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("❌ false");
                }
            }
            else if (obj is TimeSpan dt)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(dt.ToString());
            }
            else if (IsNumericType(obj.GetType()))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(obj.ToString());
            }
            else
                Console.Write(obj.ToString());

            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        public static KeyValuePair<ConsoleColor, ConsoleColor> GetConsoleColorBySeverity(Severity severity)
        {
            if (severity == Severity.Debugging)
                return new KeyValuePair<ConsoleColor, ConsoleColor>(ConsoleColor.DarkGray, DefaultBackgroundColor);

            if (severity == Severity.Informational)
                return new KeyValuePair<ConsoleColor, ConsoleColor>(DefaultForegroundColor, DefaultBackgroundColor);

            if (severity == Severity.Notice)
                return new KeyValuePair<ConsoleColor, ConsoleColor>(ConsoleColor.White, DefaultBackgroundColor);

            if (severity == Severity.Warning)
                return new KeyValuePair<ConsoleColor, ConsoleColor>(ConsoleColor.DarkYellow, DefaultBackgroundColor);

            if (severity == Severity.Error)
                return new KeyValuePair<ConsoleColor, ConsoleColor>(ConsoleColor.Red, DefaultBackgroundColor);

            if (severity == Severity.Critical)
                return new KeyValuePair<ConsoleColor, ConsoleColor>(ConsoleColor.Black, ConsoleColor.Yellow);

            if (severity == Severity.Alert)
                return new KeyValuePair<ConsoleColor, ConsoleColor>(ConsoleColor.White, ConsoleColor.DarkRed);

            if (severity == Severity.Emergency)
                return new KeyValuePair<ConsoleColor, ConsoleColor>(ConsoleColor.Yellow, ConsoleColor.DarkRed);

            throw new NotImplementedException();
        }

        public static void SetConsoleColorBySeverity(Severity severity)
        {
            var colors = GetConsoleColorBySeverity(severity);
            Console.ForegroundColor = colors.Key;
            Console.BackgroundColor = colors.Value;
        }

        public static ConsoleColor GetConsoleColorByFlavor(Flavor flavor)
        {
            if (flavor == Flavor.Important)
                return ConsoleColor.Cyan;

            if (flavor == Flavor.Ok)
                return ConsoleColor.Green;

            if (flavor == Flavor.Progress)
                return ConsoleColor.Blue;

            if (flavor == Flavor.Failed)
                return ConsoleColor.Red;

            throw new NotImplementedException();
        }

        public static void SetConsoleColorbyFlavor(Flavor flavor)
        {
            var color = GetConsoleColorByFlavor(flavor);
            Console.ForegroundColor = color;
        }

        // thanks to Guillaume (https://stackoverflow.com/questions/1749966/c-sharp-how-to-determine-whether-a-type-is-a-number)
        static bool IsNumericType(Type t)
        {
            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
