using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.NETCoreMVVMApp1.ViewModels;
using ReactiveUI;

namespace Avalonia.NETCoreMVVMApp1.Views;

public partial class Registration : Window
{
    private SignUpViewModel model;
    public Registration()
    {
        InitializeComponent();
        model = new SignUpViewModel();
        DataContext = model;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (model.Email != "" && model.Name != "" && model.Password != "" &&
            model.Password == model.PasswordAgain)
        {
            var response = BDRequests.SignUp(model.Email, model.Password,model.Name);
            if (response == 200)
            {
                MainWindowViewModel.getInstance()._user = BDRequests.SignIn(model.Email, model.Password);
                var new_win = new MainWindow();
                new_win.Show();
                Close();
            }
            else
            {
                MessageBus.Current.SendMessage("Email занят");
            }
        }
    }

    private void Button_OnClick_Back(object? sender, RoutedEventArgs e)
    {
        var r = new SignIn();
        r.Show();
        Close();
    }
}