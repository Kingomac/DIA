// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using ProgramacionPorContrato;

Trace.Listeners.Add(new ConsoleTraceListener());
Trace.Listeners.Add(new TextWriterTraceListener("trace.log"));

var lista = new Lista<int>();

lista.Inserta(11);
lista.Inserta(22);
lista.Inserta(33);
lista.Inserta(44);
lista.Inserta(55);

Console.WriteLine($"#l == {lista.Count}");
lista.IrPpio();

while (!lista.EsFinal())
{
    Console.WriteLine("Elemento: " + lista.Actual.Elemento.ToString());
    lista.IrSig();
}

Trace.Close();
