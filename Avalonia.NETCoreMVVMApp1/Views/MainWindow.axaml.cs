using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.NETCoreMVVMApp1.ViewModels;
using ReactiveUI;

namespace Avalonia.NETCoreMVVMApp1.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel _model;
    public MainWindow()
    {
        
      
            _model= MainWindowViewModel.getInstance();
            this.DataContext = _model;
            InitializeComponent();
          //  StartFix();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        //StartFix();
    }

    private void StartFix()
    {
        if (_model._user == null)
        {
            var w = new SignIn();
            w.Show();
            Close();
        }
    }
    private void Button_OnClick_Go_Back(object? sender, RoutedEventArgs e)
    {
        var r = new SignIn();
        r.Show();
        Close();
    }

    private void Button_OnClick_Open_Table(object? sender, RoutedEventArgs e)
    {
        WeekTable.id = MainWindowViewModel.getInstance()._user.id;
        var w = new WeekTable();
        w.Show();
        Close();
    }
}