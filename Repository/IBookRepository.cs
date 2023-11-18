using BookStore.Api.Models;

namespace BookStore.Api.Repository
{
    public interface IBookRepository
    {
        //task of getting all books from db
        Task<List<BookModel>> GetAllBooksAsync();

        //task of getting one book from db by id
        Task<BookModel> GetBookByIdAsync(int BookId);

        //task of adding one book to db
        Task<int> AddBookAsync(BookModel bookModel);

        //task of updating an existing book
        Task UpdateBookAsync(int BookId, BookModel bookModel);
    }
}
