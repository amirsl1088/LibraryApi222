using LibraryApi22.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static LibraryNewApi.Controllers.BooksController;

namespace LibraryApi22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BookServise Servise = new BookServise();
        [HttpPost("add")]
        public int AddBook([FromBody] AddBookDto dto)
        {
            return Servise.AddBook(dto);
        }
        [HttpPut("update/{id}")]
        public void UpdateBooks([FromRoute]int id,UpdateBooksDto dto)
        {
            Servise.UpdateBook(id, dto);
        }
        [HttpDelete("delete-book/{id}")]
        public void DeleteBook([FromRoute]int id)
        {
            Servise.DeleteBook(id);
        }
        [HttpGet("get-books")]
        public List<GetBookDto> GetBooks([FromQuery]string bookname=null)
        {
            return Servise.GetBooks(bookname);
        }
        [HttpPatch("rent-books")]
        public void RentBook([FromQuery]int userid, [FromQuery]int bookid)
        {
            Servise.RentBook(userid, bookid);
        }
    }
}
