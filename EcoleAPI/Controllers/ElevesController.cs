// Controllers/ElevesController.cs
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class ElevesController : ControllerBase
{
    private static List<Eleve> eleves = new List<Eleve>
    {
        new Eleve { Id = 1, Nom = "Jean", Age = 10, Note = 15 }
    };

    // GET: api/Eleves/nom/{id}
    [HttpGet("nom/{id}")]
    public ActionResult<string> GetNom(int id)
    {
        var eleve = eleves.FirstOrDefault(e => e.Id == id);
        if (eleve == null) return NotFound();
        return eleve.Nom;
    }

    // GET: api/Eleves/age/{id}
    [HttpGet("age/{id}")]
    public ActionResult<int> GetAge(int id)
    {
        var eleve = eleves.FirstOrDefault(e => e.Id == id);
        if (eleve == null) return NotFound();
        return eleve.Age;
    }

    // GET: api/Eleves/note/{id}
    [HttpGet("note/{id}")]
    public ActionResult<double> GetNote(int id)
    {
        var eleve = eleves.FirstOrDefault(e => e.Id == id);
        if (eleve == null) return NotFound();
        return eleve.Note;
    }

    // POST: api/Eleves
    [HttpPost]
    public ActionResult<Eleve> AjouterEleve(Eleve eleve)
    {
        eleve.Id = eleves.Max(e => e.Id) + 1;
        eleves.Add(eleve);
        return CreatedAtAction(nameof(GetNom), new { id = eleve.Id }, eleve);
    }
}
