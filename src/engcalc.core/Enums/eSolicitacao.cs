using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Enums;

public enum eSolicitacao
{
    CORTANTE,
    FLEXAO,
    TORCAO,
    FLEXOTORCAO,
    FLEXAOCORTANTE,
    TORCAOCORTANTE,
    FLEXOTORCAOeCORTANTE,
    INDEFINIDO
}