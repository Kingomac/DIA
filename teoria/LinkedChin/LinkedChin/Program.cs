// See https://aka.ms/new-console-template for more information

using LinkedChin;

var c1 = new Contacto()
{
    Nombre = "Mario",
    Apellidos = "Vila Comesaña",
    Email = "vcmario@gmail.com",
    FechaNacimiento = new DateTime(2002, 2, 26),
    Habilidades = new List<Habilidad>()
    {
        new Habilidad()
            { FechaComienzo = new DateTime(2019, 9, 24), Tipo = Habilidad.TipoHabilidad.Arte, Titulo = "Dibujo a carboncillo" },
        new Habilidad()
            { FechaComienzo = new DateTime(2020, 2, 20), Tipo = Habilidad.TipoHabilidad.Arte, Titulo = "Dibujo en perspectiva cónica con 2 puntos de fuga"},
        new Habilidad()
            {FechaComienzo = new DateTime(2021, 3, 14), Tipo = Habilidad.TipoHabilidad.Diseño, Titulo = "Diseño de interfaces web"},
    }
};

Console.WriteLine(c1);

var jsonContacto = new JsonContacto() { Contacto = c1 };
jsonContacto.Save("contacto.json");
Contacto c2 = JsonContacto.Load("contacto.json");
Console.WriteLine(c2);
