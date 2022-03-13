using BookReview.Controllers;
using BusinessLogic.Logic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookReview.Tests.ControllerTests
{
    public class BooksControllerTests
    {
        private readonly Mock<IBooksLogic> booksLogicMock;
        private readonly Mock<ILogger> loggerMock;
        private readonly BooksController controller;

        public BooksControllerTests()
        {
            booksLogicMock = new Mock<IBooksLogic>();
            loggerMock = new Mock<ILogger>();
            controller = new BooksController(
                booksLogicMock.Object,
                loggerMock.Object);
        }

        [Fact]
        public async Task GetBooks_returns_books()
        {
            // Arrange.
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

            booksLogicMock.Setup(x => x.GetAll())
                .ReturnsAsync(books);

            // Act.
            var result = await controller.GetBooks();

            // Assert.
            Assert.IsAssignableFrom<IEnumerable<BookModel>>(result);
            Assert.Equal(2, result.Count());
            booksLogicMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetBook_returns_book()
        {
            // Arrange.
            int bookId = 1;
            var book = new BookModel
            {
                Id = bookId,
                Name = "test-name",
            };

            booksLogicMock.Setup(x => x.Get(bookId))
                .ReturnsAsync(book);

            // Act.
            var result = await controller.GetBook(bookId);

            // Assert.
            var actionResult = Assert.IsAssignableFrom<ActionResult<BookModel>>(result);
            var model = Assert.IsType<BookModel>(actionResult.Value);
            Assert.Equal(bookId, model.Id);
            Assert.Equal(book.Name, model.Name);
            booksLogicMock.Verify(x => x.Get(bookId), Times.Once);
        }

        [Fact]
        public async Task GetBooks_returns_not_found_when_no_book()
        {
            // Arrange.
            int bookId = 999;
            // Act.
            var actionResult = await controller.GetBook(bookId);

            // Assert.
            var result = actionResult.Result as NotFoundResult;
            Assert.NotNull(result);
            booksLogicMock.Verify(x => x.Get(bookId), Times.Once);
        }

        [Fact]
        public async Task AddBook_returns_ok()
        {
            // Arrange.
            var book = new BookModel
            {
                Id = 1,
                Name = "test-name",
            };

            booksLogicMock.Setup(x => x.Add(It.IsAny<BookModel>()))
                .Returns(Task.CompletedTask);

            // Act.
            var actionResult = await controller.AddBook(book);
            
            // Assert.
            var result = Assert.IsAssignableFrom<OkResult>(actionResult);
            Assert.NotNull(result);
            booksLogicMock.Verify(x => x.Add(book), Times.Once);
        }

        [Fact]
        public async Task DeleteBook_deletes_book()
        {
            // Arrange.
            int bookId = 1;
            var book = new BookModel
            {
                Id = bookId,
            };

            booksLogicMock.Setup(x => x.Get(bookId))
                .ReturnsAsync(book);
            booksLogicMock.Setup(x => x.Delete(bookId))
                .Returns(Task.CompletedTask);

            // Act.
            var actionResult = await controller.DeleteBook(bookId);

            // Assert.
            var result = Assert.IsAssignableFrom<OkResult>(actionResult);
            Assert.NotNull(result);
            booksLogicMock.Verify(x => x.Get(bookId), Times.Once);
            booksLogicMock.Verify(x => x.Delete(bookId), Times.Once);
        }

        [Fact]
        public async Task DeleteBook_returns_not_found()
        {
            // Arrange.
            int bookId = 1;

            booksLogicMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Returns(Task.CompletedTask);

            // Act.
            var actionResult = await controller.DeleteBook(bookId);

            // Assert.
            var result = Assert.IsAssignableFrom<NotFoundResult>(actionResult);
            Assert.NotNull(result);
            booksLogicMock.Verify(x => x.Get(bookId), Times.Once);
            booksLogicMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task GetSoftDeleted_returns_trashed()
        {
            // Arrange.
            var books = new List<BookModel>
            {
                new BookModel
                {
                    Id = 1,
                },
                new BookModel
                {
                    Id = 2,
                }
            };

            booksLogicMock.Setup(x => x.GetSoftDeleted())
                .ReturnsAsync(books);

            // Act.
            var result = await controller.GetSoftDeleted();

            // Assert.
            Assert.IsAssignableFrom<IEnumerable<BookModel>>(result);
            Assert.Equal(2, result.Count());
            booksLogicMock.Verify(x => x.GetSoftDeleted(), Times.Once);
        }
    }
}
