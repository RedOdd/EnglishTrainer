using System;
using EnglishTrainer.Domain;

namespace EnglishTrainer.Application
{
    public class UserService : IUserService
    {
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Guid RegisterUser(string nickname)
        {

            var userId = Guid.NewGuid();
            var user = new User(userId, nickname);
            
           if (_userRepository.LoadUserGuid(nickname) == Guid.Empty)
            {
                _userRepository.SaveUser(user);
                
                return userId;
            } else
            {
               return _userRepository.LoadUserGuid(nickname);
            }
            
            
        }

        public User LogIn(string nickname)
        {
            if (!(_userRepository.LoadUser(_userRepository.LoadUserGuid(nickname)) == null))
            {
                return _userRepository.LoadUser(_userRepository.LoadUserGuid(nickname));
            }
            throw new Exception();
        }


        private readonly IUserRepository _userRepository;
    }
}
