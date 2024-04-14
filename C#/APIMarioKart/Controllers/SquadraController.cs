using APIMarioKart.DTO;
using APIMarioKart.Services;
using APIMarioKart.Utils;
using Microsoft.AspNetCore.Mvc;

namespace APIMarioKart.Controllers
{

    [Route("api/Squadra")]
    [ApiController]
    public class SquadraController : Controller
    {


        private readonly SquadraService _service;
        public SquadraController(SquadraService service)
        {
            _service = service;
        }





        [HttpGet("ListaSquadra")]
        public ActionResult<Risposta> ElencoSquadra()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciSquadra()
            });
        }





        [HttpPost("inserisciSquadra")]
        public IActionResult InserisciSquad(DTOSquadra objPer)
        {
            if (_service.InserisciSquadra(objPer))
            {
                return Ok();
            }

            return BadRequest();

        }



        [HttpPut("modificaSquadra")]
        public IActionResult ModificaSquadra(DTOSquadra objPer)
        {
            if (_service.ModificaSquadra(objPer))
                return Ok();
            return BadRequest();
        }


        [HttpPost("Aggiungi nella squadra/{codPer}/{sqCod}")]
        public IActionResult InsertIntoSquadra(string codPer, string sqCod)
        {
            if (_service.InserisciPersonaggionellasquadra(codPer, sqCod))
                return Ok();
            return BadRequest();
        }




    }

}
