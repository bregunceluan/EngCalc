using engcalc.core.Models.Dimensionamento;
using engcalc.core.Models.Dimensionamento.Resultados;
using engcalc.core.Models.ElementosEstruturais;
using engcalc.core.Models.Geometrias;
using engcalc.core.Models.Materiais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.test;

public class DimensionamentoFlexaoSimplesTest
{
    [Trait("Dimensionamento", "Calculo Dimensionamento Flexao Simples")]
    [Fact(DisplayName = "Armadura Simples")]
    public void CalculaArmaduraSimples_ShouldReturnTrue()
    {
        var concreto = new Concreto(30);
        var aco = new Aco(500);
        var solicitacao = new Solicitacao(m: 15 * 1.4);
        var geometria = new GeometriaViga(20, 60, 5, 200);

        var viga = new Viga(concreto,aco,solicitacao,geometria);

        var resultado = viga.BaseResultadosDimensionamento as FlexaoSimples;

        Assert.NotNull(resultado);  

        double xCalculado = resultado.XCalculado;

        var asUm = resultado.As;
        var as2 = resultado.As2;

        var expectedasUm = 9.83;
        var xExpected = 14.67;

        Assert.Equal(expectedasUm, asUm, 2);
        Assert.Equal(xExpected, xCalculado, 2);
    }

    [Trait("Dimensionamento", "Calculo Dimensionamento Flexao Simples")]
    [Fact(DisplayName = "Armadura Minima")]
    public void CalculaArmaduraMinima_ShouldReturnTrue()
    {
        var concreto = new Concreto(30);
        var aco = new Aco(500);
        var solicitacao = new Solicitacao(m: 2.1 * 1.4);
        var geometria = new GeometriaViga(20, 60, 5, 200);

        var viga = new Viga(concreto, aco, solicitacao, geometria);

        var resultado = viga.BaseResultadosDimensionamento as FlexaoSimples;

        Assert.NotNull(resultado);

        double xCalculado = resultado.XCalculado;
        var asUm = resultado.As;

        var expectedasUm = 1.25;
        var xExpected = 1.86;

        Assert.Equal(expectedasUm, asUm, 2);
        Assert.Equal(xExpected, xCalculado, 2);
    }

    [Trait("Dimensionamento", "Calculo Dimensionamento Flexao Simples")]
    [Fact(DisplayName = "Armadura Dupla")]
    public void CalculaArmaduraDupla_ShouldReturnTrue()
    {
        var concretoViga = new Concreto(25);
        var acoViga = new Aco(500);
        var solicitacaoViga = new Solicitacao(m: 20 * 1.4);
        var geometriaViga = new GeometriaViga(20, 60, 5, 200);

        var viga = new Viga(concretoViga, acoViga, solicitacaoViga, geometriaViga);

        var resultado = viga.BaseResultadosDimensionamento as FlexaoSimples;

        Assert.NotNull(resultado);

        double xCalculado = resultado.XCalculado;

        var as1 = resultado.As;
        var as2 = resultado.As2;

        var expectedAs1 = 14.23;
        var expectedAs2 = 0.41;
        var xExpected = 24.75;

        Assert.Equal(expected: expectedAs1, actual: as1, 2);
        Assert.Equal(expected: expectedAs2, actual: as2, 2);
        Assert.Equal(expected: xExpected, actual: xCalculado, 2);
    }

    [Trait("Solicitações", "Calculo Momento Ductil")]
    [Fact(DisplayName = "Momento Ductil")]
    public void CalculaMomentoDuctil_ShouldReturnTrue()
    {
        var concretoViga = new Concreto(25);
        var acoViga = new Aco(500);
        var solicitacaoViga = new Solicitacao(m: 15 * 1.4);
        var geometriaViga = new GeometriaViga(20, 60, 5, 200);

        var viga = new Viga(concretoViga, acoViga, solicitacaoViga, geometriaViga);

        var resultado = viga.BaseResultadosDimensionamento as FlexaoSimples;

        Assert.NotNull(resultado);

        var mdDucCalculado = resultado.MdDuctil;
        var mdDucexpected = 27.11;

        Assert.Equal(mdDucexpected, mdDucCalculado, 2);
    }

    [Trait("Solicitações", "Calculo Momento Mínimo")]
    [Fact(DisplayName = "Momento Mínimo")]
    public void CalculaMomentoMinimo_ShouldReturnTrue()
    {
        var concretoViga = new Concreto(25);
        var acoViga = new Aco(500);
        var solicitacaoViga = new Solicitacao(m: 15 * 1.4);
        var geometriaViga = new GeometriaViga(20, 60, 5, 200);

        var viga = new Viga(concretoViga, acoViga, solicitacaoViga, geometriaViga);

        var resultado = viga.BaseResultadosDimensionamento as FlexaoSimples;

        Assert.NotNull(resultado);

        var mdMinCalculado = resultado.MdMinimo;
        var mdMinexpected = 3.20;

        Assert.Equal(mdMinexpected, mdMinCalculado, 2);
    }

}
