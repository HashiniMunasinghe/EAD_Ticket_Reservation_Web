using EAD_Ticket_Reservation_system.Models;
using EAD_Ticket_Reservation_system.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAD_Ticket_Reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly Reservation _reservation;
        public ReservationController(Reservation reservationService)
        {
            this._reservation = reservationService;
        }
        
        //API to get Reservations
        [HttpGet]
        [Route("GetReservations")]
        public ActionResult<List<ReservationModel>> GetReservations()
        {
            return _reservation.Get();
        }

        //API call to get reservation from ID
        [HttpGet]
        [Route("GetReservationById/{id}")]
        public ActionResult<ReservationModel> GetReservationById(string id)
        {
            var reservation = _reservation.Get(id);

            //If there is no reservation from the Id
            if (reservation == null)
            {
                //return response
                return NotFound($"Reservation with Id = {id} not found");
            }

            //return response
            return reservation;
        }

        //API to add new Reservation
        [HttpPost]
        [Route("AddReservation")]
        public ActionResult<ReservationModel> AddReservation([FromBody] ReservationModel reservation)
        {
            _reservation.Create(reservation);

            return CreatedAtAction(nameof(GetReservations), new { id = reservation.Id }, reservation);
        }

        //API to Update Reservation
        [HttpPut]
        [Route("UpdateReservation/{Id}")]

        public ActionResult UpdateReservation(string id, [FromBody] ReservationModel reservation)
        {
            var existingReservation = _reservation.Get(id);

            if (existingReservation == null)
            {
                return NotFound($"Reservation with Id = {id} not found");
            }
            //update method
            _reservation.Update(id, reservation);

            //return response
            return NoContent();
        }

        //API to Delete Reservation
        [HttpDelete]
        [Route("DeleteReservation/{Id}")]
        public ActionResult DeleteReservation(string id)
        {
            var reservation = _reservation.Get(id);

            if (reservation == null)
            {
                return NotFound($"Reservation with Id = {id} not found");
            }

            //delete method
            _reservation.Delete(id);

            //return response
            return Ok($"Reservation with Id = {id} deleted");
        }
    }
}
