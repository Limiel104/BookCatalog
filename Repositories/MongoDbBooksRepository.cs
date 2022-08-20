using System;
using System.Collections.Generic;
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

        public void CreateBook(Book book)
        {
            booksColletion.InsertOne(book);
        }

        public void DeleteBook(Guid id)
        {
            var filter = filterDefinitionBuilder.Eq(book => book.Id, id);
            booksColletion.DeleteOne(filter);
        }

        public Book GetBook(Guid id)
        {
            var filter = filterDefinitionBuilder.Eq(book => book.Id, id);
            return booksColletion.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Book> GetBooks()
        {
            return booksColletion.Find(new BsonDocument()).ToList();
        }

        public void UpdateBook(Book book)
        {
            var filter = filterDefinitionBuilder.Eq(existingBook => existingBook.Id, book.Id);
            booksColletion.ReplaceOne(filter, book);
        }
    }
}