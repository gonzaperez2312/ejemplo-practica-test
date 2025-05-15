using System;
using System.Collections.Generic;
using System.Linq;

public class Universidad
{
    public List<Alumno> Alumnos { get; set; }

    public Universidad()
    {
        Alumnos = new List<Alumno>();
    }

    public ObtenerExamenesAprobadosResponse ObtenerExamenesAprobados(string dni)
    {
        var response = new ObtenerExamenesAprobadosResponse();
        
        var alumno = Alumnos.FirstOrDefault(a => a.DNI == dni);
        if (alumno == null)
        {
            response.Error = "El alumno no existe";
            return response;
        }

        foreach (var materia in alumno.HistoriaAcademica)
        {
            foreach (var examen in materia.Examenes.Where(e => e.EstaAprobado()))
            {
                response.Examenes.Add(new ExamenAprobado
                {
                    NombreAlumno = alumno.Nombre,
                    Carrera = alumno.Carrera,
                    NombreMateria = materia.Nombre,
                    AnioAsignado = materia.AnioAsignado,
                    AnioCursado = materia.AnioCursado,
                    MesaExamen = examen.Mesa,
                    NotaFinal = examen.NotaFinal
                });
            }
        }

        return response;
    }

    public int ObtenerCantidadExamenesNoAprobados(MesaExamen mesa, int anio)
    {
        return Alumnos.SelectMany(a => a.HistoriaAcademica)
                     .SelectMany(m => m.Examenes)
                     .Count(e => e.Mesa == mesa && e.AnioMesa == anio && !e.EstaAprobado());
    }

    public List<Materia> ObtenerMateriasRecursadas(string dni)
    {
        var alumno = Alumnos.FirstOrDefault(a => a.DNI == dni);
        if (alumno == null)
            return new List<Materia>();

        return alumno.HistoriaAcademica.Where(m => m.EstaRecursada()).ToList();
    }
} 