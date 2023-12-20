namespace LinkedChin;

using System.Text.Json;

public class JsonContacto
{
    public required Contacto Contacto { get; init; }

    public void Save(string nf)
    {
        using (var f = new FileStream(nf, FileMode.Create))
        {
            JsonSerializer.Serialize(f, Contacto);
        }
    }

    public static Contacto? Load(string nf)
    {
        Contacto? toret = null;
        try
        {
            using (var f = new FileStream(nf, FileMode.Open))
            {
                toret = JsonSerializer.Deserialize<Contacto>(f);
            }
        }
        catch (Exception e) when
            (e is JsonException or IOException)
        {
            throw new JsonException(e.Message);
        }
        return toret;
    }
}