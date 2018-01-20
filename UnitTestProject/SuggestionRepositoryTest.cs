using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace DomainModelTests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void GetTest()
        {
            SuggestionRepository r = new SuggestionRepository();
            Suggestion x = new Suggestion();
            //x.Id = 1; само добавиться))
            x.Subject = "СУКААААААА";
            x.Date = new DateTime(2015, 7, 20);//обязательное поле по бд
            //Arrange
            
            r.Create(x);
            r.Save();
            //Act
            var result = r.GetSuggestionList();
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Suggestion>));
            r.Delete(x.Id);
            r.Save();
        }
        [TestMethod]
        public void CreateTest()
        {
            SuggestionRepository r = new SuggestionRepository();
            //Arrange
            Suggestion x = new Suggestion();
            //Act
            x.Subject = "СУКААААААА";
            x.Date = new DateTime(2015, 7, 20);//обязательное поле по бд
            r.Create(x);
            r.Save();
            //Assert
            var get = r.GetSuggestionList();
            Suggestion sub = get.FirstOrDefault(equal => equal.Subject == "СУКААААААА");
            Assert.AreEqual("СУКААААААА", sub.Subject);
            r.Delete(x.Id);
            r.Save();

        }
    }
}
