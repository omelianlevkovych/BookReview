using BookReview.Controllers;
using BusinessLogic.Logic.Interfaces;
using BusinessLogic.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookReview.Tests.ControllerTests
{
    public class BooksControllerTests
    {
        [Fact]
        public async Task GetBooks_returns_books()
        {
            // Arrange.
            var logicMock = new Mock<IBooksLogic>();

            var books = new List<BookModel>
            {
                new BookModel
                {
                    Id = 1,
                },
                new BookModel 
                { 
                    Id = 2 
                },
            };

            logicMock.Setup(x => x.GetAll())
                .ReturnsAsync(books);

            var controller = new BooksController(logicMock.Object);

            // Act.
            var result = await controller.GetBooks();

            // Assert.
            Assert.IsAssignableFrom<IEnumerable<BookModel>>(result);
            Assert.Equal(2, result.Count());
        }

    }
}
