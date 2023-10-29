namespace GUI;

public partial class AddDatosReparacion : ValidableUserControl
{
    public AddDatosReparacion()
    {
        InitializeComponent();
    }

    public override bool Validated =>
        double.TryParse(HorasTrabajadasTxt.Text, out _) && double.TryParse(CostePiezasTxt.Text, out _);

    public override void HighlightErrors()
    {
    }
}