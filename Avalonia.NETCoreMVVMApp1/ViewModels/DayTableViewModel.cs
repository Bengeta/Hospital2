using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Avalonia.NETCoreMVVMApp1.Views;
using JetBrains.Annotations;
using Lab1;
using ReactiveUI;

namespace Avalonia.NETCoreMVVMApp1.ViewModels
{
    public class DayTableViewModel : INotifyPropertyChanged, IReactiveObject
    {
        private List<string> pations;
        private List<Patient> _pations;
        private int id;
        private DayTable _dayTable;

        public DayTableViewModel(int id,int day,DayTable _dayTable)
        {
            this.id = id;
            this._dayTable = _dayTable;

             _pations = BDRequests.GetDayPatients(day+1,id);
            pations = getList(_pations);
        }
        public List<string> Patients
        {
            get => pations;
        }
        int selectedIndex=-1;

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                var t = this.RaiseAndSetIfChanged(ref selectedIndex, value);
                EditPation.day = _pations[t].day;
                EditPation.Patient = _pations[t];
                EditPation.id = id;
                var w = new EditPation();
                w.Show();
                _dayTable.Close();
            }
        }

        private List<string> getList(List<Patient> _patients)
        {
            var ans = new List<string>();
            foreach (var patient in _patients)
            {
                ans.Add(patient.name.Split(' ')[0]+" "+patient.timeStart.ToString()+" "+patient.timeEnd.ToString());
            }

            return ans;
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