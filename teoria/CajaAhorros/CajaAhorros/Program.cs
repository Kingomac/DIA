// See https://aka.ms/new-console-template for more information

using CajaAhorros;

Console.WriteLine("Hello, World!");

Cuenta c0= new Cuenta()
{
    DNI = 12345678,
    Saldo = 0.0f
};
c0.Ingresa(5,0);
Console.WriteLine("saldo: " + c0.Saldo);
Console.WriteLine("saldo compuesto: " + c0.SaldoCompuesto.euros + "." + c0.SaldoCompuesto.centimos);
c0.Ingresa(3.33f);
Console.WriteLine("***********************");
Console.WriteLine("saldo: " + c0.Saldo);
Console.WriteLine("saldo compuesto: " + c0.SaldoCompuesto.euros + "." + c0.SaldoCompuesto.centimos);