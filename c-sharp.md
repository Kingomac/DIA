# Apuntes C#

- [Apuntes C#](#apuntes-c)
- [Propiedades](#propiedades)
  - [Modificadores](#modificadores)
    - [init](#init)
    - [required](#required)
- [Colecciones](#colecciones)
  - [Ejemplos con listas](#ejemplos-con-listas)
    - [Fibonacci](#fibonacci)
    - [Lista a string](#lista-a-string)
      - [StringBuilder](#stringbuilder)
      - [String.join()](#stringjoin)
  - [Tipos e interfaces de colecciones](#tipos-e-interfaces-de-colecciones)
  - [Ejemplos vectores primitivos](#ejemplos-vectores-primitivos)
  - [Filtrar colecciones](#filtrar-colecciones)
    - [Where](#where)
    - [Exists](#exists)
- [Funciones Lambda](#funciones-lambda)
  - [Ejemplos](#ejemplos)
    - [Fibonacci](#fibonacci-1)
    - [String from list](#string-from-list)
- [XML](#xml)
  - [Ejemplo - Fibonacci sin posición](#ejemplo---fibonacci-sin-posición)
    - [Ejemplo - Fibonacci con posición](#ejemplo---fibonacci-con-posición)
    - [Filtrado con Linq](#filtrado-con-linq)
      - [Sintaxis similar a SQL](#sintaxis-similar-a-sql)
      - [Sintaxis de filtros de listas de C#](#sintaxis-de-filtros-de-listas-de-c)
- [Clases](#clases)
  - [Modificadores de acceso](#modificadores-de-acceso)
  - [Herencia](#herencia)
    - [sealed](#sealed)
  - [Sobrescritura de métodos](#sobrescritura-de-métodos)
  - [Polimorfismo](#polimorfismo)


# Propiedades

Las propiedades son estructuras (usualmente públicas) que contienen "getters" y "setters", de forma que pueden ser tratadas como variables, pero, aun así tener funciones que se ejecuten en su lectura y escritura.

Para ilustrarlo pensemos en las características de un Pokémon:

```c#
public class Pokemon
{
    //...
    public uint Id { get; }
    public string Nombre { get; }
    public string Apodo { get; set; }
    //...
}
```

En este caso aparecen 3 propiedades básicas, `Id` y `Nombre` solo contienen el método `get` que se usa el por defecto, ya que son de solo lectura y el `Apodo` contiene `get`y `set` porque se puede modificar.

El siguiente es un ejemplo de cómo se podría crear la propiedad `Ps`, que sería la salud del Pokémon, y que se calcula usando las estadísticas base.

```c#
public class Pokemon
{
    public int PsBase { get; }
    public byte IvPs { get; }
    public byte EvPs { get; set; }
    public string Naturaleza { get; }
    public int Ps => (5 + (Nivel / 100 * (PsBase * 2 + IvPs + EvPs))) * GetValorNaturaleza("PS", Naturaleza);

}
```

Por último, un ejemplo de cómo se comprueban las asignaciones del nivel, ya que este solo puede subir de uno en uno y debe estar entre 1 y 100 incluidos. Cuando se llega a nivel 100, el nivel deja de incrementarse y como su valor por defecto es 1 cumplirá sus restricciones.

```c#
public class Pokemon
{
    private int _nivel = 1;

    public int Nivel
    {
        get => _nivel;
        set
        {
            if (value != _nivel + 1)
            {
                throw new Exception("Los niveles suben de 1 en 1");
            }

            if (value <= 100)
            {
                _nivel = value;
            }
        }
    }   
}
```



## Modificadores

### init

Palabra clave que define un método de incialización de de una propiedad, de forma, que cuando defines el objeto puedes indicar el valor de la propiedad. Esta propiedad sustituye a `set;` y solo permite asignar su valor en la inicialización.

```c#
public class Pokemon
{
    public string Nombre { get; init; }
    private int id;
    
    public Pokemon(int id)
    {
        this.id = id;
    }
}
```

```C#
var a = new Pokemon(25);
var b = new Pokemon(25) { Nombre = "Pikachu"};
```



### required

Palabra clave que indica que es necesario inicializar la propiedad cuando se construya el objeto. Se puede usar con propiedades o campos y solo se puede usar en elementos de tipo `public`

```c#
public class Pokemon
{
    public required string Nombre { get; init; }
    private int id;

    public Pokemon(int id)
    {
        this.id = id;
    }
}
```

```c#
//var a = new Pokemon(25);
var b = new Pokemon(25) { Nombre = "Pikachu"};
```

### private

Los getters y setters de las propiedades pueden ser privados. Sin embargo, solo uno de los dos puede serlo,  getter o setter.





# Colecciones

Se encuentran en la directiva `using System.Collections`

## Ejemplos con listas

### Fibonacci

```c#
static List<int> Fibo(int n)
{
    var toret = new List<int>();

    if (n == 1)
    {
        toret.Add(1);
    }
    else if (n == 2)
    {
        toret.AddRange(new int[] { 1, 1 });
    }
    else if (n > 2)
    {
        List<int> prev = Fibo(n - 1);
        int sig = prev[ /*prev.Count-1*/ ^1] + prev[prev.Count - 2];
        prev.Add(sig);
        toret = prev;
    }

    return toret;
}
```

### Lista a string

#### StringBuilder

```c#
static string StringFromList<T>(List<T> l)
{
    StringBuilder toret = new StringBuilder();
    const string sep = ", ";
    foreach (T x in l)
    {
        toret.Append($"{x}{sep}");
    }

    return toret.ToString();
}
```

#### String.join()

```c#
static string StringFromList<T>(List<T> l) string.Join(",", l);
```



## Tipos e interfaces de colecciones

| Tipo                            | Función                                                      |
| ------------------------------- | ------------------------------------------------------------ |
| `IEnumerable`                   | Interfaz que permite iterar sobre una estructura. Equivalente en Java a `Iterable` |
| `IEnumerator`                   | Interfaz que lleva el puntero next sobre la iteración. Equivalente en Java a `Iterator` |
| `ICollection`                   | Interfaz que tiene métodos para modificar una colección      |
| `List` y `List<T>`              | Lista                                                        |
| `Stack` y `Stack<T>`            | Pila                                                         |
| `Queue` y `Queue<T>`            | Cola                                                         |
| `HashTable` y `Dictionary<T,U>` | Tabla hash o diccionario                                     |

## Ejemplos vectores primitivos

```c#
int[] numeros = new int[23];
int[] numeros2 = new int[] { 1, 2, 3 };
int[] numeros3 = new int[3] { 1, 2, 3 };

for (var i = 0; i < numeros.Length; i++)
{
    Console.WriteLine($"{i}: {numeros[i]}");
}

foreach (var numero in numeros2)
{
    Console.WriteLine(numero);
}
```

## Filtrar colecciones

### Where

Filtrar valores de Fibonacci pares.

```c#
IEnumerable<int> fibos30 = Fibo(30);
fibos30 = fibos30.Where(x => x % 2 == 0);
```

### Exists

```c#
if (fibos30.ToList().Exists(x => x == 42))
{
    Console.WriteLine("fibos30 tiene el sentido de la vida");
}
else
{
    Console.WriteLine("fibos30 no tiene el sentido de la vida);
}
```



# Funciones Lambda

Son funciones que se declaran como variables y permiten programar con un paradigma funcional en C#.

## Ejemplos

### Fibonacci

```c#
Func<int, List<int>> lambdaFibo = null;        
lambdaFibo = (int n) =>
{
    var toret = new List<int>();
    if (n == 1)
    {
        toret.Add(1);
    }
    else if (n == 2)
    {
        toret.AddRange(new int[] { 1, 1 });
    }
    else if (n > 2)
    {
        List<int> prev = lambdaFibo(n - 1);
        int sig = prev[ /*prev.Count-1*/ ^1] + prev[prev.Count - 2];
        prev.Add(sig);
        toret = prev;
    }
    return toret;
};
```

### String from list

```c#
Func<List<int>, string> lambdaStringFromList = (List<int> l) => string.Join(",", l); // versión 1
// versión 2
Func<List<int>, string> lambdaStringFromList = null;
lambdaStringFromList = (List<int> l) =>
{
    var toret = new StringBuilder();
    if (l.Count == 1)
    {
        toret.Append(l[0]);
    }
    else if (l.Count > 1)
    {
        toret.Append(lambdaStringFromList(l.Take(l.Count - 1).ToList()));
        toret.Append(", ");
        toret.Append(l[^1]);
    }

    return toret.ToString();
};
```

# XML

## Ejemplo - Fibonacci sin posición

Un fichero que sea:

```xml
<lista>
    <elemento>1</elemento>
    <elemento>1</elemento>
    <elemento>3</elemento>
</lista>
```

```c#
using System.XML.Linq;    

static void GuardarXML<T>(string fn, IEnumerable<T> l)
{
    var ppa1 = new XElement("lista");
    foreach (T x in l)
    {
        ppa1.Add(new XElement("elemento", x.ToString()));
    }
    ppa1.Save(fn);
}

static void RecuperarXML(string fn)
{
    var ppal = XElement.Load(fn);
    foreach (var elto in ppal.Elements("elemento"))
    {
        Console.WriteLine(elto.Value);
    }
}
```

### Ejemplo - Fibonacci con posición

```xml
<lista>
    <elemento pos="0">1</elemento>
    <elemento pos="1">1</elemento>
    <elemento pos="2">3</elemento>
</lista>
```

```c#
static void GuardarXML<T>(string fn, IEnumerable<T> l)
{
    var ppa1 = new XElement("lista");
    int num = 0;
    foreach (T x in l)
    {
        ppa1.Add(new XElement("elemento",
                              new XAttribute("pos", num),
                              new XElement("valor", x.ToString())));
        num++;
    }
    ppa1.Save(fn);
}

static void RecuperarXML(string fn)
{
    var ppal = XElement.Load(fn);
    foreach (var elto in ppal.Elements("elemento"))
    {
        Console.WriteLine($"{elto.Value}: pos -> {elto.Attribute("pos")}");
    }
}
```

### Filtrado con Linq

#### Sintaxis similar a SQL

```c#
static void RecuperarXML(string fn)
{
    var ppal = XElement.Load(fn);
    var resultado = from x in ppal.Elements()
        where Convert.ToInt32(x) % 2 == 0
        select x;
}
```

#### Sintaxis de filtros de listas de C#

```c#
static void RecuperarXML(string fn)
{
    var ppal = XElement.Load(fn);
    var xmlPares = ppal.Elements()
        .Select(x => Convert.ToInt32(x.Element("valor").Value))
        .Where(x => x % 2 == 0);
}
```



# Clases

```c#
<modificador de acceso> class <identificador>
{
	<campos>
    <propiedades>
    <métodos>
    ...
}
```



## Modificadores de acceso

- `public`: accesible para todas las clases.
- `private`: solo accesible desde la misma clase.
- `protected`: accesible desde la misma clase o clases que hereden de esa clase.
- `internal`: solo accesible desde su mismo ¿assembly?

Se pueden combinar como `protected internal` o `private protected`



## Herencia

```c#
public class Vehiculo
{
    public required string marca;

    private double precio;

    public Vehiculo(double precio)
    {
        this.precio = precio;
    }
}
public class Coche : Vehiculo
{
    public Coche(double precio) : base(precio) {}
    public void pitar()
    {
        Console.WriteLine("piiiiii");
    }
}
public class Program {
    public static void Main(string[] args)
    {
    	Coche a = new Coche(7777.77) { marca = "Nissan"};
        a.pitar();
    }
}

```

### sealed

Si quieres que una clase no pueda tener clases heredadas debes añadirle el modificador `sealed`. Siguiendo el ejemplo anterior, si `Vehiculo` fuese `sealed` el compilador generaría un error.

```c#
public sealed class Vehiculo //...
public class Coche : Vehiculo // sería incorrecto y marcado como error por el compilador
```

### partial

Es posible definir una clase en varios ficheros usando la directiva `partial`, por ejemplo:

`fichero1.cs`

```c#
partial class Cat {
    public void Miau() { Console.WriteLine("miau"); }
}
```

`fichero2.cs`

```c#
partial class Cat : Animal {
    public void Scratch() { Console.WriteLine("scratch sofa"); }
}
```

Esto sería equivalente a:

```c#
partial class Cat : Animal {
    public void Miau() { Console.WriteLine("miau"); }
    public void Scratch() { Console.WriteLine("scratch sofa"); }
}
```



## Sobrescritura de métodos

Para sobrescribir un método solo hay que declarar el método en la clase derivada con la misma cabecera que la clase base añadiendo el modificador `override`.

```c#
class Pokemon
{
	//..
    public override string ToString()
    {
    	return Nombre;    
    }
}
```

Sin embargo, para poder sobrescribir un método debe estar indicado que puede ser sustituido en la clase base con el modificador `virtual`.

```c#
public class Object
{
	    public virtual string ToString()
        {
            //...
        }
}
```

Esto no debe confundirse con `abstract`, ya que los métodos `virtual` no tienen que estar en una clase abstracta y necesitan una implementación, que será ejecutada por objetos de su misma clase u objetos de clases derivadas que no sobrescriban el método.

## Polimorfismo

Ver ejemplo en [teoria/POIS](teoria/POIS/).
