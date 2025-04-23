using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Helpers;

public static class Utils
{
    public static (double, double) EquacaoSegundoGrau(double a, double b, double c)
    {
        double delta = b * b - 4 * a * c;

        double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
        double x2 = (-b - Math.Sqrt(delta)) / (2 * a);

        return (x1, x2);
    }
}
