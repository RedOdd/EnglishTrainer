using EnglishTrainer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Application
{
    public class ViewerService : IViewerService
    {
        public static IWordRepository _wordRepository;
        public User User;
        Viewer Viewer = new Viewer();

        public ViewerService(User user, IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
            User = user;
        }

        public IList<Word> ViewExaminedWords()
        {
            return Viewer.ViewExaminedWords(User);
        }

        public IList<Word> ViewUnexaminedWords()
        {
            return Viewer.ViewUnexaminedWords(User);
        }
    }
}
