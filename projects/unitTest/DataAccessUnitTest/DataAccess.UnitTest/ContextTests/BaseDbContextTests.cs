using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitTest.ContextTests;

[TestFixture]
public class BaseDbContextTests
{
    private BaseDbContext _context;
    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<BaseDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;

        var configuration = new ConfigurationBuilder().Build();

        _context = new BaseDbContext(options, configuration);
        _context.Database.EnsureCreated();
    }
    [Test]
    public void TestDatabaseCreation()
    {
        // Test the creation of tables
        Assert.DoesNotThrow(() => _context.Books.ToList());
        Assert.DoesNotThrow(() => _context.Categories.ToList());
        Assert.DoesNotThrow(() => _context.Authors.ToList());
    }
    [Test]
    public void TestAddAndRetrieveBook()
    {
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Name = "Test Book",
            Price = 100,
            Stock = 10,
            Description = "Test Description",
            ImageUrl = "Test ImageUrl",
            CategoryId = Guid.NewGuid(),
            AuthorId = Guid.NewGuid()
        };

        _context.Books.Add(book);
        _context.SaveChanges();

        var retrievedBook = _context.Books.Find(book.Id);
        Assert.IsNotNull(retrievedBook);
        Assert.AreEqual(book.Name, retrievedBook.Name);
    }

    [Test]
    public void TestSeedData()
    {
        var category = _context.Categories.FirstOrDefault(c => c.Name == "Roman");
        Assert.IsNotNull(category);

        var author = _context.Authors.FirstOrDefault(a => a.FirstName == "John" && a.LastName == "Verdon");
        Assert.IsNotNull(author);

        var book = _context.Books.FirstOrDefault(b => b.Name == "Aklından Bir Sayı Tut");
        Assert.IsNotNull(book);

        var appUser = _context.AppUsers.FirstOrDefault(u => u.Username == "berkay");
        Assert.IsNotNull(appUser);
    }
    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }
}
