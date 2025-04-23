using engcalc.core.Helpers;
using engcalc.core.Models.Dimensionamento.Resultados;
using engcalc.core.Models.ElementosEstruturais;
using engcalc.core.Models.Geometrias;
using engcalc.core.Models.Materiais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Dimensionamento.Services
{
    public static class VigaCalculator
    {
        public static EsforcoTorsor DimensionamentoEsforcoTorsor(Viga viga)
        {
            var material = viga.Material as Concreto ?? throw new Exception("Material não é concreto.");
            var geometria = viga.Geometria as GeometriaViga ?? throw new Exception("Elemento não é viga.");
            var solicitacao = viga.Solicitacao;
            var aco = viga.Aco;

            var tsd = solicitacao.T * 1000;
            var asMin = (geometria.Rho / 100) * geometria.Area;

            var cUm = geometria.Cobrimento + geometria.DiametroEst + (geometria.DiametroAcoLong / 2);
            var perimetro = 2 * geometria.Base + 2 * geometria.Altura;
            var torcaoAu = geometria.Area / perimetro;
            var anguloDiagonalComp = geometria.AnguloBielaCompressao;
            var alphaV2 = 1 - (material.Fck / 250);

            var fcd = material.Fcd;
            var fywd = aco.Fyd / 10; //resultado kn/cm²

            double Ae = 0;
            double Ue = 0;
            double he = 0;

            if (torcaoAu < 2 * cUm)
            {
                he = Math.Min(torcaoAu, (geometria.Base - (2 * cUm)));
            }
            else
            {
                he = torcaoAu;
            }
            if (he < 2 * cUm)
            {
                Ae = (geometria.Base - cUm) * (geometria.Altura - cUm);
                Ue = 2 * (geometria.Base + geometria.Altura - (2 * cUm));
            }
            else
            {
                Ae = (geometria.Base - he) * (geometria.Altura - he);
                Ue = 2 * (geometria.Base + geometria.Altura - (2 * he));
            }
            var bielaRadi = (anguloDiagonalComp * Math.PI / 180);
            var trd2 = 0.5 * alphaV2 * (fcd * 100) * (Ae / 10000) * (he / 100) * (Math.Sin(2 * bielaRadi));
            var Asl = (tsd * Ue) / (2 * fywd * Ae * Math.Tan(bielaRadi));
            var A90S = (tsd / (2 * fywd * Ae * (1 / (Math.Tan(bielaRadi))))) * 100; //*100 para converter cm²/cm em cm²/m
            var aslMin = (0.2 * material.Fctm * he * Ue) / aco.Fyk;
            var aswMin = ((0.2 * material.Fctm * geometria.Base) / (aco.Fyk)) * 100;
            var aslFinalAs2 = Asl * (geometria.Base / (2 * (geometria.Base + geometria.Altura)));
            var aslFinalAs1 = asMin + aslFinalAs2;
            var asPeleFinal = Asl * (geometria.Altura / (2 * (geometria.Base + geometria.Altura)));
            return new EsforcoTorsor(aslFinalAs1, aslFinalAs2, A90S, aswMin, asPeleFinal, aslMin, asMin, tsd / 1000, trd2, tsd / 1000 / trd2);
        }
        public static FlexaoSimples DimensionarVigaFlexaoSimples(Viga viga)
        {
            var material = viga.Material as Concreto ?? throw new Exception("Material não é concreto.");
            var geometria = viga.Geometria as GeometriaViga ?? throw new Exception("Elemento não é viga.");

            var mdDuctil = CalculaMomentoDuctilVigaConcreto(viga);
            var mdMinimo = CalculaMomentoMinimoVigaConcreto(viga);
            var md = viga.Solicitacao.M;
            var xCalculado = double.NaN;
            var asMin = viga.Geometria.Area * geometria.Rho / 100;
            var asPele = viga.Geometria.Altura > 60 ? viga.Geometria.Base * viga.Geometria.Altura * (0.1 / 100) : 0;

            if (md > mdDuctil)
            {
                //Armadura Dupla
                (double, double) resposta = CalculoArmaduraDuplaVigaConcreto(viga, ref xCalculado);
                var result = new FlexaoSimples(resposta.Item1, resposta.Item2, asMin, asPele, mdMinimo, mdDuctil, 0, xCalculado, md, md, 1);
                return result;

            }
            if (md > mdMinimo)
            {
                //Armadura Simples
                var asCalculado = CalculoArmaduraSimplesVigaConcreto(viga, ref xCalculado);
                var result = new FlexaoSimples(asCalculado, 0, asMin, asPele, mdMinimo, mdDuctil, 0, xCalculado, md, md, 1);
                return result;
            }
            if (mdMinimo > md)
            {
                //Armadura Minima
                var asCalculado = CalculoArmaduraSimplesVigaConcreto(viga, ref xCalculado);
                var result = new FlexaoSimples(asCalculado, 0, asMin, asPele, mdMinimo, mdDuctil, 0, xCalculado, md, md, 1);
                return result;
            }
            throw new Exception("Falha para calcular flexão simples");

        }
        public static EsforcoCortante DimensionarVigaEsforcoCortante(Viga viga)
        {

            var material = viga.Material as Concreto ?? throw new Exception("Material não é concreto.");
            var geometria = viga.Geometria as GeometriaViga ?? throw new Exception("Elemento não é viga.");

            var solicitacao = viga.Solicitacao;
            double anguloEstribo = viga.Aco.AnguloEstribo;
            double anguloBiela = viga.Geometria.AnguloBielaCompressao;
            double grausEstribos = (anguloEstribo * Math.PI) / 180;
            int numEstribos = viga.Aco.NumRamosEstribo;
            double fctd = material.Fctd;
            double fctm = material.Fctm;
            var vco = 0.6 * (fctd * 100) * (viga.Geometria.Base / 100) * (geometria.AlturaUtil / 100);
            var alphaV2 = 1 - (material.Fck / 250);
            var fywd = viga.Aco.Fyd;

            var vrd2 = 0.27 * alphaV2 * (material.Fcd * 100) * (geometria.Base / 100) * (geometria.AlturaUtil / 100);
            var aswS = ((solicitacao.V - vco) / (0.9 * geometria.AlturaUtil * fywd)) * 10000;
            var aswMin = (0.2 * ((fctm * 0.1) / (500 * 0.1)) * geometria.Base) * 100;
            var vswMin = (((aswMin * (0.9 * (geometria.AlturaUtil / 100) * (fywd * 100)))) / 10000);
            var vrd3Min = vco - vswMin;
            var sdRd = solicitacao.V / vrd2;
            var asw = aswS / numEstribos;

            var result = new EsforcoCortante(asw, aswMin / numEstribos, solicitacao.V, solicitacao.V, sdRd);
            return result;
        }

        #region Calculo de Momentos
        private static double CalculaMomentoDuctilVigaConcreto(Viga viga)
        {
            var concreto = viga.Material as Concreto ?? throw new Exception("Material não é concreto.");
            var geometria = viga.Geometria as GeometriaViga ?? throw new Exception("Elemento não é viga.");

            double xDuctil;
            if (concreto.Fck <= 50) xDuctil = 0.45 * geometria.AlturaUtil;
            else xDuctil = 0.35 * geometria.AlturaUtil;
            var mdDuctil = concreto.AlphaC * concreto.Fcd * geometria.Base * concreto.Lambda * xDuctil * (geometria.AlturaUtil - concreto.Lambda * xDuctil / 2) / 10000;
            return mdDuctil;
        }
        private static double CalculaMomentoMinimoVigaConcreto(Viga viga)
        {
            var concreto = viga.Material as Concreto ?? throw new Exception("Material não é concreto.");
            var geometria = viga.Geometria as GeometriaViga ?? throw new Exception("Elemento não é viga.");

            var moduloResistenciaSecaoTransversal = geometria.Wo;
            var mdMinimo = 0.8 * moduloResistenciaSecaoTransversal * concreto.FctkSup / 10000;
            return mdMinimo;
        }
        #endregion

        #region Armaduras
        private static double CalculoArmaduraSimplesVigaConcreto(Viga viga, ref double xCalculado)
        {
            var concreto = viga.Material as Concreto ?? throw new Exception("Material não é concreto.");
            var geometria = viga.Geometria as GeometriaViga ?? throw new Exception("Elemento não é viga.");
            var aco = viga.Aco;


            var ax2 = -(concreto.AlphaC * concreto.Fcd * geometria.Base * Math.Pow(concreto.Lambda, 2)) / 2;
            var bx = concreto.AlphaC * concreto.Fcd * geometria.Base * concreto.Lambda * geometria.AlturaUtil / 100;
            var c = -viga.Solicitacao.M;

            var (x1, x2) = Utils.EquacaoSegundoGrau(ax2, bx, c);

            xCalculado = Math.Min(x1, x2) > 0 ? Math.Min(x1, x2) * 100 : Math.Max(x1, x2) * 100;

            var asUm = (concreto.AlphaC * concreto.Fcd * geometria.Base * concreto.Lambda * xCalculado) / aco.Fyd;

            return asUm;
        }
        private static (double, double) CalculoArmaduraDuplaVigaConcreto(Viga viga, ref double xCalculado)
        {
            var concreto = viga.Material as Concreto ?? throw new Exception("Material não é concreto.");
            var geometria = viga.Geometria as GeometriaViga ?? throw new Exception("Elemento não é viga.");

            var aco = viga.Aco;
            var xDuc = geometria.CalculaLinhaNeutraDuctil(concreto);

            xCalculado = xDuc;

            var md = viga.Solicitacao.M;
            var mdDuctil = CalculaMomentoDuctilVigaConcreto(viga);

            var deformacaoArmDupl = (concreto.Ecu) * ((xDuc - geometria.DLinha) / xDuc) * 1000;
            var tensaoArmDupla = double.NaN;

            var defEscoa = (aco.Fyd / aco.Es) * 1000;

            if (deformacaoArmDupl > defEscoa) tensaoArmDupla = aco.Fyd / 100;
            else tensaoArmDupla = (aco.Es / 100) * (deformacaoArmDupl / 1000);

            var as2 = (md - mdDuctil) / ((tensaoArmDupla) * (geometria.AlturaUtil - geometria.DLinha) / 100);
            var as1 = ((concreto.AlphaC * concreto.Fcd * geometria.Base * concreto.Lambda * xDuc) + (as2 * tensaoArmDupla * 100)) / aco.Fyd;

            return (as1, as2);

        }
        #endregion

    }
}
