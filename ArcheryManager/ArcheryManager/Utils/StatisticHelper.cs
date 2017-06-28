using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcheryManager.Utils
{
    public class StatisticHelper
    {
        /// <summary>
        /// SOURCE : https://stackoverflow.com/questions/3141692/standard-deviation-of-generic-list
        /// </summary>
        public static double CalculateStdDev(IEnumerable<double> values) //TO TEST
        {
            double ret = 0;

            if (values?.Count() > 0)
            {
                //Compute the Average
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }
    }
}
