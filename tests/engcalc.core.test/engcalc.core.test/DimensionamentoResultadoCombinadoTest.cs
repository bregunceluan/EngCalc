using engcalc.core.Models.Dimensionamento.Services;
using engcalc.core.Models.Dimensionamento;
using engcalc.core.Models.ElementosEstruturais;
using engcalc.core.Models.Geometrias;
using engcalc.core.Models.Materiais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engcalc.core.Models.Dimensionamento.Resultados;

namespace engcalc.core.test;

public class DimensionamentoResultadoCombinadoTest
{
    [Theory(DisplayName = "FlexoTorcao")]
    [InlineData(30, (2.15 * 1.4), (5.11 * 1.4), 20, 60, 5, 200, 1.80, 3.83, 0.73, 4.20, 2.20)]
    [InlineData(45, (4.10 * 1.4), (6.33 * 1.4), 35, 75, 5, 200, 3.94, 5.18, 1.24, 5.31, 2.66)]
    [InlineData(75, (5.33 * 1.4), (15.66 * 1.4), 35, 80, 5, 200, 4.20, 8.35, 1.53, 6.60, 3.50)]
    public void CalculaFlexoTorcao_ShouldReturnTrue(double fck, double t, double m, double b, double h, double dLin, double comp, double expectedAsMin, double expectedAs1, double expectedAs2, double expectedAsw, double expectedAsPele)
    {
        var viga = new Viga(new Concreto(fck), new Aco(500), new Solicitacao(t: t, m: m), new GeometriaViga(b, h, dLin, comp));


        var resultado = viga.BaseResultadosDimensionamento as Combinados;        
        Assert.NotNull(resultado);

        var as1 = resultado.As;
        var as2 = resultado.As2;
        var asw = resultado.Asw;
        var asmin = resultado.AsMin;
        var asPele = resultado.AsPele;

        Assert.Equal(expectedAs1, as1, 2);
        Assert.Equal(expectedAs2, as2, 2);
        Assert.Equal(expectedAsMin, asmin, 2);
        Assert.Equal(expectedAsw, asw, 2);
        Assert.Equal(expectedAsPele, asPele, 2);
    }

    [Theory(DisplayName = "FlexoTorcaoComCorte")]
    [InlineData(75, (5.33 * 1.4), (15.66 * 1.4), (2.0 * 1.4), 35, 80, 5, 200, 4.20, 8.35, 1.53, 8.84, 3.50)]
    [InlineData(75, (6.20 * 1.4), (25.10 * 1.4), (13.33 * 1.4), 35, 80, 5, 200, 4.20, 12.81, 1.78, 9.75, 4.07)]
    [InlineData(75, (6.20 * 1.4), (25.10 * 1.4), (13.33 * 1.4), 25.2, 75, 5, 200, 2.84, 13.59, 1.60, 9.44, 4.77)]

    public void CalculaFlexoTorcaoComCorte_ShouldReturnTrue(double fck, double t, double m, double v, double b, double h, double dLin, double comp, double expectedAsMin, double expectedAs1, double expectedAs2, double expectedAsw, double expectedAsPele)
    {
        var viga = new Viga(new Concreto(fck), new Aco(500), new Solicitacao(t: t, m: m, v: v), new GeometriaViga(b, h, dLin, comp));
        
        var resultado = viga.BaseResultadosDimensionamento as Combinados;
        Assert.NotNull(resultado);
        
        var as1 = resultado.As;
        var as2 = resultado.As2;
        var asw = resultado.Asw;
        var asmin = resultado.AsMin;
        var asPele = resultado.AsPele;

        Assert.Equal(expectedAs1, as1, 2);
        Assert.Equal(expectedAs2, as2, 2);
        Assert.Equal(expectedAsMin, asmin, 2);
        Assert.Equal(expectedAsw, asw, 2);
        Assert.Equal(expectedAsPele, asPele, 2);
    }

    [Theory(DisplayName = "TorcaoECortante")]
    [InlineData(75, (6.20 * 1.4), (25.10 * 1.4), (13.33 * 1.4), 25.2, 75, 5, 200, 2.84, 4.44, 1.6, 9.44, 4.77)]
    [InlineData(75, (5.44 * 1.4), (25.10 * 1.4), (11.15 * 1.4), 20, 60, 5, 200, 1.80, 3.66, 1.86, 12.5, 5.57)]
    public void CalculaTorcaoComCorte_ShouldReturnTrue(double fck, double t, double m, double v, double b, double h, double dLin, double comp, double expectedAsMin, double expectedAs1, double expectedAs2, double expectedAsw, double expectedAsPele)
    {
        var viga = new Viga(new Concreto(fck), new Aco(500), new Solicitacao(t: t, v: v), new GeometriaViga(b, h, dLin, comp));
        var resultado = viga.BaseResultadosDimensionamento as Combinados;
        Assert.NotNull(resultado);
        var as1 = resultado.As;
        var as2 = resultado.As2;
        var asw = resultado.Asw;
        var asmin = resultado.AsMin;
        var asPele = resultado.AsPele;

        Assert.Equal(expectedAs1, as1, 2);
        Assert.Equal(expectedAs2, as2, 2);
        Assert.Equal(expectedAsMin, asmin, 2);
        Assert.Equal(expectedAsw, asw, 2);
        Assert.Equal(expectedAsPele, asPele, 2);
    }

    [Theory(DisplayName = "FlexaoECortante")]
    [InlineData(35, (6.20 * 1.4), (25.10 * 1.4), (33.15 * 1.4), 20, 50, 5, 200, 1.50, 21.43, 5.60, 10.72, 0)]
    [InlineData(75, (0 * 1.4), (56 * 1.4), (11.15 * 1.4), 20, 60, 5, 200, 1.80, 37.16, 11.14, 1.89, 0)]
    public void CalculaFlexaoComCorte_ShouldReturnTrue(double fck, double t, double m, double v, double b, double h, double dLin, double comp, double expectedAsMin, double expectedAs1, double expectedAs2, double expectedAsw, double expectedAsPele)
    {
        var viga = new Viga(new Concreto(fck), new Aco(500), new Solicitacao(m: m, v: v), new GeometriaViga(b, h, dLin, comp));
        var resultado = viga.BaseResultadosDimensionamento as Combinados;
        Assert.NotNull(resultado);
        var as1 = resultado.As;
        var as2 = resultado.As2;
        var asw = resultado.Asw;
        var asmin = resultado.AsMin;
        var asPele = resultado.AsPele;

        Assert.Equal(expectedAs1, as1, 2);
        Assert.Equal(expectedAs2, as2, 2);
        Assert.Equal(expectedAsMin, asmin, 2);
        Assert.Equal(expectedAsw, asw, 2);
        Assert.Equal(expectedAsPele, asPele, 2);
    }

}