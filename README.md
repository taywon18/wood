## Wood: Keep Your Logs From Going Barking Mad

Wood is a lightweight but powerful C# library designed to make logging a breeze. No more getting lost in a tangled mess of log statements - Wood helps you write clean, informative messages to various destinations ️

**Features:**

* **Multiple Destinations:** Send your logs to the console, files, or any custom destination you can dream up. 
* **Severity Levels:**  From debug messages to critical errors, categorize your logs for easy prioritization. 
* **Simple API:**  Log messages with intuitive methods like `Debug`, `Warn`, and `Error`.  
* **Default Configuration:** Out of the box, Wood logs to both the console and a file for maximum coverage.  
* **Thread Safety:**  Logs from multiple threads are handled smoothly, no splinters here! 

**Getting Started:**

1. Install the Wood package from nuget.
2. Add `using Wood;` to your C# files.
3. Start logging! Use static methods like `Wood.Debug("Hello from Wood!")` or the fluent API with `LogManager.Instance.Information("This is an informational message")`.

**Example:**

```csharp
using Wood;

public class MyAwesomeClass
{
    public void DoSomethingCool()
    {
        Wood.Debug("Starting to do something cool...");
        // Your awesome code goes here
        Wood.Information("Successfully did something cool!");
    }
}
```

**Customize Your Logging:**

Wood provides flexibility to tailor your logging needs. You can:

* **Change Default Destinations:** Use `LogManager.ClearConfiguration()` and then `LogManager.Instance.Destinations.Add<YourCustomDestination>()` to add your own destinations.
* **Set Different Logging Levels:** Each destination can have its own minimum severity level for filtering messages.

**Feel free to contribute!** We welcome pull requests and any suggestions to make Wood the most awesome logging library ever. 
