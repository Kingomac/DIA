namespace POIS.Core;

///<summary>Crea diferentes tipos de puntos de interés.</summary>
public static class POIFactoria
{
    /// <summary>Crea un edificio como punto de interés.</summary>
    /// <param name="x">La coordenada x o latitud.</param>
    /// <param name="y">La coordenada y o longitud.</param>
    /// <param name="nombre">El nombre del punto de interés.</param>
    /// <param name="direccion">La dirección postal del punto de interés.</param>
    /// <returns>Un objeto <see cref="Edificio" />.</returns>
    public static Edificio CreaEdificio(double x, double y, string nombre, string direccion)
    {
        return new Edificio(x, y, nombre, direccion);
    }

    /// <summary>
    ///     Crea una población como punto de interés.
    ///     <param name="x">La coordenada x o latitud.</param>
    ///     <param name="y">La coordenada y o longitud.</param>
    ///     <param name="nombre">El nombre del punto de interés.</param>
    ///     <param name="numHabs">El número de habitantes.</param>
    ///     <returns>Un objeto <see cref="Poblacion" />.</returns>
    public static Poblacion CreaPoblacion(double x, double y, string nombre, int numHabs)
    {
        return new Poblacion(x, y, nombre, numHabs);
    }

    /// <summary>
    ///     Crea una cima como punto de interés.
    ///     <param name="x">La coordenada x o latitud.</param>
    ///     <param name="y">La coordenada y o longitud.</param>
    ///     <param name="nombre">El nombre del punto de interés.</param>
    ///     <param name="altura">La altura del punto de interés.</param>
    ///     <returns>Un objeto <see cref="Cima" />.</returns>
    public static Cima CreaCima(double x, double y, string nombre, int altura)
    {
        return new Cima(x, y, nombre, altura);
    }
}