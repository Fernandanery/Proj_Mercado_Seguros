using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Models;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase

{
    [HttpGet]
    public Person Get()
    {
        Person pessoa = new Person ();
        return pessoa;
    }

}