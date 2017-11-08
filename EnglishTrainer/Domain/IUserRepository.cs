using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Domain
{
    public interface IUserRepository
    {
        User LoadUser(Guid userId);
        void SaveUser(User user);
        //User LoadUser(string nickname);
        void SaveAllUsers();
        Guid LoadUserGuid(string nickname);
    }
}
