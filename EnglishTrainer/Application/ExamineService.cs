using EnglishTrainer.Domain;
using System.Collections.Generic;

namespace EnglishTrainer.Application
{
    public class ExamineService : IExamineService
    {
        public static IWordRepository _wordRepository;
        public User User;
        Сhoice Choice = new Сhoice();

        public ExamineService(User user, IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
            User = user;
        }
        
        public IList<Word> GetTwoWords()
        {
            return Choice.GetTwoWord(User);
        }

        public bool Check(bool answer, IList<Word> twoWords)
        {
            if( answer == Choice.CheckTheCorrectTranslation(twoWords))
            {
                User.WordsListForUser.GetWordInList(twoWords[0].WordId).IncrementCountOfTrueAnswers();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
