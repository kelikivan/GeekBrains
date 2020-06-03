using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public struct Complex
    {
        public double Im;
        public double Re;

        public Complex(double _im, double _re)
        {
            Im = _im;
            Re = _re;
        }

        public Complex Plus(Complex x)
        {
            Complex y;
            y.Im = Im + x.Im;
            y.Re = Re + x.Re;
            return y;
        }

        public Complex Minus(Complex x)
        {
            Complex y;
            y.Im = Im - x.Im;
            y.Re = Re - x.Re;
            return y;
        }

        public Complex Multi(Complex x)
        {
            Complex y;
            y.Im = Re * x.Im + Im * x.Re;
            y.Re = Re * x.Re - Im * x.Im;
            return y;
        }

        public override string ToString()
        {
            return $"{Re} + {Im}i";
        }
    }
}