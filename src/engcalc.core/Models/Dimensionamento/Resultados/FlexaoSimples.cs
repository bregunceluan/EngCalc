using engcalc.core.Interfaces;
using engcalc.core.Models.ElementosEstruturais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Dimensionamento.Resultados;

public class FlexaoSimples : IResultadosDimensionamento
{
    public FlexaoSimples(double @as, double as2, double asMin, 
        double asPele, double mdMinimo, double mdDuctil, double xDuctil, 
        double xCalculado, double esforcoSolicitante, double esforcoResistente, double sdRd)
    {
        EsforcoSolicitante = esforcoSolicitante;
        EsforcoResistente = esforcoResistente;
        As = @as;
        As2 = as2;
        AsPele = asPele;
        MdMinimo = mdMinimo;
        MdDuctil = mdDuctil;
        XDuctil = xDuctil;
        XCalculado = xCalculado;
        AsMin = asMin;
    }

    public double As { get; set; }
    public double As2 { get; set; }
    public double AsMin { get; set; }
    public double AsPele { get; set; }
    public double MdMinimo { get; set; }
    public double MdDuctil { get; set; }
    public double XDuctil { get; set; }
    public double XCalculado { get; set; }
    public double EsforcoSolicitante { get; set; }
    public double EsforcoResistente { get; set; }
    public double SdRd { get; set; }

}
