namespace engcalc.api.Dto;

public class SolicitacaoDto
{
    public double V { get; set; }
    public double M { get; set; }
    public double T { get; set; }

    public void Majorar(double majorador)
    {
        if (V > 0)
        {
            V *= majorador;
        }
        if (M > 0)
        {
            M *= majorador;
        }
        if (T > 0)
        {
            T *= majorador;
        }
    }

}