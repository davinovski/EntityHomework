using EntityHomework.Data;
using EntityHomework.Models;
using EntityHomework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityHomework.Persistence
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(EntityHomeworkContext context) : base(context)
        { }

        public Book GetBookWithAuthor(int id)
        {
            return Context.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
        }

        public Book Update(int id, Book entity)
        {

            Book book = Context.Books.Where(b => b.Id == id).FirstOrDefault();

            book.Name = entity.Name;
            book.Description = entity.Description;
            book.Count = entity.Count;
            book.AuthorId = entity.AuthorId;
            book.Author = entity.Author;

            Context.SaveChanges();
            return book;
        }
    }
}