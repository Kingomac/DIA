using System.Xml.Linq;
using TiendaElectronica.Core.Reparaciones;

namespace TiendaElectronica.Core;

public class ArchivoReparaciones
{
    private List<Reparacion> Reparaciones { get; }
    private const string NOMBRE_FICHERO = "reparaciones.xml";

    public ArchivoReparaciones()
    {
        this.Reparaciones = new List<Reparacion>();
        if (File.Exists(NOMBRE_FICHERO))
        {
            var els = XElement.Load(NOMBRE_FICHERO);
        }
    }

    public void GuardarFichero()
    {
        var padreReps = new XElement("lista-reparaciones");
        foreach (var rep in Reparaciones)
        {
            padreReps.Add($"rep-{rep.GetType().Name.ToLower()}", rep);
        }
    }

    public void Add(Reparacion rep)
    {
        this.Reparaciones.Add(rep);
    }

    public IEnumerator<Reparacion> GetEnumerator()
    {
        return this.Reparaciones.GetEnumerator();
    }
    
    
    
}