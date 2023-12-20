using System;
using System.Collections.Generic;

namespace ColeccionCoches.Core;

public class RegistroCoches
{
    public RegistroCoches()
    {
        this.coches = new List<Coche>();
    }

    /// <summary>
    /// Devuelve el coche en la posición <paramref name="pos"/>
    /// </summary>
    /// <param name="pos">Posición del coche en la lista</param>
    /// <returns>El objeto <see cref="Coche"/></returns>
    /// <exception cref="ArgumentException">Si la posición es incorrecta</exception>
    public Coche Get(int pos)
    {
        if (pos < 0 || pos >= this.Count)
        {
            throw new ArgumentException($"{nameof(pos)} incorrecto: " + pos);
        }

        return this.coches[pos];
    }

    public int Count => coches.Count;

    public void Add(Coche c)
    {
        this.coches.Add(c);
    }

    public void Modifica(int pos, string color)
    {
        if (pos < 0 || pos >= this.Count)
        {
            throw new ArgumentException($"{nameof(pos)} incorrecto: " + pos);
        }
        this.coches[pos].Color = color;
    }

    private List<Coche> coches;
}