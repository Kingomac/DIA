using Avalonia.Controls;
using Avalonia.Interactivity;
using TiendaElectronica.Core;
using TiendaElectronica.Core.Reparaciones;

namespace GUI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public ArchivoReparaciones ArchivoReparaciones { get; set; } = new();

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        foreach (var rep in ArchivoReparaciones)
        {
            var tipoReparacion = rep.GetType().Name[nameof(Reparacion).Length..];
            AparatosList.Items.Add($"{tipoReparacion}: {rep.Dispositivo.NumeroSerie} - {rep.Dispositivo.Modelo}");
        }
    }

    private void AparatosList_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
    }
}