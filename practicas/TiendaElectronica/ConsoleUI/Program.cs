using ConsoleUI.Menu;
using TiendaElectronica.Core;
using TiendaElectronica.Core.Aparatos;
using TiendaElectronica.Core.Reparaciones;

namespace ConsoleUI;

public class Program
{
    public static void Main(string[] args)
    {
        var archivo = new ArchivoReparaciones();
        var seguir = true;
        while (seguir)
            ConsoleMenu.Run(
                "Selecciona una acción:",
                new Dictionary<string, Action>
                {
                    {
                        "Nueva reparación", () => archivo.Add(NuevaReaparacion())
                    },
                    { "Ver listado", () => { } },
                    {
                        "Salir", () =>
                        {
                            archivo.GuardarFichero();
                            seguir = false;
                        }
                    }
                }
            );
    }

    private static Reparacion NuevaReaparacion()
    {
        Aparato? aparato = null;
        Console.WriteLine("Nueva reparación");
        Console.WriteLine("Introduce los datos del aparato");
        var numeroSerie = ConsoleMenu.AskForNumber<uint>("Número de serie");
        var modelo = ConsoleMenu.AskForString("Modelo");
        ConsoleMenu.Run("Elige el tipo de aparato:", new Dictionary<string, Action>
        {
            {
                "Radio", () => aparato = new Radio
                {
                    NumeroSerie = numeroSerie,
                    Modelo = modelo,
                    BandasSoportadas = ConsoleMenu.AskForEnum<BandasRadio>("Bandas soportadas")
                }
            },
            {
                "Televisor", () => aparato = new Televisor
                {
                    NumeroSerie = numeroSerie,
                    Modelo = modelo,
                    Pulgadas = ConsoleMenu.AskForNumber<double>("Pulgadas")
                }
            },
            {
                "Reproductor DVD", () => aparato = new ReproductorDVD
                {
                    NumeroSerie = numeroSerie,
                    Modelo = modelo,
                    BlueRay = ConsoleMenu.AskForBool("Soporta Blue-Ray?"),
                    TiempoGrabacion = ConsoleMenu.AskForNumber<double>("Tiempo grabación")
                }
            },
            {
                "Adaptador TDT", () => aparato = new AdaptadorTDT
                {
                    NumeroSerie = numeroSerie,
                    Modelo = modelo,
                    TiempoMaximoGrabacion = ConsoleMenu.AskForNumber<double>("Tiempo máximo de grabación")
                }
            }
        });
        var horasTrabajadas = ConsoleMenu.AskForNumber<double>("Horas trabajadas");
        var costePiezas = ConsoleMenu.AskForNumber<double>("Coste de piezas");
        return Reparacion.Create(aparato ?? throw new Exception(), horasTrabajadas, costePiezas);
    }

    private static void Titulo()
    {
        Console.WriteLine("""
                              ________________________ _       ______  _______
                              \__   __|__   __(  ____ ( (    /(  __  \(  ___  )
                                 ) (     ) (  | (    \/  \  ( | (  \  ) (   ) |
                                 | |     | |  | (__   |   \ | | |   ) | (___) |
                                 | |     | |  |  __)  | (\ \) | |   | |  ___  |
                                 | |     | |  | (     | | \   | |   ) | (   ) |
                                 | |  ___) (__| (____/\ )  \  | (__/  ) )   ( |
                           ______)_(  \_______(_______//____)_|______/|/__ __\|___ _      ________________ _______
                          (  ____ ( \     (  ____ (  ____ \__   __(  ____ |  ___  | (    /\__   __(  ____ (  ___  )
                          | (    \/ (     | (    \/ (    \/  ) (  | (    )| (   ) |  \  ( |  ) (  | (    \/ (   ) |
                          | (__   | |     | (__   | |        | |  | (____)| |   | |   \ | |  | |  | |     | (___) |
                          |  __)  | |     |  __)  | |        | |  |     __) |   | | (\ \) |  | |  | |     |  ___  |
                          | (     | |     | (     | |        | |  | (\ (  | |   | | | \   |  | |  | |     | (   ) |
                          | (____/\ (____/\ (____/\ (____/\  | |  | ) \ \_| (___) | )  \  |__) (__| (____/\ )   ( |
                          (_______(_______(_______(_______/  )_(  |/   \__(_______)/    )_)_______(_______//     \|


                          """);
    }
}