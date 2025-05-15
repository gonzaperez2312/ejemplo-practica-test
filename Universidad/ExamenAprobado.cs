public class ExamenAprobado
{
    public string NombreAlumno { get; set; }
    public string Carrera { get; set; }
    public string NombreMateria { get; set; }
    public int AnioAsignado { get; set; }
    public int AnioCursado { get; set; }
    public MesaExamen MesaExamen { get; set; }
    public int NotaFinal { get; set; }

    public ExamenAprobado()
    {
        NombreAlumno = string.Empty;
        Carrera = string.Empty;
        NombreMateria = string.Empty;
        AnioAsignado = 1;
        AnioCursado = DateTime.Now.Year;
        MesaExamen = MesaExamen.Marzo;
        NotaFinal = 0;
    }
} 