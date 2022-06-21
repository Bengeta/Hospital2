using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.NETCoreMVVMApp1.ViewModels;
using Lab1;

namespace Avalonia.NETCoreMVVMApp1.Views;

public partial class EditPation : Window
{
    private EditPationViewModel model;
    public static int day;
    public static int id;
    public static Patient Patient;

    public EditPation()
    {
        model = new EditPationViewModel(Patient, id,day);
        DataContext = model;
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Button_OnClick_Back(object? sender, RoutedEventArgs e)
    {
        /*DayTable.id = this.id;
        DayTable.day = this.Patient.day;*/
        var w = new DayTable();
        w.Show();
        Close();
    }

    private void Button_OnClick_Add(object? sender, RoutedEventArgs e)
    {
        if (model.Day != -1 && model.Name != "" && model.TimeEnd != "" && model.TimeStart != "")
        {
            var newPatient = new Patient();
            newPatient.day = model.Day;
            var patientList = BDRequests.GetDayPatients(newPatient.day, model.id);
            newPatient.name = model.Name;
            newPatient.timeStart = ConverToTimeOnly(model.TimeStart);
            newPatient.timeEnd = ConverToTimeOnly(model.TimeEnd);
            if (EditPation.Patient != null)
                newPatient.id = EditPation.Patient.id;
            foreach (var patient in patientList)
            {
                if (newPatient.id == patient.id)
                    continue;
                if ((newPatient.timeStart.IsBetween(patient.timeStart, patient.timeEnd) ||
                     newPatient.timeEnd.IsBetween(patient.timeStart, patient.timeEnd)) ||
                    (patient.timeStart.IsBetween(newPatient.timeStart, newPatient.timeEnd) ||
                     patient.timeEnd.IsBetween(newPatient.timeStart, newPatient.timeEnd))
                   )
                {
                    return;
                }
            }

            List<PatientEntity> list;
            if (EditPation.Patient != null)
            {
                list = BDRequests.UpdatePatient(newPatient, model.id, model.patient.id);
            }
            else
                list = BDRequests.AddPatient(newPatient, model.id);


            if (list != null)
            {
                var w = new DayTable();
                w.Show();
                Close();
            }
        }
    }

    private TimeOnly ConverToTimeOnly(string time)
    {
        var time_ = time.Split(':');
        return new TimeOnly(int.Parse(time_[0]), int.Parse(time_[1]));
    }

    private void Button_OnClick_Delete(object? sender, RoutedEventArgs e)
    {
        BDRequests.DeletePatient(EditPation.Patient.id);
        var w = new DayTable();
        w.Show();
        Close();
        
    }
}