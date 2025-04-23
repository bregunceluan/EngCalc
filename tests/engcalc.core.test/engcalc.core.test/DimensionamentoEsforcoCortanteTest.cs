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

public class DimensionamentoEsforcoCortanteTest
{
    [Theory(DisplayName = "Dimensionamento")]
    [InlineData(30, (35 * 1.4), 20, 60, 5, 200, 2.32 / 2, 9.16, 0.87)]
    [InlineData(25, (25.12 * 1.4), 20, 75, 5, 200, 2.06 / 2, 4.45, 0.58)]
    [InlineData(25, (43.55 * 1.4), 30, 75, 5, 200, 3.08 / 2, 8.18, 0.67)]
    [InlineData(60, (43.55 * 1.4), 30, 75, 5, 200, 5.16 / 2, 6.18, 0.33)]

    public void CalculaEstribo_ShouldReturnTrue(double fck, double solicitacao, double b, double h, double dLin, double comp, double expectedAsMin, double expectedAsw, double expectedSdrd)
    {
        var viga = new Viga(new Concreto(fck), new Aco(500), new Solicitacao(v: solicitacao), new GeometriaViga(b, h, dLin, comp));
        var resultado = viga.BaseResultadosDimensionamento as EsforcoCortante;
        Assert.NotNull(resultado);
        var asw = resultado.Asw;
        var aswMin = resultado.AswMin;
        var sdrd = resultado.SdRd;
        Assert.Equal(expectedAsMin, aswMin, 2);
        Assert.Equal(expectedAsw, asw, 2);
        Assert.Equal(expectedSdrd, sdrd, 2);
    }

}
