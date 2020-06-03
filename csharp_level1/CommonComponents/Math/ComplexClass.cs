using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public class MyComplex
    {
        private readonly double _im;
        private readonly double _re;

        public MyComplex(double im, double re)
        {
            _im = im;
            _re = re;
        }
        public MyComplex Plus(MyComplex x)
        {
            return new MyComplex(this._im + x._im, this._re + x._re);
        }

        public MyComplex Minus(MyComplex x)
        {
            return new MyComplex(this._im - x._im, this._re - x._re);
        }

        public MyComplex Multi(MyComplex x)
        {
            double im = this._re * x._im + this._im * x._re;
            double re = this._re * x._re - this._im * x._im;
            return new MyComplex(im, re);
        }

        public override string ToString()
        {
            return $"{_re} + {_im}i";
        }
    }
}