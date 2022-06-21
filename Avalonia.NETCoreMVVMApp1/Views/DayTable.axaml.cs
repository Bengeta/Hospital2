using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.NETCoreMVVMApp1.ViewModels;

namespace Avalonia.NETCoreMVVMApp1.Views;

public partial class DayTable : Window
{
    private DayTableViewModel model;
    public static int day;
    public static int id;
    public DayTable()
    {
        model = new DayTableViewModel(id,day,this);
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

    private void Button_GoBack(object? sender, RoutedEventArgs e)
    {
        WeekTable.id = id;
        var w = new WeekTable();
        w.Show();
        Close();
        
    }

    private void Button_AddPatient(object? sender, RoutedEventArgs e)
    {
        EditPation.day = day;
        EditPation.Patient = null;
        EditPation.id = id;
        var w = new EditPation();
        w.Show();
        Close();
    }
}