namespace Wood.Test;

[TestClass]
public class SeverityTest
{
    [TestMethod]
    public void TestDebug()
    {
        LogManager.Debug("Simple debug phrase");
    }

    [TestMethod]
    public void TestInformation()
    {
        LogManager.Information("Simple information phrase");
    }

    [TestMethod]
    public void TestNotice()
    {
        LogManager.Notice("Simple notice phrase");
    }

    [TestMethod]
    public void TestWarning()
    {
        LogManager.Warn("Simple warning phrase");
    }

    [TestMethod]
    public void TestError()
    {
        LogManager.Error("Simple error phrase");
    }

    [TestMethod]
    public void TestCritical()
    {
        LogManager.Critical("Simple critical phrase");
    }    
    
    [TestMethod]
    public void TestAlert()
    {
        LogManager.Alert("Simple alert phrase");
    }    
    
    [TestMethod]
    public void TestEmergency()
    {
        LogManager.Emergency("Simple emergency phrase");
    }

    [TestMethod]
    public void TestEverything()
    {
        foreach (var s in Enum.GetValues(typeof(Severity)))
            LogManager.Log((Severity)s, "Simple test message");
    }
}