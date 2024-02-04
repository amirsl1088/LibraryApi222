using LibraryApi22.Models;
using Microsoft.AspNetCore.Mvc;
using static LibraryNewApi.Controllers.BooksController;

namespace LibraryApi22.Services
{
    public class BookServise
    {
        public static List<Book> Books = new();
        UserService Service = new UserService();
        public int AddBook(AddBookDto dto)
        {
            var book = new Book
            {
                Name = dto.Name,
                GenreId = dto.GenreId,
                WriterId = dto.WriterId,
                Stock = dto.Stock

            };
            Books.Add(book);
            return book.Id;
        }
        public void UpdateBook(int id,UpdateBooksDto dto)
        {
            var book = Books.Where(_ => _.Id == id).First();
            Books.Remove(book);

            book.Name = dto.Name;
            book.GenreId = dto.GenreId;
            book.WriterId = dto.WriterId;
            book.Stock = dto.Stock;
            Books.Add(book);
        }
        public void DeleteBook(int id)
        {
            var book = Books.First(_ => _.Id == id);
            Books.Remove(book);
        }
        public List<GetBookDto> GetBooks([FromQuery] string bookname = null)
        {
            var books = Books
                .Select(_ => new GetBookDto
                {
                    Name = _.Name,
                    Id = _.Id,
                    GenreId = _.GenreId,
                    WriterId = _.WriterId,
                    Stock = _.Stock

                })
                .ToList();
            if (bookname != null)
            {
                books = books.Where(_ => _.Name == bookname).ToList();
                return books;
            }

            return books;

        }
        public void RentBook(int userid,int bookid)
        {
            var user = Service.Users.FirstOrDefault(_ => _.Id == userid);
            if (user == null)
            {
                throw new Exception("user not found");
            }
            var book = Books.FirstOrDefault(_ => _.Id == bookid);
            if (book == null)
            {
                throw new Exception("book not found");
            }
            if (user.Books.Count > 4)
            {
                throw new Exception("full of books");
            }
            book.Stock -= 1;
            user.Books.Add(book);
        }
    }
}
