using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Avalonia.Interactivity;
using Avalonia.NETCoreMVVMApp1.Views;
using JetBrains.Annotations;
using ReactiveUI;

namespace Avalonia.NETCoreMVVMApp1.ViewModels
{
    public class WeekTableViewModel : INotifyPropertyChanged
    {
        private List<int> weekPat;
        private List<string>dayName;
        public List<string> weekDays;
        private int id;
        private WeekTable _weekTable;

        public WeekTableViewModel(int id, WeekTable _weekTable)
        {
            this.id = id;
            this._weekTable = _weekTable;
            dayName = new List<string>() {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            weekPat = BDRequests.GetWeekPatients(id);
            weekDays = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                weekDays.Add(weekPat[i]+" "+ dayName[i].ToString());
            }
        }

        public string Monday { get => weekDays[0];}
        public string Tuesday { get => weekDays[1];}
        public string Wednesday { get => weekDays[2];}
        public string Thursday { get => weekDays[3];}
        public string Friday { get => weekDays[4];}
        public string Saturday { get => weekDays[5];}
        public string Sunday { get => weekDays[6];}
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Button_OpenDay(int day)
        {
            DayTable.id = id;
            DayTable.day = day;
            var w = new DayTable();
            w.Show();
            _weekTable.Close();
        }
    }
}