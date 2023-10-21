namespace CajaAhorros;

public class Cuenta
{
    public required int DNI { get; init; }

    // [euros][centimos]
    //  [n-2]    [2]
    private int saldo;
    public required float Saldo
    {
        get => (float) saldo / 100;
        set => saldo = (int)(value * 100);
    }

    public (int euros, int centimos) SaldoCompuesto => new(saldo / 100, saldo % 100);

    public void Ingresa(float x)
    {
        var euros = (int)x;
        this.Ingresa(euros, (int)Math.Round((x-euros)*100));
    }

    public void Ingresa(int euros, int centimos)
    {
        this.saldo += euros * 100 + centimos;
    }
}