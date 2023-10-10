using System.Xml.Linq;
using TiendaElectronica.Core.Aparatos;

namespace TiendaElectronica.Core.Reparaciones;

public class XmlReparacion
{
    public static XElement ToXml(Reparacion rep)
    {
        var result = new XElement(rep.GetType().Name);
        result.SetAttributeValue(nameof(rep.HorasTrabajadas), rep.HorasTrabajadas);
        result.SetAttributeValue(nameof(rep.CostePiezas), rep.CostePiezas);
        result.Add(XmlAparato.ToXml(rep.Dispositivo));
        return result;
    }
}