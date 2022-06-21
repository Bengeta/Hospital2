using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.NETCoreMVVMApp1.ViewModels;

namespace Avalonia.NETCoreMVVMApp1.Views;

public partial class SignIn : Window
{
    private SignInViewModel model;
    public SignIn()
    {
        InitializeComponent();
        model = new SignInViewModel();
        this.DataContext = model;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var r = new Registration();
        r.Show();
        Close();
    }

    private void Button_SignIn(object? sender, RoutedEventArgs e)
    {
        if (model.Email != null && model.Password != null)
        {
            var user = BDRequests.SignIn(model.Email, model.Password);
            if (user != null)
            {
                MainWindowViewModel.getInstance()._user = user;
                var w = new MainWindow();
                w.Show();
                Close();
            }
            else
            {
                
            }
        }
    }
}