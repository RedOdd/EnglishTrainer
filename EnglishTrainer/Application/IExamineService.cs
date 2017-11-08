using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishTrainer.Domain;

namespace EnglishTrainer.Application
{
    public interface IExamineService
    {
        IList<Word> GetTwoWords();
        bool Check(bool answer, IList<Word> twoWords);
    }
}
