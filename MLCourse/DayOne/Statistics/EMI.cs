using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{
   public  class EMI
    {
        public static double Get_emi(double principal, double rate, int number_of_year)
        {
            double percent_rate = rate / (12 * 100);
            return principal / ((1 - Math.Pow(1 + percent_rate, -number_of_year * 12)) / percent_rate);
        }
    }
}
