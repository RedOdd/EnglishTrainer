using EnglishTrainer.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer.Domain
{
    public class Viewer : IViewer
    {
        IWordRepository _wordRepository;
        public Viewer()
        {
            _wordRepository = new InMemoryWordRepository();
        }

        public IList<Word> ViewExaminedWords(User user)
        {
            var wordsInList =  user.WordsListForUser._wordsInList.Where(word => word.Value.CountOfTrueAnswers >= 3).ToList();
            IList < Word > words = new List<Word>();
            foreach (var wordInListTemp in wordsInList)
            {
                words.Add(_wordRepository.LoadWord(wordInListTemp.Key));
            }
            return words;
        }

        public IList<Word> ViewUnexaminedWords(User user)
        {
            var wordsInList = user.WordsListForUser._wordsInList.Where(word => word.Value.CountOfTrueAnswers < 3).ToList();
            IList<Word> words = new List<Word>();
            foreach (var wordInListTemp in wordsInList)
            {
                words.Add(_wordRepository.LoadWord(wordInListTemp.Key));
            }
            return words;
        }
    }
}
