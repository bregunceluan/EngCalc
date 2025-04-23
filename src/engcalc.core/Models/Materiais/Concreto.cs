using engcalc.core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Materiais;

public class Concreto : Material
{
    /// <summary>
    /// Valor em Mpa
    /// </summary>
    public double Fck { get; set; }

    /// <summary>
    /// Valor em Mpa
    /// </summary>
    public double Fctm { get; set; }
    public double FctkInf { get; set; }
    public double FctkSup { get; set; }
    public double Lambda { get; set; }
    public double AlphaC { get; set; }
    public double Eci { get; set; }
    public double Ecs { get; set; }
    public double Fcd { get; set; }
    public double Fctd { get; set; }
    public double GamaC { get; set; } = 1.4;
    public eAgregado Agregado { get; set; } = eAgregado.BASALTO;
    public double AlphaE { get; set; } //Coeficiente do agregado do concreto
    public double AlphaI { get; set; }

    public double Ecu = (3.5 / 1000);

    public Concreto()
    {

    }
    public Concreto(double fck)
    {
        Nome = $"{fck} MPa";
        Fck = fck;
        SetProperties();
    }
    protected override void SetProperties()
    {
        Fctm = CalculaFctm();
        FctkInf = CalculaFctkInf();
        FctkSup = CalculaFctkSup();
        Lambda = CalculaLambda();
        AlphaC = CalculaAlphaC();
        AlphaE = CalculaAlphaE();
        Eci = CalculaEci();
        AlphaI = CalculaAlphaI();
        Ecs = CalculaEcs();
        Fcd = CalculaFcd();
        Fctd = CalculaFctd();
    }
    public double CalculaFctm()
    {
        if (Fck <= 50)
        {
            var result = 0.3 * Math.Pow(Fck, (2.0 / 3.0));
            return result;
        }
        else
        {
            var result = 2.12 * Math.Log(1 + 0.11 * Fck);
            return result;
        }
    }
    private double CalculaFctkInf()
    {
        var result = Fctm * 0.7;
        return result;
    }
    private double CalculaFctkSup()
    {
        var result = Fctm * 1.3;
        return result;
    }
    private double CalculaFcd()
    {
        double result = Fck / GamaC;
        return result;
    }
    public double CalculaAlphaC()
    {
        if (Fck <= 50)
        {
            return 0.85;
        }
        else
        {
            double result = 0.85 * (1 - (Fck - 50) / 200);
            return result;
        }
    }
    public double CalculaLambda()
    {
        if (Fck <= 50)
        {
            return 0.8;
        }
        else
        {
            double result = 0.8 - (Fck - 50) / 400;
            return result;
        }
    }

    public double CalculaAlphaE() => Agregado switch
    {
        eAgregado.BASALTO or eAgregado.DIABASIO => 1.2,
        eAgregado.GRANITO or eAgregado.GNAISSE => 1.0,
        eAgregado.CALCARIO or eAgregado.ARENITO => 0.9,
        _ => 1.2
    };

    private double CalculaEci()
    {
        if (Fck <= 50)
        {
            double result = AlphaE * 5600 * Math.Sqrt(Fck);
            return result;
        }
        else
        {
            double result = AlphaE * 21500 * Math.Pow((Fck / 10.0) + 1.25, 1.0 / 3.0);
            return result;
        }
    }
    public double CalculaAlphaI()
    {
        double result = 0.8 + 0.2 * (Fck / 80);
        if (result > 1.0) return 1.0;
        return result;
    }
    private double CalculaEcs()
    {
        double result = AlphaI * Eci;
        return result;
    }
    private double CalculaFctd()
    {
        return FctkInf / GamaC;
    }


}