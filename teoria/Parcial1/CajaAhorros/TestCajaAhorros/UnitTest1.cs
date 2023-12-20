using CajaAhorros;

namespace TestCajaAhorros;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        c0 = new Cuenta()
        {
            DNI = 12345678,
            Saldo = 0,
        };
    }

    [Test]
    public void TestCuenta0()
    {
        Assert.AreEqual(12345678, c0.DNI);
        Assert.That(c0.Saldo, Is.EqualTo(0));
    }

    [Test]
    public void TestIngreso()
    {
        Assert.That(c0.Saldo, Is.EqualTo(0));
        c0.Ingresa(5,0);
        Assert.That(c0.Saldo, Is.EqualTo(5.0));
        c0.Ingresa(3.33f);
        Assert.That(c0.Saldo, Is.EqualTo(8.33f));
    }

    [Test]
    public void TestIngresoCompuesto()
    {
        c0.Ingresa(8.33f);
        Assert.That(c0.SaldoCompuesto, Is.EqualTo((8,33)));
        c0.Ingresa(0,67);
        Assert.That(c0.SaldoCompuesto, Is.EqualTo((9,0)));
    }

    Cuenta c0;
}