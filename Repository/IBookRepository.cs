using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;

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

        //task of updating a property in an existing book
        Task UpdateBookPatchAsync(int BookId, JsonPatchDocument bookModel);

        //task of deleting an existing book from db
        Task DeleteBookAsync(int BookId);
    }
}
