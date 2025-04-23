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

public class DimensionamentoTorcaoTest
{

    [Theory(DisplayName = "Dimensionamento")]
    [InlineData(30, (3.75 * 1.4), 20, 60, 5, 200, 3.08, 1.28, 3.84)]
    [InlineData(25, (5.12 * 1.4), 20, 75, 5, 200, 3.65, 1.40, 5.27)]
    [InlineData(35, (3.55 * 1.4), 30, 55, 5, 200, 3.69, 1.21, 2.22)]
    [InlineData(35, (3.55 * 1.4), 32, 55, 5, 200, 4.07, 1.43, 2.46)]

    public void CalculaArmaduraDupla_ShouldReturnTrue(double fck, double solicitacao, double b, double h, double dLin, double comp, double expectedAs, double expectedAs2, double expectedAsPele)
    {
        var viga = new Viga(new Concreto(fck), new Aco(500), new Solicitacao(t: solicitacao), new GeometriaViga(b, h, dLin, comp));
        var resultado = viga.BaseResultadosDimensionamento as EsforcoTorsor;
        Assert.NotNull(resultado);
        var asUm = resultado.As;
        var asDois = resultado.As2;
        var asPele = resultado.AsPele;

        Assert.Equal(expectedAs, asUm, 2);
        Assert.Equal(expectedAs2, asDois, 2);
        Assert.Equal(expectedAsPele, asPele, 2);
    }
}
