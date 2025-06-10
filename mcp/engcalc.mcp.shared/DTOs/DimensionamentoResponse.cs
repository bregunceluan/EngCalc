using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace engcalc.mcp.shared.DTOs;

public class DimensionamentoResponse
{
    public ResultadosCombinados? ResultadosCombinados { get; set; }
    public ResultadosEsforcoCortante? ResultadosEsforcoCortante { get; set; }
    public ResultadosEsforcoTorsor? ResultadosEsforcoTorsor { get; set; }
    public ResultadosFlexaoSimples? ResultadosFlexaoSimples { get; set; }
}

public class ResultadosCombinados
{
    [JsonPropertyName("as")]
    public double As { get; set; }

    public double As2 { get; set; }
    public double Asw { get; set; }
    public double AsPele { get; set; }
    public double AsMin { get; set; }
    public double EsforcoSolicitante { get; set; }
    public double EsforcoResistente { get; set; }
    public double SdRd { get; set; }
}

public class ResultadosEsforcoCortante
{
    public double Asw { get; set; }
    public double AswMin { get; set; }
    public double EsforcoSolicitante { get; set; }
    public double EsforcoResistente { get; set; }
    public double SdRd { get; set; }
}

public class ResultadosEsforcoTorsor
{
    [JsonPropertyName("as")]
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
}

public class ResultadosFlexaoSimples
{
    [JsonPropertyName("as")]
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