using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waken.Models;
using Waken.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waken.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlarmsView : ContentPage
	{
        AlarmsViewModel alarmsViewModel;

		public AlarmsView ()
		{
			InitializeComponent ();

            BindingContext = alarmsViewModel = new AlarmsViewModel(this);

            AlarmsList.ItemSelected += (sender, e) =>
            {
                var selected = AlarmsList.SelectedItem as Alarm;

                if (null == selected)
                {
                    return;
                }

                alarmsViewModel.GoToAlarmDetailsCommand.Execute(selected);
                AlarmsList.SelectedItem = null;
            };
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            alarmsViewModel.RefreshCommand.Execute(null);
        }
    }
}