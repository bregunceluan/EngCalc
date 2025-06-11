using engcalc.mcp.shared.Clients;
using engcalc.mcp.shared.DTOs;
using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace engcalc.mcp.shared.Tools;
[McpServerToolType]
public static class EngCalcTools
{

    [McpServerTool, Description("Dimensiona uma viga de concreto de acordo com a norma brasileira NBR-6118. Obtendo assim aço necessário" +
        "para que o elemento estrutural esteja seguros e dentro dos limites estabelecidos.")]
    public static async Task<string> DimensionaVigaDeConcreto(

        EngcalcApiClient engcalcClient,

        [Description("Define o esforço solicitante de calculo ao qual a viga está submetida, sendo: " +
        "Vk(Esforço Cortante característico em kN), Mk(Esforço flexor característico em kN.m), Tk(Esforço Torsor característico em kn.M)")] Solicitacao solicitacao,

        [Description("Define o aço utilizado na viga, sendo Fyk(Resistência característica do aço em MPa)")] Aco aco,

        [Description("Define o concreto utilizado na viga, sendo Fck(Resistência característica do concreto em MPa)")] Concreto concreto,

        [Description("Define a geometria da viga, sendo dLinha (Também chamado d', mede distância da fibra mais " +
        "extrema do concreto até o centro de gravidade das barras de compressão. Muita vezes o valor é 5cm.)."+
        " Comprimento(Comprimento da viga em cm), Base(Largura da viga em cm), Altura(Altura total da viga em cm)." + 
        " Apesar de não ser um valor de entrada na API, a altura útil da viga (chamado de d) é calculada como h - d'linha.")] GeometriaViga geometriaViga
        )
    {

        try
        {
            var request = new DimensionamentoRequest
            {
                Solicitacao = solicitacao,
                Aco = aco,
                Concreto = concreto,
                GeometriaViga = geometriaViga
            };

            var response = await engcalcClient.GetDimensionamentoAsync(request);

            var content = JsonSerializer.Serialize(response);

            return content;
        }
        catch (Exception)
        {
            return "Erro ao processar a solicitação.";
        }

    }

}
