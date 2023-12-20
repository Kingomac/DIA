namespace SobrecargaOperadores;

public class CoordenadaPolar
{
    public required double Angulo { get; init; }
    public required double Distancia { get; init; }

    public override string ToString()
    {
        return $"@{Angulo}, {Distancia}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is CoordenadaPolar cp) return Distancia == cp.Distancia && Angulo == cp.Angulo;

        return false;
    }

    public override int GetHashCode()
    {
        // 1234 = 1 * 10^4
        //       + 2 * 10^3
        //       + 3 * 10^2
        //       + 4 * 10^1
        // al multipicar los valores por números primos distintos y sumarlos
        // se obtendrán siempre valores de hashcode sin colisiones
        return (11 * Angulo + 7 * Distancia).GetHashCode();
    }

    public static bool operator ==(CoordenadaPolar c1, CoordenadaPolar c2)
    {
        var toret = false;
        if (c1 is not null) toret = c1.Equals(c2);

        return toret;
    }

    public static bool operator !=(CoordenadaPolar c1, CoordenadaPolar c2)
    {
        return !(c1 == c2);
    }
}