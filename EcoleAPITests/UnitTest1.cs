using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcoleAPI;
using System.Linq;

[TestClass]
public class ElevesControllerTests
{
    private ElevesController _controller;

    [TestInitialize]
    public void SetUp()
    {
        _controller = new ElevesController();
    }

    [TestMethod]
    public void GetNom_WithValidId_ReturnsExpectedNom()
    {
        var expectedNom = "Jean";
        var result = _controller.GetNom(1);

        Assert.IsInstanceOfType(result.Result, typeof(ActionResult<string>));
        Assert.AreEqual(expectedNom, result.Value);
    }

    [TestMethod]
    public void GetNom_WithInvalidId_ReturnsNotFound()
    {
        var invalidId = 999;
        var result = _controller.GetNom(invalidId);

        Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
    }

    [TestMethod]
    public void GetAge_WithValidId_ReturnsExpectedAge()
    {
        var expectedAge = 10;
        var result = _controller.GetAge(1);

        Assert.IsInstanceOfType(result.Result, typeof(ActionResult<int>));
        Assert.AreEqual(expectedAge, result.Value);
    }

    [TestMethod]
    public void GetAge_WithInvalidId_ReturnsNotFound()
    {
        var invalidId = 999;
        var result = _controller.GetAge(invalidId);

        Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
    }

    [TestMethod]
    public void GetNote_WithValidId_ReturnsExpectedNote()
    {
        var expectedNote = 15.0;
        var result = _controller.GetNote(1);

        Assert.IsInstanceOfType(result.Result, typeof(ActionResult<double>));
        Assert.AreEqual(expectedNote, result.Value);
    }

    [TestMethod]
    public void GetNote_WithInvalidId_ReturnsNotFound()
    {
        var invalidId = 999;
        var result = _controller.GetNote(invalidId);

        Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
    }

    [TestMethod]
    public void AjouterEleve_WithValidEleve_ReturnsCreatedEleve()
    {
        var newEleve = new Eleve { Nom = "Marc", Age = 11, Note = 16.5 };
        var result = _controller.AjouterEleve(newEleve);

        Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
        var createdEleve = ((CreatedAtActionResult)result.Result).Value as Eleve;
        Assert.AreEqual(newEleve.Nom, createdEleve.Nom);
        Assert.AreEqual(newEleve.Age, createdEleve.Age);
        Assert.AreEqual(newEleve.Note, createdEleve.Note);
    }
}
