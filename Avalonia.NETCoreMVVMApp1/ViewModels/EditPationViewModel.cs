using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Lab1;
using ReactiveUI;

namespace Avalonia.NETCoreMVVMApp1.ViewModels
{
    public class EditPationViewModel : INotifyPropertyChanged, IReactiveObject
    {
        public Patient patient;
        private string _name = "";
        private string _timeStart = "";
        private string _timeEnd = "";
        private int _day ;
        private string _addButton;
        public int id;

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
        public string AddButton
        {
            get => _addButton;
            set
            {
                _addButton = value;
            }
        }

        public string TimeStart
        {
            get => _timeStart;
            set
            {
                if (value != null && value.Contains(':'))
                {
                    var in_ = value.Split(':');
                    int a;
                    if (in_.Length == 2 && int.TryParse(in_[0], out a) && int.TryParse(in_[1], out a))
                    {
                        var i1 = int.Parse(in_[0]);
                        var i2 = int.Parse(in_[1]);
                        if (i1 >= 8 && i1 <= 17 && i2 >= 0 && i2 <= 60)
                        {
                            _timeStart = value;
                        }
                    }
                }
            }
        }

        public string TimeEnd
        {
            get => _timeEnd;
            set
            {
                if (value != null && value.Contains(':'))
                {
                    var in_ = value.Split(':');
                    int a;
                    if (in_.Length == 2 && int.TryParse(in_[0], out a) && int.TryParse(in_[1], out a))
                    {
                        var i1 = int.Parse(in_[0]);
                        var i2 = int.Parse(in_[1]);
                        if (i1 >= 8 && i1 <= 17 && i2 >= 0 && i2 <= 60)
                        {
                            _timeEnd = value;
                        }
                    }
                }
            }
        }

        public int Day
        {
            get => _day;
            set
            {
                int a;
                if (value != null)
                {
                    var t = value;
                    if (t < 8 && t > 0)
                    {
                        _day = value;
                    }
                }
            }
        }


        public EditPationViewModel(Patient patient,int id,int day)
        {
            this.id = id;
            this.Day = day;
            this.patient = patient;
            if (patient!=null)
            {
                Name = patient.name;
                TimeEnd = patient.timeEnd.ToString();
                TimeStart = patient.timeStart.ToString();
                Day = patient.day;
                AddButton = "Edit";

            }
            else
            {
                AddButton = "Add";
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangingEventHandler? PropertyChanging;

        public void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            throw new System.NotImplementedException();
        }
    }
}