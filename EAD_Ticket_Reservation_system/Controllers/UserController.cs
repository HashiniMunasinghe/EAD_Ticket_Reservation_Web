using EAD_Ticket_Reservation_system.Models;
using EAD_Ticket_Reservation_system.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAD_Ticket_Reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly User _user;
        public UserController(User userService)
        {
            this._user = userService;
        }
        //API call to get all details of Users
        [HttpGet]
        [Route("GetUsers")]
        public ActionResult<List<UserModel>> Get()
        {
            return _user.Get();
        }

        //API call to get user details by Id
        [HttpGet]
        [Route("GetUserById/{Id}")]
        public ActionResult<UserModel> Get(string id)
        {
            var user = _user.Get(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            return user;
        }

        //API call to Add new User
        [HttpPost]
        [Route("AddUser")]
        public ActionResult<UserModel> Post([FromBody] UserModel user)
        {
            _user.Create(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        //API call to Update User details
        [HttpPut]
        [Route("UpdateUser/{Id}")]
        public ActionResult Put(string id, [FromBody] UserModel user)
        {
            var existingUser = _user.Get(id);

            if (existingUser == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            _user.Update(id, user);
            return NoContent();
        }

        //API call to Delete User Details
        [HttpDelete]
        [Route("DeleteUser/{Id}")]
        public ActionResult Delete(string id)
        {
            var user = _user.Get(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            //delete method of user
            _user.Delete(id);

            //return response
            return Ok($"User with Id = {id} deleted");
        }
    }
}
