using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ByteCuisine.Tests
{
    public class DataContextTests
    {
        private DbContextOptions<DataContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ByteCuisine")
                .Options;
        }

        [Test]
        public void Can_Insert_And_Retrieve_Account()
        {
            
            using (var context = new DataContext(_options))
            {
                var account = new Account { 
                    Username = "testuser", 
                    Password = "example",
                    Role = "User",
                    Email = "test@example.com",
                    PictureData = Convert.FromBase64String("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"),
                    IsDeleted = false,
                };

                
                context.Accounts.Add(account);
                context.SaveChanges();
            }

            
            using (var context = new DataContext(_options))
            {
                var retrievedAccount = context.Accounts.Find(1);
                Assert.That("testuser".Equals(retrievedAccount.Username));
                Assert.That("example".Equals(retrievedAccount.Password));
                Assert.That("User".Equals(retrievedAccount.Role));
                Assert.That(retrievedAccount.PictureData.Any());
                Assert.That("test@example.com".Equals( retrievedAccount.Email));
                Assert.That(false.Equals(retrievedAccount.IsDeleted));
            }
        }

        [Test]
        public void Can_Insert_And_Retrieve_Logs()
        {

            using (var context = new DataContext(_options))
            {
                var log = new Log
                {
                    ActivityName = "Logowanie",
                    ActivityTime = DateTime.UtcNow,
                    AccountId = 1,
                };


                context.Logs.Add(log);
                context.SaveChanges();
            }


            using (var context = new DataContext(_options))
            {
                var retrievedLogs = context.Logs.Find(1);
                Assert.That("Logowanie".Equals(retrievedLogs.ActivityName));
                Assert.That(1.Equals(retrievedLogs.AccountId));
            }
        }
    }
}


