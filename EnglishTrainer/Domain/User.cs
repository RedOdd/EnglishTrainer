using EnglishTrainer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Domain
{
    public class User
    {
        public User(Guid id, string nickname)
        {
            Id = id;
            Nickname = nickname;
            WordsListForUser = new WordsListForUser(new InMemoryWordRepository());
        }

        public WordsListForUser GetWordsListForUser()
        {
            return WordsListForUser;
        }
        public WordsListForUser WordsListForUser;
        public Guid Id { get; }
        public string Nickname { get; }
    }
}
