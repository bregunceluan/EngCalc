using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engcalc.core.Models.Materiais;

public abstract class Material
{
    public string Nome { get; set; } = string.Empty;
    public double PesoEspecifico { get; set; }
    public double Gama { get; set; }
    protected abstract void SetProperties();
}
