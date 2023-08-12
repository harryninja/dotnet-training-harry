using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;
using Microsoft.EntityFrameworkCore;
namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private DatabaseContext _repository { get; set; }
    public PersonController(DatabaseContext repository)
    {
        this._repository = repository;
    }
    [HttpGet]
    public ActionResult<List<Person>> Get()
    {
        var result = _repository.Persons.Include(p => p.ListaContrato).ToList();
        if(!result.Any()){
            return NoContent();
        }
        return Ok(result);
    }
    [HttpPost]
    public Person Post(Person pessoa)
    {
        _repository.Persons.Add(pessoa);
        _repository.SaveChanges();
        return pessoa;
    }
    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Person pessoa)
    {
        _repository.Persons.Update(pessoa);
        _repository.SaveChanges();
        return "dados id" + id + "atualizados";
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id)
    {
        var result = _repository.Persons.SingleOrDefault(e => e.Id == id);
        if(result is null){
            return BadRequest();
        }
        _repository.Persons.Remove(result);
        _repository.SaveChanges();
        return Ok("Deletado" + id);
    }

}