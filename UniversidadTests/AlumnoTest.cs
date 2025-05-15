using System.Collections.Generic;

public class AlumnoTest
{
    private Alumno alumno;

    [SetUp]
    public void Initialize()
    {
        alumno = new Alumno();
    }

    [Test]
    public void Constructor_CreaInstancia_InicializaHistoriaAcademica()
    {
        // Assert
        Assert.IsNotNull(alumno.HistoriaAcademica);
        Assert.AreEqual(0, alumno.HistoriaAcademica.Count);
    }

    [Test]
    public void PropiedadesBasicas_AsignarValores_GuardaValoresCorrectamente()
    {
        // Arrange
        alumno.Nombre = "Juan Perez";
        alumno.DNI = "12345678";
        alumno.Carrera = "Ingeniería";
        alumno.AnioActual = 2;

        // Assert
        Assert.AreEqual("Juan Perez", alumno.Nombre);
        Assert.AreEqual("12345678", alumno.DNI);
        Assert.AreEqual("Ingeniería", alumno.Carrera);
        Assert.AreEqual(2, alumno.AnioActual);
    }

    [Test]
    public void HistoriaAcademica_AgregarMateria_AgregaCorrectamente()
    {
        // Arrange
        var materia = new Materia { Nombre = "Matemática" };

        // Act
        alumno.HistoriaAcademica.Add(materia);

        // Assert
        Assert.AreEqual(1, alumno.HistoriaAcademica.Count);
        Assert.AreEqual("Matemática", alumno.HistoriaAcademica[0].Nombre);
    }

    [Test]
    public void HistoriaAcademica_AgregarVariasMaterias_MantieneOrden()
    {
        // Arrange
        var materia1 = new Materia { Nombre = "Matemática" };
        var materia2 = new Materia { Nombre = "Física" };
        var materia3 = new Materia { Nombre = "Química" };

        // Act
        alumno.HistoriaAcademica.Add(materia1);
        alumno.HistoriaAcademica.Add(materia2);
        alumno.HistoriaAcademica.Add(materia3);

        // Assert
        Assert.AreEqual(3, alumno.HistoriaAcademica.Count);
        Assert.AreEqual("Matemática", alumno.HistoriaAcademica[0].Nombre);
        Assert.AreEqual("Física", alumno.HistoriaAcademica[1].Nombre);
        Assert.AreEqual("Química", alumno.HistoriaAcademica[2].Nombre);
    }
} 