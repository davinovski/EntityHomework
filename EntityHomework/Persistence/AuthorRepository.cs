using EntityHomework.Data;
using EntityHomework.Models;
using EntityHomework.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityHomework.Persistence
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(EntityHomeworkContext context) : base(context)
        { }

        public Author GetAuthorWithBooks(int id)
        {
            return Context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
        }

        public Author Update(int id, Author entity)
        {
            Author author = Context.Authors.Where(a => a.Id == id).FirstOrDefault();
            author.Name = entity.Name;
            Context.SaveChanges();
            Context.Entry(author).Collection(a => a.Books).Load();
            return author;

        }
    }
}