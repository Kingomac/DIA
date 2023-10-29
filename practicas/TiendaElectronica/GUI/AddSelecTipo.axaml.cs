using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Avalonia.Controls;
using TiendaElectronica.Core.Aparatos;

namespace GUI;

public partial class AddSelecTipo : UserControl
{
    private readonly ImmutableDictionary<string, Type> tipos = new Dictionary<string, Type>
    {
        { "Adaptador TDT", typeof(AdaptadorTDT) },
        { "Radio", typeof(Radio) },
        { "Reproductor DVD", typeof(ReproductorDVD) },
        { "Televisor", typeof(Televisor) }
    }.ToImmutableDictionary();

    public AddSelecTipo()
    {
        InitializeComponent();
        AparatoTipoSelect.ItemsSource = tipos.Keys;
    }
}