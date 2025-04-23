using engcalc.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Dimensionamento.Resultados;

public class EsforcoTorsor : IResultadosDimensionamento
{
    public EsforcoTorsor(double @as, double as2, double asw90, double aswMin, double asPele, double aslMin, double asMin, double esforcoSolicitante, double esforcoResistente, double sdRd)
    {
        As = @as;
        As2 = as2;
        A90 = asw90;
        AswMin = aswMin;
        AsPele = asPele;
        AsMin = asMin;
        AslMin = aslMin;
        EsforcoSolicitante = esforcoSolicitante;
        EsforcoResistente = esforcoResistente;
        SdRd = sdRd;
    }
    public EsforcoTorsor()
    {

    }

    public double As { get; set; }
    public double As2 { get; set; }
    public double A90 { get; set; }
    public double AswMin { get; set; }
    public double AsPele { get; set; }
    public double AsMin { get; set; }
    public double AslMin { get; set; }
    public double EsforcoSolicitante { get; set; }
    public double EsforcoResistente { get; set; }
    public double SdRd { get; set; }

    public void AdicionaValoresMinimos()
    {
        As += AsMin;
    }
}