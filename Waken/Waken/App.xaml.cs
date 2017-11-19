using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Waken.Models;
using Waken.Views;
using Xamarin.Forms;

namespace Waken
{
	public partial class App : Application
	{
        public static List<Alarm> Alarms = new List<Alarm>();

		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new AlarmsView());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
