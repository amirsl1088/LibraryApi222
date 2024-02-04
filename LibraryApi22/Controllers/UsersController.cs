using LibraryApi22.DTO;
using LibraryApi22.Models;
using LibraryApi22.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static LibraryNewApi.Controllers.UserController;

namespace LibraryApi22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserService Service = new UserService();
        [HttpPost("add")]
        public int AddUser([FromBody] AddUserDto dto)
        {
            return Service.AddUser(dto);
        }
        [HttpPut("update")]
        public void UpdateUser([FromQuery]int id, [FromBody]UpdateUsersDto dto)
        {
            Service.UpdateUser(id, dto);
        }
        [HttpDelete("delete/{id}")]
        public void DeleteUser([FromRoute]int id)
        {
            Service.DeleteUser(id);
        }
        [HttpGet("get-users")]
        public List<GetUserDto> GetUsers([FromQuery]string username = null)
        {
            return Service.GetUsers(username);
        }
        [HttpGet("get-users-books/{userid}")]
        public List<GetUsersBookDto> getUsersBooks([FromRoute]int userid)
        {
            return Service.GetUsersBooks(userid);
        }
    }
}
