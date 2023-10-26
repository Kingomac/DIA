# Notas examen parcial 1

Estas notas hacen referencia a la corrección del examen del curso 2022/23 en [Ideone](https://ideone.com/q0stD5).

## Devolver una colección inmutable

```c#
var numeros = new List<int>();
// para devolver una colección que el usuario no puede modificar
// 1. Clonas la lista
numeros.ToList();
// 2. Clonas la lista como inmutable
numeros.ToImmutableList();
// 3. La mejor opción, no clona la lista sino que comprueba que no se
// modifique en tiempo de ejecución desde esa referencia que se ha devuelto
numeros.AsReadOnly();
```

## Formateo de strings

Cuando quieres meter mucha información en un método `ToString()`

```c#
List<Coche> coches = new List<Coche>();
// se llena de coches
// 1. Usar StringBuilder
StringBuilder sb = new StringBuilder();
foreach(var c in coches) {
    sb.AppendLine(c);
}
sb.ToString();
// 2. string.join
string.join("\n", coches);
```

## Ordenar

1. Aprender clase `Comparer`
2. ` this.coches.Sort( (b1, b2) => b1.Puesto - b2.Puesto );`

La operación que se realiza debe dar -1 o 1 según la posición deseada del elemento.

## Constructores múltiples

Para no repetir código debes hacer esto:

```c#
public Carrera() {
    this.bolidos = new List<Bolido>();
}
public Carrera(IEnumerable<Bolido> bolidos) : this() {
    // opción 1 - más lenta
    foreach(var bolido in bolidos) {
        this.Inserta(bolido);
    }
    // opción 2 - solo ordena 1 vez
    this.bolidos.AddRange(bolidos);
	this.Ordena();
}
```

## XML

En clase lo hizo distinto al ejemplo, guardó todo en atributos en vez de hacer una etiqueta para cada propiedad de la clase `Carrera`, pero que usando XML de Linq es lo mismo, solo que en vez de pasar `XElement` pasas `XAttribute`.

En el código de recuperar cambia que hace la selección de elementos `<bolido>` sobre la query de recuperar el elemento raíz `<carrera>`, si no se hiciese funcionaría igual, como en el ejemplo porque al hacer `raiz.Elements("bolido")` busca todos los elementos `<bolido>` en sus elementos hijos.



Importante: no hacer `XElement.ToString()` porque esto devolvería la etiqueta completa en XML como `<bolido piloto="Alonso" .. />` en lugar del valor deseado. Para ello seguir el patrón:

```c#
string piloto = ((string?) bolidoXML.Attribute("piloto")) ?? "";
```

Así, en caso de que falle se recupera sustituyendo el valor por cadena vacía. En base al resultado puedes lanzar excepciones o gestionarlo como quieras.