namespace TiendaElectronica.Core.Aparatos;

public class AdaptadorTDT : Aparato
{
    public AdaptadorTDT() : base(5)
    {
    }

    public uint TiempoMaximoGrabacion { get; init; }
    public bool PuedeGrabar => TiempoMaximoGrabacion > 0;
}