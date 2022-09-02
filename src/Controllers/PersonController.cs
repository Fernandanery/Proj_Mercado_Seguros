using Microsoft.AspNetCore.Mvc;
using Proj_Mercado_Seguros.src.Models;
using Proj_Mercado_Seguros.src.Persisntence;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Proj_Mercado_Seguros.src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private DataBaseContext _context { get; set; }
    public PersonController(DataBaseContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<List<Pessoa>> Get()
    {
        //OK retorna 200, Se não tiver conteudo retorna NotFound 204
        var result = _context.Pessoas.Include(p => p.contratos).ToList();

        if (!result.Any())
        {
            return NoContent();
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult <Pessoa> Post([FromBody]Pessoa pessoa)
    {
        
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();

        return Created ("Criado com sucesso" , pessoa);
    }

    [HttpPut("{id}")]
    public ActionResult <Object> Update([FromRoute] int id, [FromBody] Pessoa pessoa)
    {
        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);

        if (result is null) {
            return NotFound(new {
                msg = "Registro não encontrado",
                status = HttpStatusCode.NotFound
            });
        }

        //Bloco de tratamento de erro
        try
        {
        _context.Pessoas.Update(pessoa);
        _context.SaveChanges();
        }
        catch (SystemException) {

          return BadRequest (new
            {
                msg = "Houve erro ao solicitar a atualização",
                status = HttpStatusCode.OK
            });
        }

        return Ok (new {
            msg = "Dados atualizados com sucesso" ,
            status = HttpStatusCode.OK
        });
    }
    [HttpDelete("{id}")]

    public ActionResult<Object> Delete([FromRoute] int id)
    {
        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);

        if (result is null)
        {
            return BadRequest(new
            {
                msg = "Conteudo inexitente, solicitação inválida",
                status = HttpStatusCode.BadRequest
            });
        }

        _context.Pessoas.Remove(result);
        _context.SaveChanges();

        return Ok(new {
            msg = "Deletado com sucesso",
            status = HttpStatusCode.OK
            });
    }
}