using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnglishTrainer.Application;
using EnglishTrainer.Infrastructure;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void RegisterUser_UserAddToList()
        {
            InMemoryUserRepository userRepository = new InMemoryUserRepository();
            UserService userService = new UserService(userRepository);
                Assert.AreNotEqual(userRepository.LoadUser(userService.RegisterUser("Test1")), null);
        }

        [TestMethod]
        public void UserRegister_WordsAddedToWordsListForUser()
        {
            InMemoryUserRepository userRepository = new InMemoryUserRepository();
            UserService userService = new UserService(userRepository);
            Assert.IsTrue(userRepository.LoadUser(userService.RegisterUser("Test2")).GetWordsListForUser()._wordsInList.FirstOrDefault().Value.CountOfTrueAnswers.ToString().Equals("0"));
        }

        [TestMethod]
        public void UserRegister_UserRepositorySave()
        {
            TrainerService trainerService = new TrainerService();

            InMemoryUserRepository userRepositoryFirst = new InMemoryUserRepository();
            UserService userServiceFirst = new UserService(userRepositoryFirst);
            userServiceFirst.RegisterUser("Test3");
            trainerService.SaveMemoryUserRepository(userRepositoryFirst);

            InMemoryUserRepository userRepositorySecound = new InMemoryUserRepository();
            UserService userServiceSecound = new UserService(userRepositorySecound);
            Assert.AreNotEqual(userServiceSecound.LogIn("Test3"), null);

        }

        [TestMethod]
        public void EqualWords_CheckShouldBeTrue()
        {
            InMemoryUserRepository userRepository = new InMemoryUserRepository();
            UserService userService = new UserService(userRepository);
            userService.RegisterUser("Test4");

            ExamineService examineService = new ExamineService(userService.LogIn("Test4"), new InMemoryWordRepository());
            var twoWords = examineService.GetTwoWords();
            twoWords[1].WordInEnglish = twoWords[0].WordInEnglish;
            Assert.IsTrue(examineService.Check(true, twoWords));
        }

        [TestMethod]
        public void NotEqualWords_CheckShouldBeTrue()
        {
            InMemoryUserRepository userRepository = new InMemoryUserRepository();
            UserService userService = new UserService(userRepository);
            userService.RegisterUser("Test5");

            ExamineService examineService = new ExamineService(userService.LogIn("Test5"), new InMemoryWordRepository());
            //IList<Word> twoWords = new List<Word>(2);
            var twoWords = examineService.GetTwoWords();
            while (twoWords[0].WordInEnglish == twoWords[1].WordInEnglish)
            {
                twoWords = examineService.GetTwoWords();
            }
            twoWords[1].WordInEnglish = "1";
            Assert.IsTrue(examineService.Check(false, twoWords));
        }

        [TestMethod]
        public void EqualWords_CountAnswerShouldBeIncremented()
        {
            InMemoryUserRepository userRepository = new InMemoryUserRepository();
            UserService userService = new UserService(userRepository);
            userService.RegisterUser("Test6");

            ExamineService examineService = new ExamineService(userService.LogIn("Test6"), new InMemoryWordRepository());
            var twoWords = examineService.GetTwoWords();
            twoWords[1].WordInEnglish = twoWords[0].WordInEnglish;
            Guid guidWord = twoWords[0].WordId;
            examineService.Check(true, twoWords);
            Assert.IsTrue(userRepository.LoadUser(userService.LogIn("Test6").Id).WordsListForUser._wordsInList[guidWord].CountOfTrueAnswers == 1);

        }

        [TestMethod]
        public void ExaminedWords_CountWordListShouldBeEqualZero()
        {
            InMemoryUserRepository userRepository = new InMemoryUserRepository();
            UserService userService = new UserService(userRepository);
            userService.RegisterUser("Test7");
            ViewerService viewerService = new ViewerService(userService.LogIn("Test7"), new InMemoryWordRepository());
            var wordsListExamined = viewerService.ViewExaminedWords();
            Assert.IsTrue(wordsListExamined.Count == 0);
        }
        
        [TestMethod]
        public void UnexaminedWords_CountWordListShouldBeEqualFive()
        {
            InMemoryUserRepository userRepository = new InMemoryUserRepository();
            UserService userService = new UserService(userRepository);
            userService.RegisterUser("Test8");
            ViewerService viewerService = new ViewerService(userService.LogIn("Test8"), new InMemoryWordRepository());
            var wordsListUnexamined = viewerService.ViewUnexaminedWords();
            Assert.IsTrue(wordsListUnexamined.Count == 5);
        }

        [ExpectedException(typeof(Exception)),TestMethod]
        public void AllWorldsTrue_ShouldBeExeption()
        {
            InMemoryUserRepository userRepository = new InMemoryUserRepository();
            UserService userService = new UserService(userRepository);
            userService.RegisterUser("Test6");

            ExamineService examineService = new ExamineService(userService.LogIn("Test6"), new InMemoryWordRepository());
            var twoWords = examineService.GetTwoWords();

            for (var wordCount = 0; wordCount < 5; wordCount++)
            {
                for (var count = 0; count < 3; count++)
                {
                    twoWords[1].WordInEnglish = twoWords[0].WordInEnglish;
                    Guid guidWord = twoWords[0].WordId;
                    examineService.Check(true, twoWords);
                }
                twoWords = examineService.GetTwoWords();
            }
            twoWords = examineService.GetTwoWords();
        }
    }
}
