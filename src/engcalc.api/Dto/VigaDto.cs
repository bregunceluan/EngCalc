using engcalc.core.Models.Dimensionamento;
using engcalc.core.Models.ElementosEstruturais;
using engcalc.core.Models.Geometrias;
using engcalc.core.Models.Materiais;
using Newtonsoft.Json;

namespace engcalc.api.Dto;

public class VigaDto
{
    public VigaDto(SolicitacaoDto solicitacao, AcoDto aco, ConcretoDto concreto, GeometriaVigaDto geometriaViga)
    {
        Solicitacao = solicitacao;
        Aco = aco;
        Concreto = concreto;
        GeometriaViga = geometriaViga;
    }

    public SolicitacaoDto Solicitacao { get; set; }

    public AcoDto Aco { get; set; }

    [JsonProperty("Material")]
    public ConcretoDto Concreto { get; set; }


    [JsonProperty("Geometria")]
    public GeometriaVigaDto GeometriaViga { get; set; }
}