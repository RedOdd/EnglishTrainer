using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Domain
{
    public class WordInList
    {
        public WordInList(Guid wordInListId)
        {
            WordInListId = wordInListId;
            CountOfTrueAnswers = 0;
        }

        public void IncrementCountOfTrueAnswers()
        {
            CountOfTrueAnswers++;
        }

        public Guid WordInListId;
        public int CountOfTrueAnswers;
    }
}
