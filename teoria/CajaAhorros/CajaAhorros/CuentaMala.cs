namespace CajaAhorros;

public class CuentaMala
{
    public required int DNI { get; init; }
    public required float Saldo { get; set; }

    public void Ingresa(float x)
    {
        Saldo += x;
    }
}