using engcalc.core.Enums;
using engcalc.core.Interfaces;
using engcalc.core.Models.Dimensionamento;
using engcalc.core.Models.Dimensionamento.Resultados;
using engcalc.core.Models.Dimensionamento.Services;
using engcalc.core.Models.Geometrias;
using engcalc.core.Models.Materiais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.ElementosEstruturais;

public class Viga
{
    public Material Material { get; set; }
    public Aco Aco { get; set; }
    public Solicitacao Solicitacao { get; set; }
    public Geometria Geometria { get; set; }
    public IResultadosDimensionamento? BaseResultadosDimensionamento { get; set; }
    public ResultadosGerais ResultadosGerais { get; set; }

    public Viga(Material material, Aco aco, Solicitacao solicitacao, Geometria geometria)
    {
        Material = material;
        Aco = aco;
        Solicitacao = solicitacao;
        Geometria = geometria;

        Dimensionar();

    }

    public void Dimensionar()
    {
        if (Solicitacao.TipoSolicitacao == eSolicitacao.CORTANTE)
        {
            var cortante = VigaCalculator.DimensionarVigaEsforcoCortante(this);
            BaseResultadosDimensionamento = cortante;
            ResultadosGerais = new ResultadosGerais()
            {
                ResultadosEsforcoCortante = cortante
            };
        }

        if (Solicitacao.TipoSolicitacao == eSolicitacao.TORCAO)
        {
            var torcao = VigaCalculator.DimensionamentoEsforcoTorsor(this);
            BaseResultadosDimensionamento = torcao;
            ResultadosGerais = new ResultadosGerais()
            {
                ResultadosEsforcoTorsor = torcao
            };
        }   

        if (Solicitacao.TipoSolicitacao == eSolicitacao.FLEXAO)
        {
            var flexao = VigaCalculator.DimensionarVigaFlexaoSimples(this);
            BaseResultadosDimensionamento = flexao;
            ResultadosGerais = new ResultadosGerais()
            {
                ResultadosFlexaoSimples = flexao
            };
        }

        if (Solicitacao.TipoSolicitacao == eSolicitacao.FLEXAOCORTANTE)
        {
            var flexao = VigaCalculator.DimensionarVigaFlexaoSimples(this);
            var cortante = VigaCalculator.DimensionarVigaEsforcoCortante(this);
            var combinado = CombinacaoResultados.ResultadoFlexoCortante(cortante, flexao);
            BaseResultadosDimensionamento = combinado;
            ResultadosGerais = new ResultadosGerais()
            {
                ResultadosCombinados = combinado,
                ResultadosFlexaoSimples = flexao,
                ResultadosEsforcoCortante = cortante,
            };
        }

        if (Solicitacao.TipoSolicitacao == eSolicitacao.FLEXOTORCAO)
        {
            var flexao = VigaCalculator.DimensionarVigaFlexaoSimples(this);
            var torcao = VigaCalculator.DimensionamentoEsforcoTorsor(this);

            var combinado = CombinacaoResultados.ResultadoFlexoTorcao(torcao, flexao);
            BaseResultadosDimensionamento = combinado;
            ResultadosGerais = new ResultadosGerais()
            {
                ResultadosCombinados = combinado,
                ResultadosFlexaoSimples = flexao,
                ResultadosEsforcoTorsor = torcao,
            };

        }

        if (Solicitacao.TipoSolicitacao == eSolicitacao.TORCAOCORTANTE)
        {
            var torcao = VigaCalculator.DimensionamentoEsforcoTorsor(this);
            var cortante = VigaCalculator.DimensionarVigaEsforcoCortante(this);

            var combinado = CombinacaoResultados.TorcaoCortante(cortante, torcao);
            BaseResultadosDimensionamento = combinado;
            ResultadosGerais = new ResultadosGerais()
            {
                ResultadosCombinados = combinado,
                ResultadosEsforcoCortante = cortante,
                ResultadosEsforcoTorsor = torcao,
            };
        }

        if (Solicitacao.TipoSolicitacao == eSolicitacao.FLEXOTORCAOeCORTANTE)
        {
            var torcao = VigaCalculator.DimensionamentoEsforcoTorsor(this);
            var cortante = VigaCalculator.DimensionarVigaEsforcoCortante(this);
            var flexao = VigaCalculator.DimensionarVigaFlexaoSimples(this);

            var combinado = CombinacaoResultados.ResultadosFlexoTorcaoCortante(flexao, cortante, torcao);

            BaseResultadosDimensionamento = combinado;
            ResultadosGerais = new ResultadosGerais()
            {
                ResultadosCombinados = combinado,
                ResultadosEsforcoCortante = cortante,
                ResultadosEsforcoTorsor = torcao,
                ResultadosFlexaoSimples = flexao,
            };
        }


    }

}
