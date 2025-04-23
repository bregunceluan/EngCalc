using engcalc.api.Dto;
using engcalc.core.Models.Dimensionamento;
using engcalc.core.Models.Dimensionamento.Resultados;
using engcalc.core.Models.ElementosEstruturais;
using engcalc.core.Models.Geometrias;
using engcalc.core.Models.Materiais;
using Microsoft.AspNetCore.Mvc;

namespace engcalc.api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DimensionamentoController : ControllerBase
{
    [HttpPost("viga")]
    public ResultadosGerais DimensionarVigas([FromBody] VigaDto vigaDto)
    {

        vigaDto.Solicitacao.Majorar(1.4);

        var aco = new Aco(vigaDto.Aco.Fyk);
        var concreto = new Concreto(vigaDto.Concreto.Fck);
        var solicitacao = new Solicitacao(vigaDto.Solicitacao.V, vigaDto.Solicitacao.M, vigaDto.Solicitacao.T);
        var geometria = new GeometriaViga(vigaDto.GeometriaViga.Base, vigaDto.GeometriaViga.Altura, vigaDto.GeometriaViga.DLinha, vigaDto.GeometriaViga.Comprimento);

        var viga = new Viga(concreto, aco, solicitacao, geometria);

        return viga.ResultadosGerais;
    }
}
