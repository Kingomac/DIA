

using TiendaElectronica.Core;
using TiendaElectronica.Core.Reparaciones;

namespace TiendaElectronica.ConsoleUI;

public class Program
{
    public static void Main(string[] args)
    {
        ArchivoReparaciones archivo = new ArchivoReparaciones();
        Menu();
    }

    private static int Menu()
    {
        int n = 0;
        do
        {
            Console.WriteLine("1. Nueva reparación");
            Console.WriteLine("2. Ver listado");
            Console.WriteLine("3. Salir");
            n = Convert.ToInt32(Console.ReadLine());
        } while (n != 1 && n != 2 && n != 3);

        return n;
    }
    
    private static void NuevaReaparacion()
    {
        Console.WriteLine("Nueva reparación");
        Console.WriteLine("Elige el tipo de aparato:");
        Console.WriteLine("1. Radio");
        Console.WriteLine("2. Televisión");
        Console.WriteLine("3. Reproductor DVD");
        Console.WriteLine("4. Adaptador DVD");

        Reparacion rep;
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