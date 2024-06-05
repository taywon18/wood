namespace Wood.Test;

[TestClass]
public class FlavorTest
{
    public void Test(Severity severity, Flavor flavor)
    {
        LogManager.Log(severity, "Simple ", flavor, flavor.ToString(), Flavor.Normal, " test message");
    }

    [TestMethod]
    public void TestNormal()
    {
        Test(Severity.Informational, Flavor.Normal);
    }

    [TestMethod]
    public void TestImportant()
    {
        Test(Severity.Informational, Flavor.Important);
    }

    [TestMethod]
    public void TestOk()
    {
        Test(Severity.Informational, Flavor.Ok);
    }

    [TestMethod]
    public void TestFailed()
    {
        Test(Severity.Informational, Flavor.Failed);
    }

    [TestMethod]
    public void TestProgress()
    {
        Test(Severity.Informational, Flavor.Progress);
    }

    [TestMethod]
    public void TestEverything()
    {
        foreach (var s in Enum.GetValues(typeof(Severity)))
            foreach (var f in Enum.GetValues(typeof(Flavor)))
                Test((Severity)s, (Flavor)f);
    }
}