﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HumidicConsoleAppCopy
{
   public  class Humidity
    {
        public float Level { get; set; }
        public DateTime Date { get; set; }

        public Humidity()
        {

        }
        public Humidity(DateTime date)
        {
            Date = date;
        }

        public Humidity(float level, DateTime date)
        {

            Level = level;
            Date = date;

        }

    }
}
