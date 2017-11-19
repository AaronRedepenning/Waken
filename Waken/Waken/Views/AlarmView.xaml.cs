using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waken.Models;
using Waken.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waken.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlarmView : ContentPage
	{
		public AlarmView ()
		{
			InitializeComponent ();
		}

        public void OnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void OnSaveClicked(object sender, EventArgs e)
        {
            App.Alarms.Add(BindingContext as Alarm);
            DependencyService.Get<IAlarmSchedulerService>().ScheduleAlarm(BindingContext as Alarm);

            Navigation.PopAsync();
        }
	}
}