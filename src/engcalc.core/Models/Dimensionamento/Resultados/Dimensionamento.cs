using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace engcalc.core.Models.Dimensionamento.Resultados;

public class Dimensionamento
{
    [JsonPropertyName("resultadosCombinados")]
    public Combinados ResultadosCombinados { get; set; }

    [JsonPropertyName("resultadosEsforcoCortante")]
    public EsforcoCortante ResultadosEsforcoCortante { get; set; }

    [JsonPropertyName("resultadosEsforcoTorsor")]
    public EsforcoTorsor ResultadosEsforcoTorsor { get; set; }

    [JsonPropertyName("resultadosFlexaoSimples")]
    public FlexaoSimples ResultadosFlexaoSimples { get; set; }

    public Dimensionamento(Combinados resultadosCombinados, EsforcoCortante resultadosEsforcoCortante, EsforcoTorsor resultadosEsforcoTorsor, FlexaoSimples resultadosFlexaoSimples)
    {
        ResultadosCombinados = resultadosCombinados;
        ResultadosEsforcoCortante = resultadosEsforcoCortante;
        ResultadosEsforcoTorsor = resultadosEsforcoTorsor;
        ResultadosFlexaoSimples = resultadosFlexaoSimples;
    }

}