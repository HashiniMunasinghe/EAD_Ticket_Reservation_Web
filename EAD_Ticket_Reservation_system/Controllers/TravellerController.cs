using EAD_Ticket_Reservation_system.Models;
using EAD_Ticket_Reservation_system.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAD_Ticket_Reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravellerController : ControllerBase
    {
        private readonly Traveller _traveller;
        public TravellerController(Traveller travellerService)
        {
            this._traveller = travellerService;
        }
        //API call to get all Traveller details
        [HttpGet]
        [Route("GetTravellers")]
        public ActionResult<List<TravellerModel>> Get()
        {
            return _traveller.Get();
        }

        //API call to get traveller details by Id
        [HttpGet]
        [Route("GetTravellerById/{Id}")]
        public ActionResult<TravellerModel> Get(string id)
        {
            var traveller = _traveller.Get(id);

            if (traveller == null)
            {
                return NotFound($"Traveller with Id = {id} not found");
            }

            return traveller;
        }

        //API call to add a new traveller
        [HttpPost]
        [Route("AddTraveller")]
        public ActionResult<TravellerModel> Post([FromBody] TravellerModel traveller)
        {
            _traveller.Create(traveller);

            return CreatedAtAction(nameof(Get), new { id = traveller.Id }, traveller);
        }

        //API call to update existing Traveller
        [HttpPut]
        [Route("UpdateTraveller/{Id}")]
        public ActionResult Put(string id, [FromBody] TravellerModel traveller)
        {
            var existingTraveller = _traveller.Get(id);

            if (existingTraveller == null)
            {
                return NotFound($"Traveller with Id = {id} not found");
            }
            
            //update method
            _traveller.Update(id, traveller);

            //return response
            return NoContent();
        }

        //API call to delete traveller details
        [HttpDelete]
        [Route("DeleteTraveller/{Id}")]
        public ActionResult Delete(string id)
        {
            var traveller = _traveller.Get(id);

            if (traveller == null)
            {
                return NotFound($"Traveller with Id = {id} not found");
            }

            //delete method
            _traveller.Delete(id);

            //return response
            return Ok($"Traveller with Id = {id} deleted");
        }
    }
}
