using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GUI;

public partial class AddWindow : Window
{
    public AddWindow()
    {
        InitializeComponent();
    }

    private void TransitionBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        CarouselControl.Next();
    }
}