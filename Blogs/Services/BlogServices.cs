using Blogs.Helpers;
using Blogs.Models;
using System.Data;

namespace Blogs.Services
{
    public class BlogServices : IBaseServices<Blog>
    {
        public int Create(Blog data)
        {
            string query = $"INSERT INTO Blogs VALUES (N'{data.Title}', N'{data.Description}', {data.UserId})";
            return SqlHelper.Exec(query);
        }

        public int Delete(int id)
        {
            string query = $"DELETE Blogs WHERE Id = {id}";
            return SqlHelper.Exec(query);
        }

        public List<Blog> GetAll()
        {
            DataTable dt = SqlHelper.GetDatas("SELECT * FROM Blogs");
            List<Blog> list = new List<Blog>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Blog
                {
                    Id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Description = (string)row["Description"],
                    UserId = (int)row["UserId"]
                });
            }
            return list;
        }

        public Blog GetById(int id)
        {
            DataTable dt = SqlHelper.GetDatas($"SELECET * FROM Blogs WHERE Id={id}");
            foreach (DataRow row in dt.Rows)
            {
                Blog blog = new Blog
                {
                    Id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Description = (string)row["Description"],
                    UserId = (int)row["UserId"]
                };
                return blog;
            }
            return null;
        }

        public List<Blog> GetWhere(string query)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Blog data)
        {
            string query = $"UPDATE Blogs SET Title = N'{data.Title}', Description = N'{data.Description}', UserId = {data.UserId} WHERE Id = {id}";
            return SqlHelper.Exec(query);
        }
    }
}