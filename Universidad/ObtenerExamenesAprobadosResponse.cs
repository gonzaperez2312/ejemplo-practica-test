public class ObtenerExamenesAprobadosResponse
{
    public string Error { get; set; }
    public List<ExamenAprobado> Examenes { get; set; }

    public ObtenerExamenesAprobadosResponse()
    {
        Error = string.Empty;
        Examenes = new List<ExamenAprobado>();
    }
} 