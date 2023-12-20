// See https://aka.ms/new-console-template for more information

using SobrecargaOperadores;

Console.WriteLine("Operadores:");
var c1 = new Conjunto<int>();

c1.Inserta(4);
c1.Inserta(5);

Console.WriteLine($"{c1 + 6}");


Conjunto<Entero> ce1 = new();
ce1.Inserta(new Entero(34));
ce1 += new Entero(128);
Console.WriteLine($"ce1: {ce1}");

Conjunto<CoordenadaPolar> cp1 = new();
cp1.Inserta(new CoordenadaPolar { Angulo = 90, Distancia = 10 });
cp1 += new CoordenadaPolar { Angulo = 100, Distancia = -21 };
Console.WriteLine($"cp1: {cp1}");

Console.WriteLine("Coordenadas polares almacenadas:");
for (var i = 0; i < cp1.Count; i++) Console.WriteLine($"{i}: ({cp1[i]})");

var cpp1 = new CoordenadaPolar { Angulo = 120, Distancia = 2 };


/*var c2 = new Conjunto<int>();

foreach (var x in new int[] { }) c2.Inserta(x);

Console.WriteLine($"c1: {c1}");
Console.WriteLine($"c2: {c2}");*/