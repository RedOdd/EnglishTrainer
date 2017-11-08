using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Domain
{
    public interface IWordRepository
    {
        Word LoadWord(Guid wordId);
        Guid[] GetGuidArray();
        void SaveAllWords();
    }
}
