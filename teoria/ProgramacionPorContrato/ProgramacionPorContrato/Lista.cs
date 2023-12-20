using System.Collections;
using System.Diagnostics;

namespace ProgramacionPorContrato;


// Programación por contrato
// - Precondiciones    -> métodos -> principio de los métodos y garantizan que la tarea se puede llevar a cabo
// - Postcondicinoes   -> métodos -> final de los métodos y garantizan que la tarea se ha llevado a cabo
// - Invariantes       -> clases  -> final de los métodos y garantizan que no se ha violado la razón de ser de la clase
public class Lista<T>
{
    public class Nodo
    {
        public Nodo? Sig { get; set; }
        public Nodo? Prev { get; set; }
        public required T Elemento { get; set; }
    }

    public Lista()
    {
        ppio = null;
        final = null;
    }

    public void Inserta(T elemento)
    {
        // Precondición: elemento no puede ser null
        Debug.Assert(elemento is not null);

        num++;
        if (ppio is null)
        {
            final = ppio = new Nodo(){ Sig = null, Prev = null, Elemento = elemento};
            return;
        }

        var nuevoNodo = new Nodo() { Sig = null, Prev = final, Elemento = elemento };
        final.Sig = nuevoNodo;
        final = nuevoNodo;
        // Postcondición: tengo un nuevo elemento
        Debug.Assert(final.Elemento.Equals(elemento));
        RecorreAdelanteAtras();
    }
    
    // Invariante de la clase: puedo recorrer la adelante y atrás
    [Conditional("DEBUG")]
    private void RecorreAdelanteAtras()
    {
        var conteoAdelante = 1;
        var conteoAtras = 1;
        Nodo it = ppio;
        
        Trace.WriteLine("Recorrido adelante: comenzando");
        
        while (it.Sig != null)
        {
            it = it.Sig;
            conteoAdelante++;
        }
        
        Trace.WriteLine("Recorrido adelante: finalizando");
        Debug.Assert(it == final);
        Debug.Assert(conteoAdelante == num, $"{conteoAdelante} != {num}");
        it = final;
        Trace.WriteLine("Recorrido atrás: comenzando");
        while (it.Prev != null)
        {
            it = it.Prev;
            conteoAtras++;
        }
        Trace.WriteLine("Recorrido atrás: finalizando");
        Debug.Assert(it == ppio);
        Debug.Assert(conteoAtras == num, $"{conteoAdelante} != {num}");
    }

    public void IrPpio()
    {
        actual = ppio;
    }

    public bool EsFinal()
    {
        return actual == null;
    }

    public void IrSig()
    {
        actual = Actual.Sig;
    }

    public void IrPrev()
    {
        actual = Actual.Prev;
    }

    private Nodo? ppio;
    private Nodo? final;
    private int num = 0;

    public int Count => num;

    private Nodo? actual = null;

    public bool EsVacio() => Count == 0;
    
    public Nodo Actual
    {
        get
        {
            return actual;
        }
    }
}