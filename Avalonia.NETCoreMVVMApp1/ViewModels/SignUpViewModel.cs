using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using ReactiveUI;

namespace Avalonia.NETCoreMVVMApp1.ViewModels
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private string _name = "";
        private string _password = "";
        private string _email = "";
        private string _passwordAgain = "";

        public string Email
        {
            get => _email;
            set
            {
                if (value != null && value.Contains('@'))
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
                if (value != null /*&& value.Length > 6*/)
                    _password = value;
                else
                    _password = "";
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value != null && value.Split(' ').ToList().Count == 3)
                    _name = value;
                else
                    _name = "";
            }
        }

        public string PasswordAgain
        {
            get => _passwordAgain;
            set
            {
                if (value != null /*&& value.Length > 6*/)
                    _passwordAgain = value;
                else
                    _passwordAgain = "";
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