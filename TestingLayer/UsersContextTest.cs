using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;

namespace TestingLayer
{
    [TestFixture]
    class UsersContextTest
    {
        private UsersContext context = new UsersContext(SetupFixture.dbContext);
        private User user;
        private Interest i1, i2;
        

        [SetUp]
        public void CreateUser()
        {
            user = new User("Emre", "Shakir", 18, "EmreShakir", "12345", "emreshakir@abv.bg");
            i1 = new Interest("Football");
            i2 = new Interest("Tennis");

            user.Interests.Add(i1);
            user.Interests.Add(i2);

            context.Create(user);
        }
        [TearDown]
        public void DropUser()
        {
            foreach (User item in SetupFixture.dbContext.Users)
            {
                SetupFixture.dbContext.Users.Remove(item);
            }

            SetupFixture.dbContext.SaveChanges();
        }

        [Test]
        public void Create()
        {
            
            User newUser = new User("Emre","Shakir",18,"EmreShakir","12345","emreshakir@abv.bg");

           
            int usersBefore = SetupFixture.dbContext.Users.Count();
            context.Create(newUser);

            
            int usersAfter = SetupFixture.dbContext.Users.Count();
            Assert.IsTrue(usersBefore + 1 == usersAfter, "Create() does not work");
        }
        [Test]
        public void Read()
        {
            User readUser = context.Read(user.Id);

            Assert.AreEqual(user, readUser, "Read does not return the same object");
        }

        [Test]
        public void ReadWithNavigationalProperties()
        {
            User readUser = context.Read(user.Id, true);

            Assert.That(readUser.Interests.Contains(i1) && readUser.Interests.Contains(i2), "i1 and i2 is not in the Products list);
            
        }

        [Test]
        public void ReadAll()
        {
            List<User> users = (List<User>)context.ReadAll();

            Assert.That(users.Count != 0, "ReadAll() does not return users);
        }

        [Test]
        public void Update()
        {
            User changedUser = context.Read(user.Id);

            changedUser.Username = "Updated " + user.Username;
            changedUser.Email = "emreshakir@gmail.com";

            context.Update(changedUser);

            user = context.Read(user.Id);

            Assert.AreEqual(changedUser, user, "Update() does not work");
        }

        [Test]
        public void Delete()
        {
            int usersBefore = SetupFixture.dbContext.Users.Count();

            context.Delete(user.Id);
            int usersAfter = SetupFixture.dbContext.Users.Count();

            Assert.IsTrue(usersBefore - 1 == usersAfter, "Delete() does not work);
        }
    }
}
