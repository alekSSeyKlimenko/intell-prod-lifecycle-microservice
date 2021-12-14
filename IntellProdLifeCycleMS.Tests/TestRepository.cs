using System;
using System.Threading;
using System.Threading.Tasks;
using IntellProdLifeCycleMS.Domain.Models;
using Xunit;

namespace IntellProdLifeCycleMS.Tests
{
    public class TestRepository
    {
        [Fact]
        public void GetAll()
        {
            var testHelper = new UnitTestHelper();
            var repository = testHelper.IPRepository;

            Assert.True(repository.GetByIdAll<Book>().Result.Count == 0);

            Book book = new Book { Id = 1, Title = "Nic", Subtitle = "123", Type = "123", DOI = "123", Year = "123", Country = "123", City = "123", GRINTI = "123", Status = "123", Description = "123", Organization = "123", Level = 1 };
            _ = repository.Add<Book>(book);
            Book book2 = new Book { Id = 2, Title = "Nic", Subtitle = "123", Type = "123", DOI = "123", Year = "123", Country = "123", City = "123", GRINTI = "123", Status = "123", Description = "123", Organization = "123", Level = 1 };
            _ = repository.Add<Book>(book2);

            Assert.True(repository.GetByIdAll<Book>().Result.Count == 2);

        }

        [Fact]
        public void GetById()
        {
            var testHelper = new UnitTestHelper();
            var repository = testHelper.IPRepository;

            Book book = new Book { Id = 101, Title = "Nic", Subtitle = "123", Type = "123", DOI = "123", Year = "123", Country = "123", City = "123", GRINTI = "123", Status = "123", Description = "123", Organization = "123", Level = 1 };
            _ = repository.Add<Book>(book);

            Assert.Equal(101, repository.GetById<Book>(101).Result.Id);
        }


        [Fact]
        public void TestAdd()
        {
            var testHelper = new UnitTestHelper();
            var repository = testHelper.IPRepository;

            Book book = new Book { Id = 1, Title = "Nic",Subtitle = "123",Type = "123",DOI = "123",Year = "123",Country = "123",City = "123",GRINTI = "123",Status = "123",Description = "123",Organization = "123",Level =1 };
            _ = repository.Add<Book>(book);

            Assert.Equal(1, repository.GetById<Book>(1).Result.Id);
            Assert.True(repository.GetByIdAll<Book>().Result.Count == 1);
            Assert.Equal("Nic", repository.GetById<Book>(1).Result.Title);
        }

        [Fact]
        public void TestUpdate()
        {
            var testHelper = new UnitTestHelper();
            var repository = testHelper.IPRepository;

            Book book = new Book { Id = 1, Title = "Nic", Subtitle = "123", Type = "123", DOI = "123", Year = "123", Country = "123", City = "123", GRINTI = "123", Status = "123", Description = "123", Organization = "123", Level = 1 };
            _ = repository.Add<Book>(book);

            Task.Delay(20000);
            Book newBook = new Book { Id = 1, Title = "new", Subtitle = "123", Type = "123", DOI = "123", Year = "123", Country = "123", City = "123", GRINTI = "123", Status = "123", Description = "123", Organization = "123", Level = 1, Indexations = null,Authors= null, EducationalPrograms = null, Edition = "123", KeyWords = null, PageCount = 1, Publisher = "123", UDK = "123"};

            _ = repository.Update<Book>(newBook);
            Task.Delay(20000);
            Assert.Equal("new", repository.GetById<Book>(1).Result.Title);
        }

        [Fact]
        public void TestDelete()
        {
            var testHelper = new UnitTestHelper();
            var repository = testHelper.IPRepository;

            Book book = new Book { Id = 1, Title = "Nic", Subtitle = "123", Type = "123", DOI = "123", Year = "123", Country = "123", City = "123", GRINTI = "123", Status = "123", Description = "123", Organization = "123", Level = 1 };
            _ = repository.Add<Book>(book);

            _ = repository.Delete<Book>(book);

            Assert.True(repository.GetByIdAll<Book>().Result.Count == 0);
        }
    }
}
