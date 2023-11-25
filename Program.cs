using System;

static class Program {
static readonly int[] DaysPerMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    static void Main(string[] args) {
        int yearin = 0;
        int monthin = 0;
        int dayin = 0;
        int timezonein = 0;
        int hoursin = 0;
        int minutesin = 0;
        int secondsin = 0;
        Console.WriteLine("Year");
        string t = Console.ReadLine();
        if(!Int32.TryParse(t, out yearin)) {
            yearin = DateTime.Now.Year;
        }

        Console.WriteLine("Month");
        t = Console.ReadLine();
        if(!Int32.TryParse(t, out monthin)) {
            monthin = DateTime.Now.Month;
        }

        Console.WriteLine("Day");
        t = Console.ReadLine();
        if(!Int32.TryParse(t, out dayin)) {
            dayin = DateTime.Now.Day;
        }

        Console.WriteLine("Timezone compared to UTC");
        t = Console.ReadLine();
        if(!Int32.TryParse(t, out timezonein)) {
            var k = TimeZoneInfo.Local.BaseUtcOffset;
            timezonein += 3600 * k.Hours;
            timezonein += 60 * k.Minutes;
        }
            
        Console.WriteLine("Hours");
        t = Console.ReadLine();
        if(!Int32.TryParse(t, out hoursin)) {
            hoursin = DateTime.Now.Hour;
        }

        Console.WriteLine("Minutes");
        t = Console.ReadLine();
        if(!Int32.TryParse(t, out minutesin)) {
            minutesin = DateTime.Now.Minute;
        }

        Console.WriteLine("Seconds");
        t = Console.ReadLine();
        if(!Int32.TryParse(t, out secondsin)) {
            secondsin = DateTime.Now.Second;
        }

        try {
            int sum = 0;
            sum += year(yearin, monthin);
            sum += month(monthin);
            sum += day(dayin);
            sum += hour(hoursin, timezonein);
            sum += minute(minutesin);
            sum += secondsin;
            Console.WriteLine("<t:" + sum + ":R>");
        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
        return;
    }


    static int year(int years, int months) {
        int sum = (years - 1970) * 365 * 24 * 3600;
        if(years % 4 == 0 && months < 2) {
            sum += day((years - 1973) / 4);
        } else {
            sum += day((years - 1972) / 4);
        } 
        return sum;
    }

    static int month(int months) {
        int sum = 0;
        for(int i = months-2; i >= 0; i--) {
            sum += day(DaysPerMonth[i]);
        }
        return sum;
    }

    static int day(int days) {
        return (days) * 24 * 3600;
    }

    static int hour(int hours, int timezone) {
        return hours * 3600 - timezone;
    }

    static int minute(int minutes) {
        return (minutes ) * 60;
    }
}

