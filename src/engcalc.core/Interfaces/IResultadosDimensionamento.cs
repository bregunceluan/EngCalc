using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Interfaces;

public interface IResultadosDimensionamento
{
    public double EsforcoSolicitante { get; set; }
    public double EsforcoResistente { get; set; }
    public double SdRd { get; set; }


}
