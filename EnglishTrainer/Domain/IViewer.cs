using System.Collections.Generic;

namespace EnglishTrainer.Domain
{
    public interface IViewer
    {
        IList<Word> ViewExaminedWords(User user);
        IList<Word> ViewUnexaminedWords(User user);
    }
}
