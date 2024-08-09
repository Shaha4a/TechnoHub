using TechnoHub.Model;
using TechnoHub.Repositories;

namespace TechnoHub.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel> CreateUser(UserModel user)
        {
            int id = 0;
            ResponseModel response= new ResponseModel();
            id = await _userRepository.Create(user);
            if(id != 0) 
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
        public async Task<ResponseModel> UpdateUser(UserModel user)
        {
            ResponseModel response = new ResponseModel();
            var userlist = await _userRepository.GetById((int)user.Id);
            if (userlist.Count == 0)
            {
                response.Code = -1;
                response.Message = "Не успешно";
                return response;
            }else {
                _userRepository.Update(user);
                response.Code = 1;
                response.Message = "Успешно";
                return response;
            }
        }
        public async Task<List<UserModel>> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }
        public async Task<ResponseModel> DeleteUser(int id)
        {
            ResponseModel response = new ResponseModel();
            var userlist = await _userRepository.GetById(id);
            if (userlist.Count == 0)
            {
                response.Code= -1;
                response.Message = "не успешно";
                return response;
            }
            else
            {
                _userRepository.Delete(id);
                response.Code = 1;
                response.Message = "Успешно";
                return response;
            }
            
            
        }
    }
}
