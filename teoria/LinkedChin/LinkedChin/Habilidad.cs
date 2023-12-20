using System.Text.Json.Serialization;

namespace LinkedChin;

public class Habilidad
{
    public enum TipoHabilidad
    {
        Programacion,
        Diseño,
        Arte,
        Otro
    }
    
    public required TipoHabilidad Tipo { get; init; }
    public required DateTime FechaComienzo { get; init; }

    [JsonIgnore]
    public int MesesExperiencia
    {
        get
        {
            return (DateTime.Now.Month - FechaComienzo.Month) + (DateTime.Now.Year - FechaComienzo.Year) * 12;
        }
    }

    public required string Titulo { get; init; }

    public override string ToString()
    {
        return $"{Titulo} ({Tipo}): {MesesExperiencia} meses";
    }
}