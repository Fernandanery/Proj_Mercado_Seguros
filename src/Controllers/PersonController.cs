using Microsoft.AspNetCore.Mvc;
using Proj_Mercado_Seguros.src.Models;

namespace Proj_Mercado_Seguros.src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase

{
    [HttpGet]
    public Pessoa Get()
    {
        Pessoa pessoa = new Pessoa("Fernanda", 30, "402029358471");
        Contrato NovoContrato = new Contrato(50.63, "abc123");

        pessoa.contratos.Add(NovoContrato);

        return pessoa;
    }
    [HttpPost]
    public Pessoa Post(Pessoa pessoa)
    {

        return pessoa;
    }

    [HttpPut("{id}")]
    public string Update([FromRoute] int id, [FromBody] Pessoa pessoa)
    {
        Console.WriteLine(id);
        Console.WriteLine(pessoa);
        return "Dados do Id" + " " + id + "atualizados";
    }
    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id)
    {
        return "Deletado pessoa de Id " + id;


    }
}