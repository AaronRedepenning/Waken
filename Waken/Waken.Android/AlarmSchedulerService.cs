using Android.App;
using Android.Content;
using Android.Support.V4.Content;
using System;
using System.Diagnostics;
using Waken.Droid;
using Waken.Models;
using Waken.Services;
using Xamarin.Forms;

using Java.Util;

[assembly: Dependency(typeof(IAlarmSchedulerService))]
namespace Waken.Droid
{
    public class AlarmSchedulerService : IAlarmSchedulerService
    {
        public void ScheduleAlarm(Alarm alarm)
        {
            long millis = Android.OS.SystemClock.ElapsedRealtime() + 1000;



            PendingIntent pendingIntent = CreatePendingIntent(Forms.Context, alarm);
            AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);

            if(Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            {
                alarmManager.SetExactAndAllowWhileIdle(AlarmType.ElapsedRealtimeWakeup, millis, pendingIntent);
            }
            else if(Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                alarmManager.SetExact(AlarmType.ElapsedRealtimeWakeup, millis, pendingIntent);
            }
            else
            {
                alarmManager.Set(AlarmType.ElapsedRealtimeWakeup, millis, pendingIntent);
            }
        }

        PendingIntent CreatePendingIntent(Context context, Alarm alarm)
        {
            Intent intent = new Intent(context, typeof(AlarmSchedulerServiceReceiver));
            intent.PutExtra("AlarmId", alarm.Id);

            return PendingIntent.GetBroadcast(context, alarm.Id, intent, PendingIntentFlags.UpdateCurrent);
        }

        long GetAlarmTimeMilliseconds(Alarm alarm)
        {
            Calendar calendar = Calendar.GetInstance(Java.Util.TimeZone.Default);

            Debug.WriteLine($"DateTime.Ticks = {DateTime.Now.Ticks}");
            Debug.WriteLine($"Android = {Android.OS.SystemClock.ElapsedRealtime()}");

            calendar.TimeInMillis = alarm.Time.Ticks;
            calendar.Set(CalendarField.HourOfDay, alarm.Time.Hour);
            calendar.Set(CalendarField.Minute, alarm.Time.Minute);

            return calendar.TimeInMillis;
        }
    }

    public class AlarmSchedulerServiceReceiver : WakefulBroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Debug.WriteLine("AlarmSchedulerServiceReceiver.OnReceive()");
        }
    }
}