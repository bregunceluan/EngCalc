using engcalc.core.Models.Materiais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Geometrias;

public class GeometriaViga : Geometria
{
    public GeometriaViga(double @base, double altura, double dLinha, double comprimento) : base(@base, altura)
    {
        AlturaUtil = altura - dLinha;
        Comprimento = comprimento;
        Volume = CalculaVolume();
        Wo = ModuloResistenciaSecaoBruta();
        DLinha = dLinha;
    }
    public double Cobrimento { get; set; } = 2.5;
    public double DiametroEst { get; set; } = 2.0;
    public double DiametroAcoLong { get; set; } = 1.0;
    public double DLinha { get; set; }
    public double AlturaUtil { get; set; }
    public double Comprimento { get; set; }
    public double Volume { get; set; }
    public double Wo { get; set; }
    public double Rho { get; set; } = 0.15;

    public GeometriaViga()
    {

    }

    private double CalculaVolume()
    {
        return Base * Altura * Comprimento;
    }
    private double ModuloResistenciaSecaoBruta()
    {
        return Base * Math.Pow(Altura, 2) / 6;
    }

    public double CalculaLinhaNeutraDuctil(Concreto concreto)
    {
        var fck = concreto.Fck;
        if (fck < 55) return 0.45 * AlturaUtil;
        return 0.35 * AlturaUtil;
    }

}
