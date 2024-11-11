using TechnoHub.Model;
using TechnoHub.Repositories;
using TechnoHub.Validators;

namespace TechnoHub.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserValidator _userValidator;

        public UserService(UserRepository userRepository, UserValidator userValidator) 
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<ResponseModel> CreateUser(UserModel user)
        {
            int id = 0;
            ResponseModel response = new ResponseModel();

            var validationResult = await _userValidator.ValidateAsync(user);

            if(!validationResult.IsValid)
            {
                foreach(var error in validationResult.Errors)
                {
                    response.Code = StatusCodes.Status400BadRequest;
                    response.Message = error.ToString();
                    response.UserId = id;
                    return response;
                }
            }
            
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
