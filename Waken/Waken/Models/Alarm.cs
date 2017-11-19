using System;
using System.Collections.Generic;
using System.Text;

namespace Waken.Models
{
    public class Alarm
    {
        public static int nextId = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public bool IsEnabled { get; set; }

        public Alarm()
        {
            Id = nextId++;
            Name = "New Alarm";
            Time = DateTime.Now;
            IsEnabled = true;
        }
    }
}
