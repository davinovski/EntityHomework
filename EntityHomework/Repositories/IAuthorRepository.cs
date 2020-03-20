using EntityHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHomework.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorWithBooks(int id);

        Author Update(int id, Author author);
    }
}
