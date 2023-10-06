namespace TiendaElectronica.Core.Aparatos;

public abstract class Aparato
{
    public Aparato(double precioReparacionHora)
    {
        PrecioReparacionHora = precioReparacionHora;
    }

    public required uint NumeroSerie { get; init; }
    public required string Modelo { get; init; }
    public required double PrecioReparacionHora { get; init; }
}