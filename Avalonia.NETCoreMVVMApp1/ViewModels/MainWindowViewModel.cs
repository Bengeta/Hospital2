using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using JetBrains.Annotations;
using Lab1;
using ReactiveUI;

namespace Avalonia.NETCoreMVVMApp1.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private static MainWindowViewModel instance;
        private UserControl view;
        public User _user;
        private string _greeting;

        public string Greeting
        {
            get
            {
                if (_user != null)
                    return "Hi, " + _user.name;
                return " ";
            }
            set { _greeting = value; }
        }

        public UserControl View
        {
            get => view;
            set { view = value; }
        }

        public static MainWindowViewModel getInstance()
        {
            if (instance == null)
                instance = new MainWindowViewModel();
            return instance;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}