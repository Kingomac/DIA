namespace POIS.Core;

public class Poblacion : POI
{
    /// <summary>Crea una población como punto de interés.</summary>
    /// <param name="x">La coordenada x o latitud.</param>
    /// <param name="y">La coordenada y o longitud.</param>
    /// <param name="nombre">El nombre del punto de interés.</param>
    /// <param name="numHabs">El número de habitantes.</param>
    public Poblacion(double x, double y, string nombre, int numHabs)
        : base(x, y, nombre)
    {
        NumHabitantes = numHabs;
    }

    /// <summary>El número de habitantes.</summary>
    public int NumHabitantes { get; init; }

    public override string ToString()
    {
        return $"población {base.ToString()}, {NumHabitantes} pax";
    }
}