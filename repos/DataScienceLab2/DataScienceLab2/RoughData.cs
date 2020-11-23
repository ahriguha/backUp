using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace DataScienceLab2
{
    class RoughData
    {
        int date;
        int temperature;
        int windSpeed;
        string windDir;
        double precip;
        public RoughData(int date, int temperature, int windSpeed, string windDir, double precip)
        {
            this.date = date;
            this.temperature = temperature;
            this.windSpeed = windSpeed;
            this.windDir = windDir;
            this.precip = precip;
        }

        public static string[] GetStringData(RoughData r)
        {
            return new string[] { r.date.ToString(), r.temperature.ToString(), r.windSpeed.ToString(), r.windDir, r.precip.ToString()};
        }


        public static ArrayList GetArrayData(RoughData r)
        {
            return new ArrayList() { r.date, r.temperature, r.windSpeed, r.windDir, r.precip};
        }

        public static List<RoughData> GetData()
        {
            return new List<RoughData>() {
            new RoughData(1, 19, 0, "South-East", 0),
            new RoughData(2, 20, 5, "South-East", 0),
            new RoughData(3, 17, 6, "South-East", 0),
            new RoughData(4, 1800, 8, "South-East", 0.4),
            new RoughData(5, 21, 7, "South", 0.7),
            new RoughData(6, 21, 4, "South", 0),
            new RoughData(7, 22, 2, "South", 0),
            new RoughData(8, 21, 2, "South-East", 0),
            new RoughData(9, 20, 3, "South-East", 0),
            new RoughData(10, 21, 5, "East", 0),
            new RoughData(0, 0, 5, "East", 0),
            new RoughData(12, 19, 4, "East", 0.3),
            new RoughData(13, 19, 1, "East", 0.2),
            new RoughData(14, 18, 3, "North-East", 0),
            new RoughData(15, 20, 483, "North-East", 0),
            new RoughData(16, 21, 2, "North-East", 0),
            new RoughData(17, 211, 1, "West", 0.1),
            new RoughData(18, 23, 2, "North", 0),
            new RoughData(0, 25, 209, "East", 0),
            new RoughData(20, 22, 6, "East", 0.1),
            new RoughData(21, 19, 7, "East", 0.2),
            new RoughData(22, 17, 3, "North-East", 0),
            new RoughData(23, 23, 4, "North-East", 0),
            new RoughData(24, 23, 2, "North", 0),
            new RoughData(25, 20, 3, "North-West", 0),
            new RoughData(46, 21, 3, "North-West", 0),
            new RoughData(27, 2502, 4, "North-West", 100.4),
            new RoughData(28, 23, 3, "North-West", 1.5),
            new RoughData(29, 20, 1, "North-West", 0.3),
            new RoughData(30, 19, 3, "North", 0.1),
            new RoughData(31, 18, 2, "South", 0.1),
            new RoughData(1, 19, 0, "South-East", 0),
            new RoughData(2, 20, 5, "South-East", 0),
            new RoughData(3, 17, 60000, "South-East", 0),
            new RoughData(4, 1800, 8, "South-East", 0.4),
            new RoughData(5, 21, 7, "South", 0.7),
            new RoughData(6, 21, 4, "South", -13),
            new RoughData(7, 22, 2, "South", 0),
            new RoughData(8, 21, 2, "South-East", 0),
            new RoughData(9, 20, 3, "South-East", 0),
            new RoughData(10, 21, 5, "East", 0),
            new RoughData(0, 0, 5, "East", 0),
            new RoughData(12, 19, 4, "East", 0.3),
            new RoughData(13, 19, 1, "East", 0.2),
            new RoughData(14, 18, 3, "North-East", 0),
            new RoughData(15, 20, 4, "North-East", 0),
            new RoughData(16, 21, 2, "North-East", 0),
            new RoughData(17, 211, 1, "West", 0.1),
            new RoughData(18, 23, 2, "North", 0),
            new RoughData(0, 25, 7, "East", 0),
            new RoughData(20, 22, 6, "East", 0.1),
            new RoughData(21, 19, 7, "East", 0.2),
            new RoughData(22, 17, 3, "North-East", 0),
            new RoughData(23, 23, 4, "North-East", 0),
            new RoughData(24, 23, 2, "North", 0),
            new RoughData(25, 20, 3, "North-West", 0),
            new RoughData(46, 21, 3, "North-West", 0),
            new RoughData(27, 2502, 4, "North-West", 1.4),
            new RoughData(28, 23, 3, "North-West", 1.5),
            new RoughData(29, 20, 1, "North-West", 0.3),
            new RoughData(30, 19, 3234234, "North", 0.1),
            new RoughData(31, 18, 2, "South", 0.1),
            new RoughData(1, 19, 0, "South-East", 0),
            new RoughData(2, 20, 5, "South-East", 0),
            new RoughData(3, 17, 6, "South-East", 0),
            new RoughData(4, 1800, 8, "South-East", 0.4),
            new RoughData(5, 21, 7, "South", 0.7),
            new RoughData(6, 21, 4, "South", 0),
            new RoughData(7, 22, 2, "South", 0),
            new RoughData(8, 21, 2, "South-East", 0),
            new RoughData(9, 20, 3, "South-East", 150000),
            new RoughData(10, 21, 5, "East", 0),
            new RoughData(0, 0, 5, "East", 0),
            new RoughData(12, 19, 4, "East", 0.3),
            new RoughData(13, 19, 1, "East", 0.2),
            new RoughData(14, 18, 3, "North-East", 0),
            new RoughData(15, 20, 4, "North-East", 0),
            new RoughData(16, 21, 2, "North-East", 0),
            new RoughData(17, 211, 1, "West", 0.1),
            new RoughData(18, 23, 2, "North", 0),
            new RoughData(0, 25, 7, "East", 0),
            new RoughData(20, 22, 6, "East", 0.1),
            new RoughData(21, 19, 7, "East", 0.2),
            new RoughData(22, 17, 3, "North-East", 0),
            new RoughData(23, 23, 4, "North-East", 0),
            new RoughData(24, 23, 2, "North", 0),
            new RoughData(25, 20, 3, "North-West", 0),
            new RoughData(46, 21, 3, "North-West", 0),
            new RoughData(27, 2502, 4, "North-West", 1.4),
            new RoughData(28, 23, 3, "North-West", 1.5),
            new RoughData(29, 20, 1, "North-West", 0.3),
            new RoughData(30, 19, 3, "North", 0.1),
            new RoughData(31, 18, 2, "South", 0.1)
            };
        }

    }
}
