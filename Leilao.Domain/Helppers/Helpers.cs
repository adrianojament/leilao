using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.Domain.Helppers
{
    public class Helpers
    {
        public static DateTime GetDateTimeBrasilian()
        {
            DateTime timeUtc = DateTime.UtcNow;            
            var brasilian = TimeZoneInfo.FindSystemTimeZoneById("Brazil/East");
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, brasilian);
        }
    }
}
