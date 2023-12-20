using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace LinkedChin;

public class Contacto
{
    // Nombre, apellidos, fecha de nacimiento, email
    public required string Nombre { get; init; }
    public required string Apellidos { get; init; }
    [JsonIgnore]
    public string NombreCompleto => string.Join(" ", Nombre, Apellidos);
    public required DateTime FechaNacimiento { get; init; }

    public required IEnumerable<Habilidad> Habilidades
    {
        get
        {
            return _habilidades.AsReadOnly();
        }
        init
        {
            _habilidades.AddRange(value);
        }
    }

    public required string Email { get; set; }

    private List<Habilidad> _habilidades = new List<Habilidad>();

    public void InsertarHabilidad(Habilidad hab)
    {
        _habilidades.Add(hab);
    }

    public override string ToString()
    {
        return $"{Nombre} {Apellidos} {FechaNacimiento.ToString("dd/MM/yyyy")}:\n\t{string.Join("\n\t", Habilidades)}";
    }
}