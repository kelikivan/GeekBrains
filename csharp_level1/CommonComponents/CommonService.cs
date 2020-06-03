using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public static class CommonService
    {
        public static double GetMassIndexWithDataInput(out double m, out double h)
        {
            m = ConsoleView.GetDouble("Введите свой вес (кг): ");
            h = ConsoleView.GetDouble("Введите свой рост (м): ");
            return GetMassIndex(m, h);
        }
        private static double GetMassIndex(double m, double h)
        {
            return m / Math.Pow(h, 2);
        }
        public static double GetNormMass(double massIndex, double h)
        { 
            return massIndex * Math.Pow(h, 2);
        }
    }
}