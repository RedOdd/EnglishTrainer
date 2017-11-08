using System;
using EnglishTrainer.Application;
using EnglishTrainer.Domain;
using EnglishTrainer.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Application
{
    public class TrainerService : ITrainerService
    {
        public void SaveMemoryUserRepository(IUserRepository userRepository)
        {
            userRepository.SaveAllUsers();
        }

        public void SaveMemoryWordRepository(IWordRepository wordRepository)
        {
            wordRepository.SaveAllWords();
        }
    }
}
