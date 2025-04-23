using engcalc.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Dimensionamento.Resultados;

public class Combinados : IResultadosDimensionamento
{
    public Combinados(double @as, double as2, double asw, double asPele, double asMin, double esforcoSolicitante, double esforcoResistente, double sdRd)
    {
        As = @as;
        As2 = as2;
        Asw = asw;
        AsPele = asPele;
        AsMin = asMin;
        EsforcoSolicitante = esforcoSolicitante;
        EsforcoResistente = esforcoResistente;
        SdRd = sdRd;
    }

    public double As { get; set; }
    public double As2 { get; set; }
    public double Asw { get; set; }
    public double AsPele { get; set; }
    public double AsMin { get; set; }
    public double EsforcoSolicitante { get; set; }
    public double EsforcoResistente { get; set; }
    public double SdRd { get; set; }

}