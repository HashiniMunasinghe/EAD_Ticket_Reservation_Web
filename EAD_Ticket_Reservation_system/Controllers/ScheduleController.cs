using EAD_Ticket_Reservation_system.Models;
using EAD_Ticket_Reservation_system.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAD_Ticket_Reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly Schedule _schedule;
        public ScheduleController(Schedule scheduleService)
        {
            this._schedule = scheduleService;
        }

        //API to get Schedules
        [HttpGet]
        [Route("GetSchedules")]
        public ActionResult<List<ScheduleModel>> GetSchedules()
        {
            return _schedule.Get();
        }

        //API call to get schedule from ID
        [HttpGet]
        [Route("GetScheduleById/{id}")]
        public ActionResult<ScheduleModel> GetScheduleById(string id)
        {
            var schedule = _schedule.Get(id);

            //If there is no schedule from the Id
            if (schedule == null)
            {
                //return response
                return NotFound($"Schedule with Id = {id} not found");
            }

            //return response
            return schedule;
        }

        //API to add new Schedule
        [HttpPost]
        [Route("AddSchedule")]
        public ActionResult<ScheduleModel> AddSchedule([FromBody] ScheduleModel schedule)
        {
            _schedule.Create(schedule);

            return CreatedAtAction(nameof(GetSchedules), new { id = schedule.Id }, schedule);
        }

        //API to Update Schedule
        [HttpPut]
        [Route("UpdateSchedule/{Id}")]

        public ActionResult UpdateSchedule(string id, [FromBody] ScheduleModel schedule)
        {
            var existingSchedule = _schedule.Get(id);

            if (existingSchedule == null)
            {
                return NotFound($"Schedule with Id = {id} not found");
            }
            //update method
            _schedule.Update(id, schedule);

            //return response
            return NoContent();
        }

        //API to Delete Schedule
        [HttpDelete]
        [Route("DeleteSchedule/{Id}")]
        public ActionResult DeleteSchedule(string id)
        {
            var schedule = _schedule.Get(id);

            if (schedule == null)
            {
                return NotFound($"Schedule with Id = {id} not found");
            }

            //delete method
            _schedule.Delete(id);

            //return response
            return Ok($"Schedule with Id = {id} deleted");
        }
    }
}