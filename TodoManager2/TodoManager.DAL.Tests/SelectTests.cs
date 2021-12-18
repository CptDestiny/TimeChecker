using TodoManager.BL.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TodoManager.DAL.Tests
{
    [TestFixture]
    public class SelectTests
    {
        private AppDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoListManager;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options);
        }

        [Test]
        public void GetAllTodoItems()
        {
            IEnumerable<TodoItem> todoItems = _context.TodoItems.ToList();
            Assert.AreEqual(2, todoItems.Count());
        }
    }
}
