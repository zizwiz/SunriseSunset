Sunrise Sunset
==============

This is a short C# Winform app for calculating sunrise/sunset/twilight times (UTC), for some UK airports.
This is the C# implementation of [Paul Schlyter's sunriset.c](http://stjarnhimlen.se/comp/sunriset.c).

Getting started
---------------

Get sunrise/sunset time and convert it to a string
````c#
double tsunrise, tsunset;
// Parameters : year - month - day - lat - long
Sunriset.SunriseSunset(Year, Month, Day, Decimal_lat, Decimal_long, out tsunrise, out tsunset);
TimeSpan sunriseTime = TimeSpan.FromHours(tsunrise);
string sunriseTimeString = sunriseTime.ToString(@"hh\:mm\:ss");
Console.WriteLine(tsunrise+" "+sunriseTimeString);
```

Get civil/nautical/astronomical twilight times
````c#
double tsunrise, tsunset;
Sunriset.CivilTwilight(Year, Month, Day, Decimal_lat, Decimal_long, out tsunrise, out tsunset);
Sunriset.NauticalTwilight(Year, Month, Day, Decimal_lat, Decimal_long, out tsunrise, out tsunset);
Sunriset.AstronomicalTwilight(Year, Month, Day, Decimal_lat, Decimal_long, out tsunrise, out tsunset);
```
