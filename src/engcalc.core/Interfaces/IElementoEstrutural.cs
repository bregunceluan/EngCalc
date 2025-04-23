using engcalc.core.Models.Dimensionamento;
using engcalc.core.Models.Geometrias;
using engcalc.core.Models.Materiais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Interfaces;

public interface IElementoEstrutural
{
    Geometria Geometria { get; set; }
    Solicitacao Solicitacao { get; set; }
    Material Material { get; set; }

    void Dimensionar();
}
