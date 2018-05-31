using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KirLab3.Service
{
    public class Model:IModel
    {
        public double NegativeEquation(double A, double x)
        {
            return -1 * x *  Math.Sqrt((A + x) / (A - x));
        }

        public double PositiveEquation(double A, double x)
        {
            return x * Math.Sqrt((A + x) / (A - x));
        }
    }
}
