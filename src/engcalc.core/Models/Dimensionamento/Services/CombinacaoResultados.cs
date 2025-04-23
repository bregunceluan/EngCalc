using engcalc.core.Models.Dimensionamento.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Dimensionamento.Services;

public static class CombinacaoResultados
{
    public static Combinados ResultadoFlexoTorcao
        (EsforcoTorsor resultadoTorsor, FlexaoSimples resultadosFlexao)
    {
        var asTorsor = resultadoTorsor.As;
        var as2Torsor = resultadoTorsor.As2;
        var asMinTorsor = resultadoTorsor.AsMin;
        var asPeleTorsor = resultadoTorsor.AsPele;
        var aswTorsor = resultadoTorsor.A90;

        var asFlexao = resultadosFlexao.As;
        var as2Flexao = resultadosFlexao.As2;
        var asMinFlexao = resultadosFlexao.AsMin;
        var asPeleFlexao = resultadosFlexao.AsPele;

        var asMinFinal = asMinFlexao > asMinTorsor ? asMinFlexao : asMinTorsor;
        var asPeleFinal = asPeleFlexao > asPeleTorsor ? asPeleFlexao : asPeleTorsor;

        var asFinal = as2Torsor + Math.Max(asFlexao, asMinFlexao);
        var as2Final = as2Torsor + as2Flexao;
        var aswFinal = aswTorsor > resultadoTorsor.AswMin ? aswTorsor : resultadoTorsor.AswMin;

        return new Combinados(asFinal, as2Final, aswFinal, asPeleFinal, asMinFinal, 0, 0, 0);
    }
    public static Combinados ResultadoFlexoCortante
        (EsforcoCortante resultadosCortante, FlexaoSimples resultadosFlexao)
    {
        var asFlexao = resultadosFlexao.As;
        var as2Flexao = resultadosFlexao.As2;
        var asMinFlexao = resultadosFlexao.AsMin;
        var asPeleFlexao = resultadosFlexao.AsPele;

        var aswFinal = Math.Max(resultadosCortante.Asw, resultadosCortante.AswMin);

        return new Combinados(asFlexao, as2Flexao, aswFinal, asPeleFlexao, asMinFlexao, resultadosCortante.EsforcoSolicitante, resultadosCortante.EsforcoResistente, resultadosCortante.SdRd);
    }
    public static Combinados TorcaoCortante
        (EsforcoCortante resultadosCortante, EsforcoTorsor resultadoTorsor)
    {
        var aswCortante = resultadosCortante.Asw;
        var sdRdCortante = resultadosCortante.SdRd;
        var aswMinCortante = resultadosCortante.AswMin;

        var asTorsor = resultadoTorsor.As;
        var as2Torsor = resultadoTorsor.As2;
        var asMinTorsor = resultadoTorsor.AsMin;
        var asPeleTorsor = resultadoTorsor.AsPele;
        var aswTorsor = resultadoTorsor.A90;
        var sdRdTorsor = resultadoTorsor.SdRd;
        var aswMinTorsor = resultadosCortante.AswMin;

        var aswFinal = Math.Max(aswMinCortante, aswCortante) + Math.Max(aswTorsor, aswMinTorsor);
        var sdrdFinal = 0d;
        var sd = 0d;
        var rd = 0d;

        if (sdRdCortante > sdRdTorsor)
        {
            sdrdFinal = sdRdCortante;
            sd = resultadosCortante.EsforcoSolicitante;
            rd = resultadosCortante.EsforcoResistente;
        }
        else
        {
            sdrdFinal = sdRdTorsor;
            sd = resultadoTorsor.EsforcoSolicitante;
            rd = resultadoTorsor.EsforcoResistente;
        }
        return new Combinados(asTorsor, as2Torsor, aswFinal, asPeleTorsor, asMinTorsor, sd, rd, sdrdFinal);
    }
    public static Combinados ResultadosFlexoTorcaoCortante
        (FlexaoSimples resultadosFlexao, EsforcoCortante resultadosCortante, EsforcoTorsor resultadoTorsor)
    {
        var aswCortante = resultadosCortante.Asw;
        var sdRdCortante = resultadosCortante.SdRd;
        var aswMinCortante = resultadosCortante.AswMin;

        var asTorsor = resultadoTorsor.As;
        var as2Torsor = resultadoTorsor.As2;
        var asMinTorsor = resultadoTorsor.AsMin;
        var asPeleTorsor = resultadoTorsor.AsPele;
        var aswTorsor = resultadoTorsor.A90;
        var sdRdTorsor = resultadoTorsor.SdRd;
        var aswMinTorsor = resultadosCortante.AswMin;

        var asMinFlexao = resultadosFlexao.AsMin;
        var asFlexao = resultadosFlexao.As;
        var as2Flexao = resultadosFlexao.As2;
        var asPeleFlexao = resultadosFlexao.AsPele;

        asFlexao = asFlexao > asMinFlexao ? asFlexao : asMinFlexao;

        var asFinal = as2Torsor + Math.Max(asFlexao, asMinFlexao);
        var as2Final = as2Flexao + as2Torsor;
        var asPeleFinal = Math.Max(asPeleFlexao, asPeleTorsor);
        var aswFinal = Math.Max(aswMinCortante, aswCortante) + Math.Max(aswTorsor, aswMinTorsor);
        var asMinFinal = Math.Max(asMinFlexao, asMinTorsor);
        var sdrdFinal = 0d;
        var sd = 0d;
        var rd = 0d;



        if (sdRdCortante > sdRdTorsor)
        {
            sdrdFinal = sdRdCortante;
            sd = resultadosCortante.EsforcoSolicitante;
            rd = resultadosCortante.EsforcoResistente;
        }
        else
        {
            sdrdFinal = sdRdTorsor;
            sd = resultadoTorsor.EsforcoSolicitante;
            rd = resultadoTorsor.EsforcoResistente;
        }
        return new Combinados(asFinal, as2Final, aswFinal, asPeleFinal, asMinFinal, sd, rd, sdrdFinal);
    }
}