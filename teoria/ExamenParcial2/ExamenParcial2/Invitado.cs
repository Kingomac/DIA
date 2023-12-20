using System.Transactions;
using Microsoft.VisualBasic;

namespace ExamenParcial2;

using System;
using System.Diagnostics;

public class Invitado :IComparable<Invitado>
{

    public Invitado(string nombre) : this(nombre, Array.Empty<string>())
    {
    }

    public Invitado(string nombre, params string[] exparejas)
    {
        // Precondiciones
        ChkNombre(nombre);
        
        Nombre = Formatea(nombre);
        _exParejas = new List<string>(exparejas);
        
        //Invariante
        Invariante();
    }
    private static string Formatea(string n)
    {
        return n.Trim().ToLower();
    }

    public void InsertarExPareja(string expareja)
    {
        _exParejas.Add(expareja);
        // Invariante
        Invariante();
    }

    public int NumExParejas => _exParejas.Count;

    public IReadOnlyList<string> ExParejas
    {
        get => _exParejas.AsReadOnly();
        set
        {
            foreach (var el in value)
            {
                _exParejas.Add(el);
            }
        }
    }

    public int CompareTo(Invitado? other)
    {
        /*
         * Forma 1
         *
        var toret = -1;
        if (other is not null)
        {
            if (NumExParejas == other.NumExParejas)
            {
                for (var i = 0; i < NumExParejas; i++)
                {
                    if (this._exParejas[i] != other._exParejas[i])
                    {
                        toret = -1;
                        break;
                    }
                }
            } else if (NumExParejas > other.NumExParejas)
            {
                toret = 1;
            }

        }

        return toret;*/

        var toret = -1;
        if (other is not null)
        {
            toret = NumExParejas - other.NumExParejas;

            if (toret == 0)
            {
                for (var i = 0; i < NumExParejas; i++)
                {
                    if (this._exParejas[i] != other._exParejas[i])
                    {
                        toret = -1;
                        break;
                    }
                }
            }
        }

        return toret;
    }

    public string this[int i]
    {
        get
        {
            if (i < 0 || i >= NumExParejas)
            {
                throw new ArgumentException("[i]: " + i + " está fuera de los límites de la lista");
            }
            return _exParejas[i];
        }
    }

    public override int GetHashCode()
    {
        int toret = Nombre.GetHashCode();
        foreach (var ex in ExParejas)
        {
            toret += 11 * ex.GetHashCode();
        }

        return toret;
    }

    public override bool Equals(object? obj)
    {
        var toret = false;
        if (obj is Invitado otro)
        {
            toret = Nombre == otro.Nombre;

            if (toret)
            {
                toret = CompareTo(otro) == 0;
            }
        }

        return false;
    }
    
    public static bool operator&(Invitado? a, Invitado? b)
    {
        return    a is not null 
               && b is not null
               && !b._exParejas.Contains(a.Nombre)
               && !a._exParejas.Contains(b.Nombre);
    }

    public override string ToString()
    {
        return $"{Nombre}: {string.Join(", ", _exParejas)}";
    }

    private void ChkNombre(string n)
    {
        Debug.Assert(string.IsNullOrEmpty(n), "nombre no puede ser vacío");
        foreach (var ch in n)
        {
            Debug.Assert(char.IsLetter(ch), "nombre no puede haber puntuación");
        }
    }

    private void Invariante()
    {
        Debug.Assert(NumExParejas <= 10, "no puede haber más de 10 exparejas");
    }

    public string Nombre { get; }
    
    private IList<string> _exParejas;
}