using engcalc.core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Dimensionamento;

public class Solicitacao
{
    public double V { get; set; } 
    public double M { get; set; }
    public double T { get; set; }
    public eSolicitacao TipoSolicitacao { get; set; }

    public Solicitacao(double v = 0, double m = 0, double t = 0)
    {
        V = v;
        M = m;
        T = t;
        TipoSolicitacao = GetSolicitacao();
    }

    private eSolicitacao GetSolicitacao()
    {
        if (V != 0 && M == 0 && T == 0)
        {
            return eSolicitacao.CORTANTE;
        }
        if (V == 0 && M == 0 && T != 0)
        {
            return eSolicitacao.TORCAO;
        }
        if (V == 0 && M != 0 && T == 0)
        {
            return eSolicitacao.FLEXAO;
        }
        if (V != 0 && M != 0 && T == 0)
        {
            return eSolicitacao.FLEXAOCORTANTE;
        }
        if (V == 0 && M != 0 && T != 0)
        {
            return eSolicitacao.FLEXOTORCAO;
        }
        if (V != 0 && M == 0 && T != 0)
        {
            return eSolicitacao.TORCAOCORTANTE;
        }
        if (V != 0 && M != 0 && T != 0)
        {
            return eSolicitacao.FLEXOTORCAOeCORTANTE;

        }
        return eSolicitacao.INDEFINIDO;
    }
}
