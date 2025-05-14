using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace engcalc.mcp.server.DTOs;

public class DimensionamentoRequest
{
    public required Solicitacao Solicitacao { get; set; }
    public required Aco Aco { get; set; }
    public required Concreto Concreto { get; set; }
    public required GeometriaViga GeometriaViga { get; set; }
}

public class Solicitacao
{
    public double V { get; set; }
    public double M { get; set; }
    public double T { get; set; }
}

public class Aco
{
    public double Fyk { get; set; }
}

public class Concreto
{
    public double Fck { get; set; }
}

public class GeometriaViga
{
    [JsonPropertyName("dLinha")]
    public double DLinha { get; set; }
    public double Comprimento { get; set; }
    public double Base { get; set; }
    public double Altura { get; set; }
}
