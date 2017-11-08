using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishTrainer.Application;
using EnglishTrainer.Domain;
using System.IO;
using Newtonsoft.Json;
using System.Collections;

namespace EnglishTrainer.Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        public InMemoryUserRepository()
        {
            _users =  new Dictionary<Guid, User>();
            FileStream file = new FileStream("BaseOfUsers.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(file);
            var baseOfUsersText = streamReader.ReadToEnd();
            streamReader.Close();
            if (!(baseOfUsersText.Equals("")))
            {
                _users = JsonConvert.DeserializeObject<Dictionary<Guid, User>>(baseOfUsersText);
            }
        }

        public User LoadUser(Guid userId)
        {
            if (!_users.ContainsKey(userId))
            {
                throw new Exception();
            }
            return _users[userId];
        }

        public Guid LoadUserGuid(string nickname)
        {
           
            if (_users.Count(user => user.Value.Nickname == nickname) == 0)
            {
                return Guid.Empty;
            }
            else
            {
                return _users[_users.SingleOrDefault(user => user.Value.Nickname == nickname).Key].Id;
            }


        }

        public void SaveUser(User user)
        {
            _users[user.Id] = user;
        }

        public void SaveAllUsers()
        {
            FileStream file = new FileStream("BaseOfUsers.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamwriter = new StreamWriter(file);

            streamwriter.WriteLine(JsonConvert.SerializeObject(_users));
            streamwriter.Close();
        }

        private readonly Dictionary<Guid, User> _users = new Dictionary<Guid, User>();
    }
}
