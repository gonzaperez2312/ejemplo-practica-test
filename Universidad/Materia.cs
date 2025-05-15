public class Materia
{
    public string Nombre { get; set; }
    public int AnioAsignado { get; set; }
    public int AnioCursado { get; set; }
    public List<Examen> Examenes { get; set; }

    public Materia()
    {
        Examenes = new List<Examen>();
    }

    public bool EstaRecursada()
    {
        return Examenes.Count(e => !e.EstaAprobado()) >= 3;
    }
} 