using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Geometrias;

public abstract class Geometria
{
    public double Base { get; set; }
    public double Altura { get; set; }
    public double Area { get; set; }
    public double AreaForma { get; set; }
    public double AnguloBielaCompressao { get; set; } = 45;

    public Geometria()
    {

    }

    public Geometria(double @base, double altura)
    {
        Base = @base;
        Altura = altura;
        Area = CalcularArea();
    }

    public virtual double CalcularArea()
    {
        return Base * Altura;
    }

}