using System.Text;

namespace FondoMarino.Core;

public class Celda
{
    private double _profundidad;
    public required double Profundidad
    {
        get => _profundidad;
        init
        {
            if (value > 0) throw new ArgumentOutOfRangeException("La profundidad debe ser menor o igual a 0");
            _profundidad = value;
        }
    }

    public required uint X { get; init; }
    public required int Y { get }


    public String ToString()
    {
        return $"{this.GetType().Name.ToLower()} "
    }
    
}