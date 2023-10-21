using EAD_Ticket_Reservation_system.Models;
using EAD_Ticket_Reservation_system.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAD_Ticket_Reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly Train _train;
        public TrainController(Train trainService)
        {
            this._train = trainService;
        }
       
        //API call to get all Trains
        [HttpGet]
        [Route("GetTrains")]
        public ActionResult<List<TrainModel>> Get()
        {
            return _train.Get();
        }

        //API call to get train detail by Id
        [HttpGet]
        [Route("GetTrainById/{Id}")]
        public ActionResult<TrainModel> Get(string id)
        {
            var train = _train.Get(id);

            if (train == null)
            {
                return NotFound($"Train with Id = {id} not found");
            }

            return train;
        }

        //API call to Add new Train to the system
        [HttpPost]
        [Route("AddTrain")]
        public ActionResult<TrainModel> Post([FromBody] TrainModel train)
        {
            //create method call
            _train.Create(train);

            return CreatedAtAction(nameof(Get), new { id = train.Id }, train);
        }

        // API call to Update Train details
        [HttpPut]
        [Route("UpdateTrain/{Id}")]
        public ActionResult Put(string id, [FromBody] TrainModel train)
        {
            var existingTrain = _train.Get(id);

            if (existingTrain == null)
            {
                return NotFound($"Train with Id = {id} not found");
            }

            //update method
            _train.Update(id, train);

            //return response
            return NoContent();
        }

        // API call to delete a Train
        [HttpDelete]
        [Route("DeleteTrain/{id}")]
        public ActionResult Delete(string id)
        {
            var train = _train.Get(id);

            //If Train details according to the Id is null
            if (train == null)
            {
                return NotFound($"Train with Id = {id} not found");
            }

            //Delete method
            _train.Delete(id);

            //return response
            return Ok($"Train with Id = {id} deleted");
        }
    }
}
