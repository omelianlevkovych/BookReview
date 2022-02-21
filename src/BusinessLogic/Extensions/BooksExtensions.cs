using BusinessLogic.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Extensions
{
    public static class BooksExtensions
    {
        public static BookModel ToModel(this BookEntity bookEntities)
        {
            return new BookModel
                {
                    Id = bookEntities.Id,
                    Name = bookEntities.Name,
                };
        }

        public static IEnumerable<BookModel> ToModel(this IEnumerable<BookEntity> bookEntities)
        {
            // TODO: this seems to be wrong.
            var result = new List<BookModel>();

            foreach (var book in bookEntities)
            {
                result.Add(book.ToModel());
            }
            return result;
        }
    }
}
