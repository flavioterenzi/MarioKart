using APIMarioKart.DTO;
using APIMarioKart.Services;
using APIMarioKart.Utils;
using Microsoft.AspNetCore.Mvc;

namespace APIMarioKart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaggioController : Controller
    {
        private readonly PersonaggiServices _service;

        public PersonaggioController(PersonaggiServices service)
        {
            _service = service;
        }

        [HttpGet("ListaPersonaggi")]
        public ActionResult<Risposta> ElencoPersonaggi()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciPersonaggi()
            });
        }


        [HttpPost("inserisci")]
        public IActionResult InserisciPers(DTOPersonaggi objPer)
        {
            if (_service.InserisciPersonaggi(objPer))
            {
                return Ok();
            }

            return BadRequest();

        }



        [HttpPut("modificaPersonaggio")]
        public IActionResult ModificaPersonaggio(DTOPersonaggi objPer)
        {
            if (_service.ModificaPersonaggio(objPer))
                return Ok();
            return BadRequest();
        }

    

    }
}
