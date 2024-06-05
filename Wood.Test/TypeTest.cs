namespace Wood.Test;

[TestClass]
public class TypeTest
{
    [TestMethod]
    public void TestNull()
    {
        LogManager.Information("Testing null: ", null);
    }

    [TestMethod]
    public void TestTrue()
    {
        LogManager.Information("Testing true: ", true);
    }

    [TestMethod]
    public void TestFalse()
    {
        LogManager.Information("Testing false: ", false);
    }

    [TestMethod]
    public void TestByte()
    {
        LogManager.Information("Testing char: ", (byte)Random.Shared.Next(1, 254));
    }

    [TestMethod]
    public void TestIntZero()
    {
        LogManager.Information("Testing int(0): ", 0);
    }

    [TestMethod]
    public void TestIntNegative()
    {
        LogManager.Information("Testing int(-rand): ", -Random.Shared.Next(1, 99));
    }

    [TestMethod]
    public void TestIntRandom()
    {
        LogManager.Information("Testing int(rand): ", Random.Shared.Next(1, 99));
    }

    [TestMethod]
    public void TestUIntRandom()
    {
        LogManager.Information("Testing uint(rand): ", (uint)Random.Shared.Next(1, 99));
    }

    [TestMethod]
    public void TestShortRandom()
    {
        LogManager.Information("Testing short(rand): ", (short)Random.Shared.Next(1, 99));
    }

    [TestMethod]
    public void TestUShortRandom()
    {
        LogManager.Information("Testing ushort(rand): ", (ushort)Random.Shared.Next(1, 99));
    }

    [TestMethod]
    public void TestLongRandom()
    {
        LogManager.Information("Testing long(rand): ", (long)Random.Shared.Next(1, 99));
    }

    [TestMethod]
    public void TestULongRandom()
    {
        LogManager.Information("Testing ulong(rand): ", (ulong)Random.Shared.Next(1, 99));
    }

    [TestMethod]
    public void TestSingle()
    {
        LogManager.Information("Testing single(rand): ", Random.Shared.NextSingle());
    }

    [TestMethod]
    public void TestDouble()
    {
        LogManager.Information("Testing double(rand): ", Random.Shared.NextDouble());
    }

    [TestMethod]
    public void TestDecimal()
    {
        LogManager.Information("Testing decimal(rand): ", (decimal)Random.Shared.NextDouble());
    }

    [TestMethod]
    public void TestChar()
    {
        LogManager.Information("Testing char(c): ", 'c');
    }

    [TestMethod]
    public void TestEmptyString()
    {
        LogManager.Information("Testing string(): ", "");
    }

    [TestMethod]
    public void TestString()
    {
        LogManager.Information("Testing string(str): ", "str");
    }

    [TestMethod]
    public void TestEverything()
    {
        TestNull();
        TestTrue();
        TestFalse();
        TestByte();
        TestIntZero();
        TestIntNegative();
        TestIntRandom();
        TestUIntRandom();
        TestShortRandom();
        TestUShortRandom();
        TestLongRandom();
        TestULongRandom();
        TestSingle();
        TestDouble();
        TestDecimal();
        TestChar();
        TestString();
        TestEmptyString();
    }
}