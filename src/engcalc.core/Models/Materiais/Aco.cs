using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Materiais;

public class Aco : Material
{
    public int NumRamosEstribo { get; set; } = 2;
    public double AnguloEstribo { get; set; } = 90;
    public double Fyk { get; set; }
    public double Es { get; set; } = 210000;
    public double Eyd { get; set; } //por mil
    public double Fyd { get; set; }
    public double GamaS { get; set; } = 1.15;
    public Aco()
    {

    }
    public Aco(double fyk)
    {
        Fyk = fyk;
        Nome = "CA-" + fyk / 10;
        SetProperties();
    }
    protected override void SetProperties()
    {
        Fyd = CalculaFyd();
        Eyd = CalculaEyd();
    }
    public double CalculaFyd()
    {
        double result = Fyk / GamaS;
        return result;
    }
    public double CalculaEyd()
    {
        var result = (Fyd / Es) * 1000;
        return result;
    }
}
