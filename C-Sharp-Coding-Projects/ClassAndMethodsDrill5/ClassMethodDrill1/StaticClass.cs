using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMethodDrill1
{
    public static class StaticClass
    {
        public static void Over9000(double x, out double y, out double z)
        {
            if (x < 9001)
            {
                y = 9001 - x;
                z = x / 1000;
            }
            else
            {
                Console.WriteLine("Nappa:  Vegeta, what does the scouter say about his power level?\nVegeta: It's over nine thouSAAAAAAAND! \nYou manage to defeat the Saiayans and save the Earth!");
                y = -1;
                z = 0;
            }
        }

        public static void Over9000(int x, out double y, out double z)
        {
            if (x < 9001)
            {
                y = 9001 - (double)x;
                z = (double)x / 1000;
            }
            else
            {
                Console.WriteLine("Nappa:  Vegeta, what does the scouter say about his power level?\nVegeta: It's over nine thouSAAAAAAAND! \nYou manage to defeat the Saiayans and save the Earth!");
                y = -1;
                z = 0;
            }
        }

        public static void Over9000(string x, out double y, out double z)
        {
            while (!Double.TryParse(x, out double w))
            {
                Console.Write("Vegeta: The scouter can't even detect a power level on this weakling!  HAHAHAHA.\nTry entering a number: ");
                x = Console.ReadLine();

            }
            if (Convert.ToDouble(x) < 9001)
            {
                y = 9001 - Convert.ToDouble(x);
                z = Convert.ToDouble(x) / 1000;
            }
            else
            {
                Console.WriteLine("Nappa:  Vegeta, what does the scouter say about his power level?\nVegeta: It's over nine thouSAAAAAAAND! \nYou manage to defeat the Saiayans and save the Earth!");
                y = -1;
                z = 0;
            }
        }
    }
}
