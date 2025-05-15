using System.Collections.Generic;

public class MateriaTest
{
    private Materia materia;

    [SetUp]
    public void Setup()
    {
        materia = new Materia
        {
            Nombre = "Matemática",
            AnioAsignado = 1,
            AnioCursado = 2023
        };
    }

    [Test]
    public void Constructor_CreaInstancia_InicializaValoresPorDefecto()
    {
        // Act
        var nuevaMateria = new Materia();

        // Assert
        Assert.AreEqual(1, nuevaMateria.AnioAsignado);
        Assert.IsNotNull(nuevaMateria.Examenes);
        Assert.AreEqual(0, nuevaMateria.Examenes.Count);
    }

    [Test]
    public void EstaRecursada_SinExamenes_RetornaFalse()
    {
        // Act
        var resultado = materia.EstaRecursada();

        // Assert
        Assert.IsFalse(resultado);
    }

    [Test]
    public void EstaRecursada_ConDosExamenesDesaprobados_RetornaFalse()
    {
        // Arrange
        materia.Examenes.Add(new Examen { NotaFinal = 2 });
        materia.Examenes.Add(new Examen { NotaFinal = 3 });

        // Act
        var resultado = materia.EstaRecursada();

        // Assert
        Assert.IsFalse(resultado);
    }

    [Test]
    public void EstaRecursada_ConTresExamenesDesaprobados_RetornaTrue()
    {
        // Arrange
        materia.Examenes.Add(new Examen { NotaFinal = 2 });
        materia.Examenes.Add(new Examen { NotaFinal = 3 });
        materia.Examenes.Add(new Examen { NotaFinal = 1 });

        // Act
        var resultado = materia.EstaRecursada();

        // Assert
        Assert.IsTrue(resultado);
    }

    [Test]
    public void EstaRecursada_ConTresExamenesUnoAprobado_RetornaFalse()
    {
        // Arrange
        materia.Examenes.Add(new Examen { NotaFinal = 2 });
        materia.Examenes.Add(new Examen { NotaFinal = 8 });
        materia.Examenes.Add(new Examen { NotaFinal = 1 });

        // Act
        var resultado = materia.EstaRecursada();

        // Assert
        Assert.IsFalse(resultado);
    }
} 