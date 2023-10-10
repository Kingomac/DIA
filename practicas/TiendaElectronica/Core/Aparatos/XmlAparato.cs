using System.Xml.Linq;

namespace TiendaElectronica.Core.Aparatos;

public class XmlAparato
{
    public static XElement ToXml(Aparato ap)
    {
        var el = new XElement(ap.GetType().Name);
        el.SetAttributeValue(nameof(ap.NumeroSerie), ap.NumeroSerie);
        el.SetAttributeValue(nameof(ap.Modelo), ap.Modelo);
        AddAttributes(el, ap);
        return el;
    }

    private static void AddAttributes(XElement el, Aparato ap)
    {
        if (ap.GetType() == typeof(Radio)) AddAttributes(el, (Radio)ap);
        else if (ap.GetType() == typeof(Televisor)) AddAttributes(el, (Televisor)ap);
        else if (ap.GetType() == typeof(ReproductorDVD)) AddAttributes(el, (ReproductorDVD)ap);
        else if (ap.GetType() == typeof(AdaptadorTDT)) AddAttributes(el, (AdaptadorTDT)ap);
    }

    private static void AddAttributes(XElement el, Radio rep)
    {
        el.SetAttributeValue(nameof(rep.BandasSoportadas), rep.BandasSoportadas);
    }

    private static void AddAttributes(XElement el, Televisor rep)
    {
        el.SetAttributeValue(nameof(rep.Pulgadas), rep.Pulgadas);
    }

    private static void AddAttributes(XElement el, ReproductorDVD rep)
    {
        el.SetAttributeValue(nameof(rep.BlueRay), rep.BlueRay);
        el.SetAttributeValue(nameof(rep.TiempoGrabacion), rep.TiempoGrabacion);
    }

    private static void AddAttributes(XElement el, AdaptadorTDT rep)
    {
        el.SetAttributeValue(nameof(rep.TiempoMaximoGrabacion), rep.TiempoMaximoGrabacion);
    }
}