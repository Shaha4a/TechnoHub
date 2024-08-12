using Microsoft.AspNetCore.Mvc;
using TechnoHub.Model;
using TechnoHub.Service;

namespace TechnoHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;
        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CourseModel course)
        {
            ResponseModel abc = new ResponseModel();
            try
            {
                abc = await _courseService.CreateUser(course);

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
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] CourseModel course)
        {
            ResponseModel abc = new ResponseModel();
            try
            {
                abc = await _courseService.UpdateUser(course);
                return Ok(abc);
            }
            catch (Exception ex)
            {
                abc.Code = -1;
                abc.Message = ex.Message;
                return BadRequest(abc);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseModel> Delete([FromRoute] int id)
        {
            ResponseModel abc = new ResponseModel();
            try
            {
                abc = await _courseService.DeleteUser(id);
                return abc;
            }
            catch (Exception ex)
            {
                abc.Code = -1;
                abc.Message = ex.Message;
                return abc;
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<List<CourseModel>> GetById([FromRoute] int id)
        {
            return await _courseService.GetUserById(id);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<CourseModel>> GetAllUsers()
        {
            return await _courseService.GetAllUsers();
        }

        
    }
}


