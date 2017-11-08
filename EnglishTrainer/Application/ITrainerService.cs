using EnglishTrainer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Application
{
    public interface ITrainerService
    {
        void SaveMemoryWordRepository(IWordRepository wordRepository);
        void SaveMemoryUserRepository(IUserRepository userRepository);
    }
}
