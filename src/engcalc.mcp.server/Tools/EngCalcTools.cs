using engcalc.mcp.server.Clients;
using engcalc.mcp.server.DTOs;
using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace engcalc.mcp.server.Tools;
[McpServerToolType]
public static class EngCalcTools
{

    [McpServerTool, Description("Dimensiona uma viga de concreto de acordo com a norma brasileira NBR-6118")]
    public static async Task<string> DimensionaVigaDeConcreto(

        EngcalcApiClient engcalcClient,

        [Description("Define o esforço solicitante de calculo ao qual a viga está submetida, sendo, " +
        "V(Esforço Cortante em kN), M(Esforço flexor em kN.m), T(Esforço Torsor kn.M)")] Solicitacao solicitacao,

        [Description("Define o aço utilizado na viga, sendo Fyk(Esforço de escoamento do aço em MPa)")] Aco aco,

        [Description("Define o concreto utilizado na viga, sendo Fck(Esforço de compressão do concreto em MPa)")] Concreto concreto,

        [Description("Define a geometria da viga, sendo dLinha(Altura útil da viga em cm), Comprimento(Comprimento da viga em cm)," +
        " Base(Largura da viga em cm), Altura(Altura total da viga em cm)")] GeometriaViga geometriaViga
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
