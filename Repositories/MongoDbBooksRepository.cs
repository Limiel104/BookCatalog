using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookCatalog.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookCatalog.Repositories
{
    public class MongoDbBooksRepository : IBooksRepository
    {
        private const string databaseName = "bookCatalog";
        private const string collectionName = "books";
        private readonly IMongoCollection<Book> booksColletion;

        private readonly FilterDefinitionBuilder<Book> filterDefinitionBuilder = Builders<Book>.Filter;

        public MongoDbBooksRepository(IMongoClient mongoClient)
        {
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
            booksColletion = mongoDatabase.GetCollection<Book>(collectionName);
        }

        public async Task CreateBookAsync(Book book)
        {
            await booksColletion.InsertOneAsync(book);
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var filter = filterDefinitionBuilder.Eq(book => book.Id, id);
            await booksColletion.DeleteOneAsync(filter);
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var filter = filterDefinitionBuilder.Eq(book => book.Id, id);
            return await booksColletion.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await booksColletion.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            var filter = filterDefinitionBuilder.Eq(existingBook => existingBook.Id, book.Id);
            await booksColletion.ReplaceOneAsync(filter, book);
        }
    }
}