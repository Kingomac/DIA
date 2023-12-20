namespace SobrecargaOperadores;

public class Conjunto<T>
{
    private readonly List<T> _elementos = new();

    public IList<T> Elementos
    {
        get => _elementos.AsReadOnly();
        private set
        {
            _elementos.Clear();
            _elementos.AddRange(value);
        }
    }

    public int Count => _elementos.Count;

    public T this[int i]
    {
        get
        {
            if (i < 0 || i >= Count) throw new ArgumentException(nameof(i) + " = " + i);

            return _elementos[i];
        }
        set
        {
            if (i < 0 || i >= Count) throw new ArgumentException(nameof(i) + " = " + i);

            _elementos[i] = value;
        }
    }

    public void Inserta(T x)
    {
        if (!Tiene(x)) _elementos.Add(x);
    }

    public bool Tiene(T x)
    {
        return _elementos.Contains(x);
    }

    public static Conjunto<T> operator +(Conjunto<T> c1, T e1)
    {
        var toret = new Conjunto<T>();
        toret.Elementos = c1.Elementos;
        toret.Inserta(e1);
        return toret;
    }

    public static Conjunto<T> operator +(T e1, Conjunto<T> c1)
    {
        return c1 + e1;
    }

    public override string ToString()
    {
        return string.Join(", ", _elementos);
    }
}