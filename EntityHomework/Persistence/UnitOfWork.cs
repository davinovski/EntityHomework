using EntityHomework.Data;
using EntityHomework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityHomework.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityHomeworkContext _context;

        public UnitOfWork()
        {
            _context = new EntityHomeworkContext();
            Books = new BookRepository(_context);
            Authors = new AuthorRepository(_context);
        }

        public IBookRepository Books { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}