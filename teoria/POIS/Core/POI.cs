namespace POIS.Core;

/// <summary>Clase base para puntos de interés.</summary>
public abstract class POI
{
    /// <summary>Crea un punto de interés.</summary>
    /// <param name="x">La coordenada x o latitud.</param>
    /// <param name="y">La coordenada y o longitud.</param>
    /// <param name="nombre">El nombre del punto de interés.</param>
    public POI(double x, double y, string nombre)
    {
        X = x;
        Y = y;
        Nombre = nombre;
    }

    /// <summary>La coordenada x o latitud.</summary>
    public double X { get; init; }

    /// <summary>La coordenada y o longitud.</summary>
    public double Y { get; init; }

    /// <summary>El nombre del punto de interés.</summary>
    public string Nombre { get; init; }

    public override string ToString()
    {
        return $"{Nombre}: ({X}, {Y})";
    }
}