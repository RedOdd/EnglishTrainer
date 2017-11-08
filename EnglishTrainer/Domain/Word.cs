using System;

namespace EnglishTrainer.Domain
{
    public class Word
    {
        public Word(Guid wordId, string wordInEnglish, string wordInRussian)
        {
            WordId = wordId;
            WordInEnglish = wordInEnglish;
            WordInRussian = wordInRussian;
        }
        public Guid WordId { get; }
        public string WordInEnglish { get; set; }
        public string WordInRussian { get; }
    }
}
