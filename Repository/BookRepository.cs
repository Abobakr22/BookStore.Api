using BookStore.Api.Data;
using BookStore.Api.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }


        //implementing task for getting all records from db
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();

            return records;
        }

        //implementing task for getting one record from db
        public async Task<BookModel> GetBookByIdAsync(int BookId)
        {
            var record = await _context.Books.Where(x => x.Id == BookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return record;
        }

        //implementing task for adding a new record to db
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Book()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        //implementing task for updating an existing book in db
        public async Task UpdateBookAsync(int BookId, BookModel bookModel)
        {
            //using this way for hitting database only one time
            var book = new Book()
            {
                Id = BookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            //by using this traditional way you will hit database 2 times
            //var book = await _context.Books.FindAsync(BookId);
            //if (book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;

            //    await _context.SaveChangesAsync();
            //}

        }
    }
}
