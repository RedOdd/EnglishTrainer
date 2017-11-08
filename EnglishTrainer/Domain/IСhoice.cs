using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Domain
{
    public interface IСhoice
    {
        bool CheckTheCorrectTranslation(IList<Word> twoWords);
        IList<Word> GetTwoWord(User user);
    }
}
