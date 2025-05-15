public class Alumno
{
    public string Nombre { get; set; }
    public string DNI { get; set; }
    public string Carrera { get; set; }
    public int AnioActual { get; set; }
    public List<Materia> HistoriaAcademica { get; set; }

    public Alumno()
    {
        HistoriaAcademica = new List<Materia>();
    }
} 