using EntityHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHomework.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBookWithAuthor(int id);

        Book Update(int id, Book author);
    }
}
