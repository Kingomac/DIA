using POIS.Core;

namespace POIS.UI;

internal static class Program
{
    private static void Main()
    {
        var poi1 = POIFactoria.CreaEdificio(
            42.3448544,
            -7.8554628,
            "ESEI",
            "Edificio Politécnico s/n, 32004 Ourense");

        var poi2 = POIFactoria.CreaCima(
            42.3496883,
            -7.6115698,
            "Monte Meda",
            1316);

        var poi3 = POIFactoria.CreaPoblacion(
            42.2912947,
            -8.1642931,
            "Ribadavia",
            5003);

        Console.WriteLine(poi1);
        Console.WriteLine(poi2);
        Console.WriteLine(poi3);
    }
}