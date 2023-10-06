namespace TiendaElectronica.Core.Aparatos;

public class ReproductorDVD : Aparato
{
    public ReproductorDVD() : base(10)
    {
    }

    public bool BlueRay { get; init; }
    public bool Graba => TiempoGrabacion > 0;
    public uint TiempoGrabacion { get; init; }
}