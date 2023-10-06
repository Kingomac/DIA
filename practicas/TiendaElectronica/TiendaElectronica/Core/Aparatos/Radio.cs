namespace TiendaElectronica.Core.Aparatos;

public class Radio : Aparato
{
    public Radio() : base(5)
    {
    }

    public BandasRadio BandasSoportadas { get; init; }
}