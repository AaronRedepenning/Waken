using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Waken.Models;
using Waken.Views;
using Xamarin.Forms;

namespace Waken.ViewModels
{
    class AlarmsViewModel
    {
        public ObservableCollection<Alarm> Alarms { get; set; }

        Page page;

        public AlarmsViewModel(Page page)
        {
            this.page = page;
            Alarms = new ObservableCollection<Alarm>();
        }

        Command refreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                return refreshCommand ?? (refreshCommand = new Command(ExecuteRefreshCommand));
            }
        }

        void ExecuteRefreshCommand()
        {
            Alarms.Clear();

            foreach (var alarm in App.Alarms)
            {
                Alarms.Add(alarm);
            }
        }

        Command goToAlarmDetailsCommand;

        public ICommand GoToAlarmDetailsCommand
        {
            get
            {
                return goToAlarmDetailsCommand ?? (goToAlarmDetailsCommand = new Command<Alarm>(ExecuteGoToAlarmDetailsCommand));
            }
        }

        void ExecuteGoToAlarmDetailsCommand(Alarm alarm)
        {
            page.Navigation.PushAsync(new AlarmView
            {
                BindingContext = alarm ?? (alarm = new Alarm())
            });
        }
    }
}
