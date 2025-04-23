using engcalc.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Dimensionamento.Resultados;

public class EsforcoCortante : IResultadosDimensionamento
{
    public EsforcoCortante(double asw, double aswmin, double esforcoSolicitante, double esforcoResistente, double sdRd)
    {
        Asw = asw;
        AswMin = aswmin;
        EsforcoResistente = esforcoResistente;
        EsforcoSolicitante = esforcoSolicitante;
        SdRd = sdRd;
    }

    public double Asw { get; set; }
    public double AswMin { get; set; }
    public double EsforcoSolicitante { get; set; }
    public double EsforcoResistente { get; set; }
    public double SdRd { get; set; }

}