namespace SobrecargaOperadores;

public class Entero
{
    public Entero(int x)
    {
        X = x;
    }

    public int X { get; }

    public static Entero operator +(Entero e1, Entero e2)
    {
        return new Entero(e1.X + e2.X);
    }

    public static bool operator ==(Entero e1, Entero e2)
    {
        return e1.X == e2.X;
    }

    public static bool operator !=(Entero e1, Entero e2)
    {
        return !(e1 == e2);
    }

    public override string ToString()
    {
        return X.ToString();
    }

    public override bool Equals(object? otro)
    {
        var toret = false;
        if (otro is Entero otroEntero) toret = X == otroEntero.X;
        return toret;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode();
    }
}