using System;

namespace KataPrograms
{
    public class Tortoise
    {
        private const int conversionMinToSec = 60;

        private const int conversionHrToSec = 3600;

        public static int[] Race(int v1, int v2, int g)
        {
            if (v1 >= v2)
            {
                return null;
            }

            int hh = 0, mm = 0, ss = 0;
            double catchup = (g * conversionHrToSec) / (v2 - v1);

            if (catchup > conversionHrToSec)
            {
                hh = (int)Math.Floor(catchup / conversionHrToSec);
            }
            if (catchup > conversionMinToSec)
            {
                mm = (int)Math.Floor(catchup / conversionMinToSec);
                ss = (int)Math.Floor(catchup - (mm * conversionMinToSec));
                mm = mm % conversionMinToSec;
            }
            else
            {
                ss = (int)Math.Floor(catchup);
            }
            return new int[] { hh, mm, ss };
        }
    }
}