using System;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Infrastructure;

namespace EnglishTrainer.Domain
{
    public class Сhoice : IСhoice
    {
        IWordRepository _wordRepository;
        public Сhoice()
        {
            _wordRepository = new InMemoryWordRepository();
        }

        public IList<Word> GetTwoWord(User user)
        {
            var wordsUnexamined = user.WordsListForUser._wordsInList.Where(wordInList => wordInList.Value.CountOfTrueAnswers < 3).ToList();
            var rand = new Random();
            IList<Word> twoWords = new List<Word>();
            if (wordsUnexamined.Count == 0)
            {
                throw new Exception();
            }
            twoWords.Add(_wordRepository.LoadWord(wordsUnexamined[rand.Next(wordsUnexamined.Count())].Key));
            twoWords.Add(_wordRepository.LoadWord(wordsUnexamined[rand.Next(wordsUnexamined.Count())].Key));
            return twoWords;
        }

        public bool CheckTheCorrectTranslation(IList<Word> twoWords)
        {
            if (twoWords[0].WordInEnglish == twoWords[1].WordInEnglish)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
