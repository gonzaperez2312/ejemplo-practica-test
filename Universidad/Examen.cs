public class Examen
{
    public MesaExamen Mesa { get; set; }
    public int AnioMesa { get; set; }
    public int NotaFinal { get; set; }

    public Examen()
    {
        NotaFinal = 0;
    }

    public bool EstaAprobado()
    {
        return NotaFinal >= 4;
    }
} 