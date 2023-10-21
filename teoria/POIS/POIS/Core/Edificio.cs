namespace POIS.Core;

public class Edificio : POI
{
    /// <summary>Crea un edificio como punto de interés.</summary>
    /// <param name="x">La coordenada x o latitud.</param>
    /// <param name="y">La coordenada y o longitud.</param>
    /// <param name="nombre">El nombre del punto de interés.</param>
    /// <param name="direccion">La dirección postal del punto de interés.</param>
    public Edificio(double x, double y, string nombre, string direccion)
        : base(x, y, nombre)
    {
        Direccion = direccion;
    }

    /// <summary>La dirección postal.</summary>
    public string Direccion { get; init; }

    public override string ToString()
    {
        return $"edificio {base.ToString()}, dirección: {Direccion}";
    }
}