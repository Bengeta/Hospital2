using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.NETCoreMVVMApp1.ViewModels;

namespace Avalonia.NETCoreMVVMApp1.Views;

public partial class WeekTable : Window
{
    private WeekTableViewModel model;
    public static int id;
    public WeekTable()
    {
        model = new WeekTableViewModel(id,this);
        this.DataContext = model;
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Button_OnClick_Back(object? sender, RoutedEventArgs e)
    {
        var w = new MainWindow();
        w.Show();
        Close();
    }
}