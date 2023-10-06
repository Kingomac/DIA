namespace TiendaElectronica.Core.Aparatos;

public class Televisor : Aparato
{
    public Televisor() : base(10)
    {
    }

    public double Pulgadas { get; init; }
}