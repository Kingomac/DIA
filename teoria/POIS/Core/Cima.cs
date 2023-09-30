namespace POIS.Core;

public class Cima : POI
{
    /// <summary>Crea una cima como punto de interés.</summary>
    /// <param name="x">La coordenada x o latitud.</param>
    /// <param name="y">La coordenada y o longitud.</param>
    /// <param name="nombre">El nombre del punto de interés.</param>
    /// <param name="altura">La altura del punto de interés.</param>
    public Cima(double x, double y, string nombre, double altura)
        : base(x, y, nombre)
    {
        Altura = altura;
    }

    // <summary>La altura de esta cima.</summary>
    public double Altura { get; init; }

    public override string ToString()
    {
        return $"cima {base.ToString()}, {Altura} m.";
    }
}