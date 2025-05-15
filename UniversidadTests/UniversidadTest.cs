using System;
using System.Collections.Generic;
using System.Linq;

public class UniversidadTest
{
    private Universidad universidad;
    private Alumno alumno;
    private Materia materia;

    [SetUp]
    public void Setup()
    {
        universidad = new Universidad();

        //Crear multiples alumnos configurados
        CrearAlumnoConMaterias("Gonzalo", "36814249", "Abogacia", 2025, 3, 1, 2);
        CrearAlumnoConMaterias("Gonzalo 2", "36814249", "Diseño", 2025, 3, 1, 0);
        
        //Inicializar un alumno que luego voy a cambiar
        alumno = new Alumno
        {
            Nombre = "Juan Perez",
            DNI = "12345678",
            Carrera = "Ingeniería",
            AnioActual = 2
        };
        materia = new Materia
        {
            Nombre = "Matemática",
            AnioAsignado = 1,
            AnioCursado = 2023
        };
    }

    [Test]
    public void ObtenerExamenesAprobados_AlumnoNoExiste_RetornaError()
    {
        // Arrange
        string dniInexistente = "99999999";

        // Act
        var resultado = universidad.ObtenerExamenesAprobados(dniInexistente);

        // Assert
        Assert.AreEqual("El alumno no existe", resultado.Error);
        Assert.AreEqual(0, resultado.Examenes.Count);
    }

    [Test]
    public void ObtenerExamenesAprobados_AlumnoExisteSinExamenes_RetornaListaVacia()
    {
        // Arrange
        universidad.Alumnos.Add(alumno);

        // Act
        var resultado = universidad.ObtenerExamenesAprobados(alumno.DNI);

        // Assert
        Assert.IsEmpty(resultado.Error);
        Assert.AreEqual(0, resultado.Examenes.Count);
    }

    [Test]
    public void ObtenerExamenesAprobados_AlumnoConExamenesAprobados_RetornaExamenes()
    {
        // Arrange
        var examen = new Examen
        {
            Mesa = MesaExamen.Marzo,
            AnioMesa = 2023,
            NotaFinal = 8
        };
        materia.Examenes.Add(examen);
        alumno.HistoriaAcademica.Add(materia);
        universidad.Alumnos.Add(alumno);

        // Act
        var resultado = universidad.ObtenerExamenesAprobados(alumno.DNI);

        // Assert
        Assert.IsEmpty(resultado.Error);
        Assert.AreEqual(1, resultado.Examenes.Count);
        Assert.AreEqual(alumno.Nombre, resultado.Examenes[0].NombreAlumno);
        Assert.AreEqual(materia.Nombre, resultado.Examenes[0].NombreMateria);
        Assert.AreEqual(8, resultado.Examenes[0].NotaFinal);
    }

    [Test]
    public void ObtenerCantidadExamenesNoAprobados_SinExamenes_RetornaCero()
    {
        // Arrange
        universidad.Alumnos.Add(alumno);

        // Act
        var resultado = universidad.ObtenerCantidadExamenesNoAprobados(MesaExamen.Marzo, 2023);

        // Assert
        Assert.AreEqual(0, resultado);
    }

    [Test]
    public void ObtenerCantidadExamenesNoAprobados_ConExamenesDesaprobados_RetornaCantidadCorrecta()
    {
        // Arrange
        var examen1 = new Examen { Mesa = MesaExamen.Marzo, AnioMesa = 2023, NotaFinal = 2 };
        var examen2 = new Examen { Mesa = MesaExamen.Marzo, AnioMesa = 2023, NotaFinal = 3 };
        materia.Examenes.Add(examen1);
        materia.Examenes.Add(examen2);
        alumno.HistoriaAcademica.Add(materia);
        universidad.Alumnos.Add(alumno);

        // Act
        var resultado = universidad.ObtenerCantidadExamenesNoAprobados(MesaExamen.Marzo, 2023);

        // Assert
        Assert.AreEqual(2, resultado);
    }

    [Test]
    public void ObtenerMateriasRecursadas_AlumnoSinMateriasRecursadas_RetornaListaVacia()
    {
        // Arrange
        universidad.Alumnos.Add(alumno);

        // Act
        var resultado = universidad.ObtenerMateriasRecursadas(alumno.DNI);

        // Assert
        Assert.AreEqual(0, resultado.Count);
    }

    [Test]
    public void ObtenerMateriasRecursadas_AlumnoConMateriaRecursada_RetornaMaterias()
    {
        // Arrange
        var examen1 = new Examen { Mesa = MesaExamen.Marzo, AnioMesa = 2023, NotaFinal = 2 };
        var examen2 = new Examen { Mesa = MesaExamen.Septiembre, AnioMesa = 2023, NotaFinal = 3 };
        var examen3 = new Examen { Mesa = MesaExamen.Mayo, AnioMesa = 2023, NotaFinal = 2 };
        materia.Examenes.Add(examen1);
        materia.Examenes.Add(examen2);
        materia.Examenes.Add(examen3);
        alumno.HistoriaAcademica.Add(materia);
        universidad.Alumnos.Add(alumno);

        // Act
        var resultado = universidad.ObtenerMateriasRecursadas(alumno.DNI);

        // Assert
        Assert.AreEqual(1, resultado.Count);
        Assert.AreEqual(materia.Nombre, resultado[0].Nombre);
    }

    private Alumno CrearAlumnoConMaterias(string nombre, string dni, string carrera, int anioActual, 
        int cantidadMaterias, int materiasAprobadas, int materiasDesaprobadas)
    {
        var alumno = new Alumno
        {
            Nombre = nombre,
            DNI = dni,
            Carrera = carrera,
            AnioActual = anioActual
        };

        for (int i = 1; i <= cantidadMaterias; i++)
        {
            var materia = new Materia
            {
                Nombre = $"Materia {i}",
                AnioAsignado = (i / 6) + 1,
                AnioCursado = 2023
            };

            // Agregamos exámenes aprobados
            for (int j = 1; j <= materiasAprobadas; j++)
            {
                materia.Examenes.Add(new Examen
                {
                    Mesa = MesaExamen.Marzo,
                    AnioMesa = 2023,
                    NotaFinal = 7 
                });
            }

            // Agregamos exámenes desaprobados
            for (int j = 1; j <= materiasDesaprobadas; j++)
            {
                materia.Examenes.Add(new Examen
                {
                    Mesa = MesaExamen.Mayo, 
                    AnioMesa = 2023,
                    NotaFinal = 2 
                });
            }

            alumno.HistoriaAcademica.Add(materia);
        }

        universidad.Alumnos.Add(alumno);
        return alumno;
    }
} 