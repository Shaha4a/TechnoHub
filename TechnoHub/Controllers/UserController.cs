using Microsoft.AspNetCore.Mvc;
using TechnoHub.Service;
using TechnoHub.Model;

namespace TechnoHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) 
        { 
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UserModel user)
        {
            ResponseModel abc= new ResponseModel() ;
            try
            {
                abc = await _userService.CreateUser(user);
               
            }
            catch (Exception ex)
            {
                abc.Code = -1;
                abc.Message = ex.Message;
                return NotFound(abc);
            }
            return Ok(abc);

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UserModel user)
        {
            ResponseModel abc= new ResponseModel() ;
            try
            {
                abc = await _userService.UpdateUser(user);
                return Ok(abc);
            }
            catch(Exception ex)
            {
                abc.Code= -1;
                abc.Message = ex.Message;
                return BadRequest(abc);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<List<UserModel>> GetById([FromRoute] int id)
        {
            return await _userService.GetUserById(id);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseModel> Delete([FromRoute] int id)
        {
            ResponseModel abc = new ResponseModel();
            try
            {
                abc = await _userService.DeleteUser(id);
                return abc;
            }
            catch (Exception ex)
            {
                abc.Code = -1;
                abc.Message = ex.Message;
                return abc;
            }
        }
    }
}
