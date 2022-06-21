using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using ReactiveUI;

namespace Avalonia.NETCoreMVVMApp1.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        private string _email = "";
        private string _password = "";

        public string Email
        {
            get => _email;
            set
            {
                if (Email != null && value.Contains('@'))
                    _email = value;
                else
                    _email = "";

            }
        }
        
        public string Password
        {
            get => _password;
            set
            {
                if (value != null /*&& value.Length>6*/)
                    _password = value;
                else
                    _password = "";

            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}