using Microsoft.AspNetCore.Mvc;
using Proj_Mercado_Seguros.src.Models;
using Proj_Mercado_Seguros.src.Persisntence;
using Microsoft.EntityFrameworkCore;

namespace Proj_Mercado_Seguros.src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private DataBaseContext _context { get; set; }
    public PersonController(DataBaseContext context)
    {
        this._context = context ;
    }

    [HttpGet]
    public List<Pessoa> Get()
    {
        return _context.Pessoas.Include(p => p.contratos).ToList() ;
    }

    [HttpPost]
    public Pessoa Post(Pessoa pessoa) {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();    

        return pessoa;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Pessoa pessoa)
    {
        _context.Pessoas.Update(pessoa);
        _context.SaveChanges();

        return "Dados do Id " + id + " atualizados";
    }
    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id)
    {
        return "Deletado pessoa de Id " + id;


    }
}