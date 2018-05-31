using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KirLab3.Service
{
    public interface IModel
    {
        double PositiveEquation(double A, double x);
        double NegativeEquation(double A, double x);
    }
}
