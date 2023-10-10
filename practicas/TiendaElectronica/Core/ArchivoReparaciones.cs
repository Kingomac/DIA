using System.Xml.Linq;
using TiendaElectronica.Core.Reparaciones;

namespace TiendaElectronica.Core;

public class ArchivoReparaciones
{
    private const string NOMBRE_FICHERO = "reparaciones.xml";

    public ArchivoReparaciones()
    {
        Reparaciones = new List<Reparacion>();
        if (File.Exists(NOMBRE_FICHERO))
        {
            var els = XElement.Load(NOMBRE_FICHERO);
            foreach (var el in els.Elements())
            {
                Console.WriteLine("localName: " + el.Name.LocalName);
                Reparaciones.Add(XmlReparacion.FromXml(el));
            }
        }
    }

    private List<Reparacion> Reparaciones { get; }

    public void GuardarFichero()
    {
        var padreReps = new XElement("ListaReparaciones");
        foreach (var rep in Reparaciones)
            padreReps.Add(XmlReparacion.ToXml(rep));

        var stream = File.Open("reparaciones.xml", FileMode.Create, FileAccess.Write);
        padreReps.Save(stream);
    }

    public void Add(Reparacion rep)
    {
        Reparaciones.Add(rep);
    }

    public IEnumerator<Reparacion> GetEnumerator()
    {
        return Reparaciones.GetEnumerator();
    }
}