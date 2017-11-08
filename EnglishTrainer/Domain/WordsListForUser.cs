using System;
using System.Collections.Generic;
using EnglishTrainer.Infrastructure;

namespace EnglishTrainer.Domain
{
    public class WordsListForUser : IWordListForUserRepository
    {
        public WordsListForUser(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
            _wordRepository = new InMemoryWordRepository();
            Guid[] guidArray = _wordRepository.GetGuidArray();
            
            for (int count = 0; count < guidArray.Length; count++)
            {
                _wordsInList.Add(guidArray[count], new WordInList(guidArray[count]));
            }
        }

        public Word GetWord(Guid wordGuid)
        {
            return _wordRepository.LoadWord(wordGuid);
        }

        public WordInList GetWordInList(Guid wordGuid)
        {
            return _wordsInList[wordGuid];
        }

        public Dictionary<Guid, WordInList> _wordsInList = new Dictionary<Guid, WordInList>();
        private readonly IWordRepository _wordRepository;
    }
}
