using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishTrainer.Application;
using EnglishTrainer.Domain;
using System.IO;
using Newtonsoft.Json;

namespace EnglishTrainer.Infrastructure
{
    public class InMemoryWordRepository : IWordRepository
    {
        private readonly Dictionary<Guid, Word> _words = new Dictionary<Guid, Word>();
        public InMemoryWordRepository()
        {
            _words = new Dictionary<Guid, Word>();
            FileStream file = new FileStream("BaseOfWords.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(file);
            var baseOfWordsText = streamReader.ReadToEnd();
            streamReader.Close();
            if (!(baseOfWordsText.Equals("")))
            {
                _words = JsonConvert.DeserializeObject<Dictionary<Guid, Word>>(baseOfWordsText);
            }
        }

        public Word LoadWord(Guid wordId)
        {
            if (!_words.ContainsKey(wordId))
            {
                throw new Exception();
            }

            return _words[wordId];
        }

        public Guid[] GetGuidArray()
        {
            IList<Guid> guidList = new List<Guid>(); 
            foreach (var _wordsTemp in _words)
            {
                guidList.Add(_wordsTemp.Key);
            }

            return guidList.ToArray<Guid>();
        }

        public void SaveAllWords()
        {
            FileStream file = new FileStream("BaseOfWords.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamwriter = new StreamWriter(file);

            streamwriter.WriteLine(JsonConvert.SerializeObject(_words));
            streamwriter.Close();
        }
    }
}
