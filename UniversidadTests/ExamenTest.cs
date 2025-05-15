public class ExamenTest
{
    private Examen examen;

    [SetUp]
    public void Setup()
    {
        examen = new Examen();
    }

    [Test]
    public void Constructor_CreaInstancia_InicializaNotaFinalEnCero()
    {
        // Assert
        Assert.AreEqual(0, examen.NotaFinal);
    }

    [Test]
    public void EstaAprobado_NotaMenorA4_RetornaFalse()
    {
        // Arrange
        examen.NotaFinal = 3;

        // Act
        var resultado = examen.EstaAprobado();

        // Assert
        Assert.IsFalse(resultado);
    }

    [Test]
    public void EstaAprobado_NotaIgualA4_RetornaTrue()
    {
        // Arrange
        examen.NotaFinal = 4;

        // Act
        var resultado = examen.EstaAprobado();

        // Assert
        Assert.IsTrue(resultado);
    }

    [Test]
    public void EstaAprobado_NotaMayorA4_RetornaTrue()
    {
        // Arrange
        examen.NotaFinal = 8;

        // Act
        var resultado = examen.EstaAprobado();

        // Assert
        Assert.IsTrue(resultado);
    }

    [Test]
    public void PropiedadesMesaYAnio_AsignarValores_GuardaValoresCorrectamente()
    {
        // Arrange
        examen.Mesa = MesaExamen.Marzo;
        examen.AnioMesa = 2023;

        // Assert
        Assert.AreEqual(MesaExamen.Marzo, examen.Mesa);
        Assert.AreEqual(2023, examen.AnioMesa);
    }
} 