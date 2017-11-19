using System;
using System.Collections.Generic;
using System.Text;
using Waken.Models;

namespace Waken.Services
{
    interface IAlarmSchedulerService
    {
        void ScheduleAlarm(Alarm alarm);
    }
}
