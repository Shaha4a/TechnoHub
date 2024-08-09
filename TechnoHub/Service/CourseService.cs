using TechnoHub.Model;
using TechnoHub.Repositories;

namespace TechnoHub.Service
{
    public class CourseService
    {

        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ResponseModel> CreateUser(CourseModel course)
        {
            int id = 0;
            ResponseModel response = new ResponseModel();
            id = await _courseRepository.Create(course);
            if (id != 0)
            {
                response.Code = 1;
                response.Message = "Успешно";
                response.UserId = id;
            }
            else
            {
                response.Code = -1;
                response.Message = "Не успешно";
                response.UserId = id;
            }
            return response;
        }
        public async Task<ResponseModel> UpdateUser(CourseModel course)
        {
            ResponseModel response = new ResponseModel();
            var userlist = await _courseRepository.GetById((int)course.id);
            if (userlist.Count == 0)
            {
                response.Code = -1;
                response.Message = "Не успешно";
                return response;
            }
            else
            {
                _courseRepository.Update(course);
                response.Code = 1;
                response.Message = "Успешно";
                return response;
            }
        }
        public async Task<List<CourseModel>> GetUserById(int id)
        {
            return await _courseRepository.GetById(id);
        }
        public async Task<List<CourseModel>> GetAllUsers()
        {
            return await _courseRepository.GetAll();
        }
        public async Task<ResponseModel> DeleteUser(int id)
        {
            ResponseModel response = new ResponseModel();
            var userlist = await _courseRepository.GetById(id);
            if (userlist.Count == 0)
            {
                response.Code = -1;
                response.Message = "не успешно";
                return response;
            }
            else
            {
                _courseRepository.Delete(id);
                response.Code = 1;
                response.Message = "Успешно";
                return response;
            }


        }
    }
}
