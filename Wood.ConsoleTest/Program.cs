// See https://aka.ms/new-console-template for more information
using Wood;
using Wood.Test;

Console.WriteLine("######################");
Console.WriteLine("#                    #");
Console.WriteLine("# Simple visual test #");
Console.WriteLine("#                    #");
Console.WriteLine("######################");
Console.WriteLine();

//Init
LogManager.Instance.ClearConfiguration();
LogManager.Instance.Destinations.Add<Wood.Destination.ConsoleDestination>();

Console.WriteLine("# Testing Flavors and Severities");
FlavorTest ft = new();
ft.TestEverything();
Console.WriteLine();

Console.WriteLine("# Testing data types");
TypeTest tt = new();
tt.TestEverything();
Console.WriteLine();