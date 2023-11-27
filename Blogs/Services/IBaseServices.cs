using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogs.Services
{
    public interface IBaseServices <T>
    {
        List<T> GetAll();
        List<T> GetWhere(string query);
        T GetById(int id);
        int Create(T data);
        int Update(int id, T data);
        int Delete(int id);
    }
}
