using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public readonly struct ComplexReadOnly
    {
        public readonly double im;
        public readonly double re;

        public ComplexReadOnly(double im, double re)
        {
            this.im = im;
            this.re = re;
        }

        public ComplexReadOnly Plus(ComplexReadOnly x)
        {
            return new ComplexReadOnly(im + x.im, re + x.re);
        }

        public ComplexReadOnly Minus(ComplexReadOnly x)
        {
            return new ComplexReadOnly(im - x.im, re - x.re);
        }

        public ComplexReadOnly Multi(ComplexReadOnly x)
        {
            double _im = re * x.im + im * x.re;
            double _re = re * x.re - im * x.im;
            return new ComplexReadOnly(_im, _re);
        }

        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }
}