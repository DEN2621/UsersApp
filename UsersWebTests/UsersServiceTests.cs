using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UsersDTO;
using UsersWeb;
using UsersWeb.Services;

namespace UsersWebTests
{
    public class UsersServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void IndexTest()
        {
            UsersService service = UsersServiceTestsHelpers.GetUsersService(new Mock<IUsersConfiguration>(MockBehavior.Strict),
                                              new Mock<IWebRequest>(MockBehavior.Strict),
                                              @"[{""id"": 18,""name"": ""qwe"",""age"": 123,""city"": ""asd"",""email"": ""qwe""}]");
            IEnumerable<UserDTO> users = service.UsersList();
            Assert.Multiple(() =>
            {
                Assert.That(users.Count(), Is.EqualTo(1));
                Assert.That(users.First().Id, Is.EqualTo(18));
                Assert.That(users.First().Name, Is.EqualTo("qwe"));
                Assert.That(users.First().Age, Is.EqualTo(123));
                Assert.That(users.First().City, Is.EqualTo("asd"));
                Assert.That(users.First().Email, Is.EqualTo("qwe"));
            });
            Assert.Pass();
        }
        [Test]
        [TestCase(18)]
        public void DetailsTest(int id)
        {
            UsersService service = UsersServiceTestsHelpers.GetUsersService(new Mock<IUsersConfiguration>(MockBehavior.Strict),
                                  new Mock<IWebRequest>(MockBehavior.Strict),
                                  @"{""id"": 18,""name"": ""qwe"",""age"": 123,""city"": ""asd"",""email"": ""qwe""}");
            UserDTO user = service.Details(id);
            Assert.Multiple(() =>
            {
                Assert.That(user.Id, Is.EqualTo(18));
                Assert.That(user.Name, Is.EqualTo("qwe"));
                Assert.That(user.Age, Is.EqualTo(123));
                Assert.That(user.City, Is.EqualTo("asd"));
                Assert.That(user.Email, Is.EqualTo("qwe"));
            });
            Assert.Pass();
        }
        [Test]
        [TestCase("Test", 5325, "Test", "test@test.test")]
        public void CreateTest(string name, int age, string city, string email)
        {
            using (CopyingMemoryStream stream = new())
            {
                UsersService service = UsersServiceTestsHelpers.GetUsersService(new Mock<IUsersConfiguration>(MockBehavior.Strict),
                                                       new Mock<IWebRequest>(MockBehavior.Strict),
                                                       It.IsAny<string>(),
                                                       stream);
                UserDTO user = new()
                {
                    Name = name,
                    Age = age,
                    City = city,
                    Email = email
                };
                service.Create(user);
                Assert.That(stream.Written, Is.EqualTo(JsonConvert.SerializeObject(user)));
            }
            Assert.Pass();
        }
        [Test]
        [TestCase("Test", 5325, "Test", "test@test.test")]
        public void EditTest(string name, int age, string city, string email)
        {
            using (CopyingMemoryStream stream = new())
            {
                UsersService service = UsersServiceTestsHelpers.GetUsersService(new Mock<IUsersConfiguration>(MockBehavior.Strict),
                                                       new Mock<IWebRequest>(MockBehavior.Strict),
                                                       It.IsAny<string>(),
                                                       stream);
                UserDTO user = new()
                {
                    Name = name,
                    Age = age,
                    City = city,
                    Email = email
                };
                service.Edit(user);
                Assert.That(stream.Written, Is.EqualTo(JsonConvert.SerializeObject(user)));
            }
            Assert.Pass();
        }
        [Test]
        [TestCase(21)]
        public void DeleteTest(int id)
        {
            UsersService service = UsersServiceTestsHelpers.GetUsersService(new Mock<IUsersConfiguration>(MockBehavior.Strict),
                                                   new Mock<IWebRequest>(MockBehavior.Strict),
                                                   It.IsAny<string>());
            service.Delete(id);
            Assert.Pass();
        }
    }
}
