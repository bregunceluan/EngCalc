using engcalc.core.Models.Materiais;

namespace engcalc.core.test;
public class MaterialTest
{
    private Concreto _concretoAte50;
    private Concreto _concretoMaior50;
    private Aco _aco;

    public MaterialTest()
    {
        _concretoAte50 = new Concreto(30);
        _concretoMaior50 = new Concreto(60);
        _aco = new Aco(500);
    }

    [Trait("Concreto", "Calculo da propriedades do Concreto")]
    [Fact(DisplayName = "Concreto até 50Mpa")]
    public void CalculaFctmAte50MPa_ShouldReturnTrue()
    {
        double expectedFctm = 2.896;
        double expectedFckInf = 2.028;
        double expectedFckSup = 3.765;
        double expectedLambda = 0.8;
        double expectedAlphaC = 0.85;
        double expectedEci = 36807.0;
        double expectedEcs = 32206.0;
        double expectedAlphaI = 0.875;
        double expectedFcd = 21.429;
        double expectedFctd = 1.448;
        Assert.Equal(expectedFctm, _concretoAte50.Fctm, 3);
        Assert.Equal(expectedFckInf, _concretoAte50.FctkInf, 3);
        Assert.Equal(expectedFckSup, _concretoAte50.FctkSup, 3);
        Assert.Equal(expectedLambda, _concretoAte50.Lambda, 3);
        Assert.Equal(expectedAlphaC, _concretoAte50.AlphaC, 3);
        Assert.Equal(expectedEci, _concretoAte50.Eci, 0);
        Assert.Equal(expectedEcs, _concretoAte50.Ecs, 0);
        Assert.Equal(expectedAlphaI, _concretoAte50.AlphaI, 3);
        Assert.Equal(expectedFcd, _concretoAte50.Fcd, 3);
        Assert.Equal(expectedFctd, _concretoAte50.Fctd, 3);
    }

    [Trait("Concreto", "Calculo da propriedades do Concreto")]
    [Fact(DisplayName = "Concreto maior 50Mpa")]
    public void CalculaFctmMaior50MPa_ShouldReturnTrue()
    {
        double expectedFctm = 4.300;
        double expectedFckInf = 3.010;
        double expectedFckSup = 5.590;
        double expectedLambda = 0.775;
        double expectedAlphaC = 0.8075;
        double expectedEci = 49934.309;
        double expectedEcs = 47437.593;
        double expectedAlphaI = 0.95;
        double expectedFcd = 42.857;
        double expectedFctd = 2.150;
        Assert.Equal(expectedFctm, _concretoMaior50.Fctm, 3);
        Assert.Equal(expectedFckInf, _concretoMaior50.FctkInf, 3);
        Assert.Equal(expectedFckSup, _concretoMaior50.FctkSup, 3);
        Assert.Equal(expectedLambda, _concretoMaior50.Lambda, 3);
        Assert.Equal(expectedAlphaC, _concretoMaior50.AlphaC, 4);
        Assert.Equal(expectedEci, _concretoMaior50.Eci, 0);
        Assert.Equal(expectedEcs, _concretoMaior50.Ecs, 0);
        Assert.Equal(expectedAlphaI, _concretoMaior50.AlphaI, 3);
        Assert.Equal(expectedFcd, _concretoMaior50.Fcd, 3);
        Assert.Equal(expectedFctd, _concretoMaior50.Fctd, 3);
    }

    [Trait("Aço", "Calculo das propriedades do Aço")]
    [Fact(DisplayName = "Aço de qualquer resistência")]
    public void CalculaResistenciaAco_ShouldReturnTrue()
    {
        double expectedFyk = 500;
        double expectedEyd = 2.07;
        double expectedFyd = 434.78;
        Assert.Equal(expectedFyk, _aco.Fyk, 0);
        Assert.Equal(expectedEyd, _aco.Eyd, 2);
        Assert.Equal(expectedFyd, _aco.Fyd, 2);
    }

}