using Avalonia.Controls;
using ColeccionCoches.Core;
using Av = Avalonia.Controls;

namespace ColeccionCoches.UI;

public partial class MainWindow : Av.Window
{
    public MainWindow()
    {
        InitializeComponent();

        var BtSig = this.FindControl<Av.Button>("BtSiguiente");
        var BtAnt = this.FindControl<Av.Button>("BtAnterior");
        var BtInserta = this.FindControl<Av.Button>("BtInserta");
        var BtModifica = this.FindControl<Av.Button>("BtModifica");
        
        // Eventos
        BtSig.Click += (_, _) => this.OnSig();
        BtAnt.Click += (_, _) => this.OnAnt();
        BtInserta.Click += (_, _) => this.OnInserta();
        BtModifica.Click += (_, _) => this.OnModifica();
        // Prepara
        coches = new RegistroCoches();
        this.pos = 0;
        this.Actualiza();
    }

    private void OnInserta()
    {
        var EdModelo = this.FindControl<Av.TextBox>("EdModelo");
        var EdColor = this.FindControl<Av.TextBox>("EdColor");
        this.coches.Add(new Coche()
        {
            Color = EdColor.Text,
            Modelo = EdModelo.Text
        });
        this.Actualiza();
    }

    private void OnModifica()
    {
        var EdColor = this.FindControl<Av.TextBox>("EdColor");
        this.coches.Modifica(this.pos, EdColor.Text);
    }

    private void OnSig()
    {
        if (this.pos < this.coches.Count - 1)
        {
            this.pos++;
        }
        this.Actualiza();
    }

    private void OnAnt()
    {
        if (this.pos > 0)
        {
            this.pos--;
        }

        this.Actualiza();
    }

    public void Actualiza()
    {
        var StLine = this.FindControl<Av.Label>("StLine");
        var numCoches = this.coches.Count;
        
        // Información del coche actual
        if (this.pos >= 0 && this.pos < numCoches)
        {
            var EdModelo = this.FindControl<Av.TextBox>("EdModelo");
            var EdColor = this.FindControl<Av.TextBox>("EdColor");
            var coche = this.coches.Get(this.pos);

            EdModelo.Text = coche.Modelo;
            EdColor.Text = coche.Color;
        }
        // Linea de estado
        StLine.Content = $"Posición: {this.pos + 1} | Coches: {numCoches}";
    }

    private RegistroCoches coches;
    private int pos;
}