using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHomework.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        int Complete();
    }
}
