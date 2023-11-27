using Blogs.Helpers;
using Blogs.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Blogs.Services
{
    public static class UserServices
    {
        //const int keySize = 64;
        //const int iterations = 350000;

        //static string HashPassword(string password, out byte[] salt)
        //{
        //    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        //    salt = RandomNumberGenerator.GetBytes(keySize);

        //    var hash = Rfc2898DeriveBytes.Pbkdf2(
        //    Encoding.UTF8.GetBytes(password),
        //    salt,
        //    iterations,
        //    hashAlgorithm,
        //    keySize);

        //    return Convert.ToHexString(hash);
        //}

        public static int Register(User data)
        {
            //var hashedpass = HashPassword(data.Password, out var salt);
            //string query = $"INSERT INTO Users VALUES (N'{data.Name}', N'{data.Surname}', N'{data.Username}', {hashedpass} ";
            string query = $"INSERT INTO Users VALUES (N'{data.Name}', N'{data.Surname}', N'{data.Username}', N'{data.Password}' ";
            return SqlHelper.Exec(query);
        }

        public static bool Login()
        {
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            //var password = HashPassword(Console.ReadLine(), out var salt);
            string password = Console.ReadLine();

            string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}' ";
            int countRows = SqlHelper.GetDatas(query).Rows.Count;
            if (countRows > 0)
            {
                Console.WriteLine("Login");
                return true;
            }
            else
            {
                Console.WriteLine("Wrong Username or Password!!");
                return false;
            }
        }

        public static int Delete(int id)
        {
            string query = $"DELETE Users WHERE Id = {id}";
            return SqlHelper.Exec(query);
        }

        public static int Edit(int id, User data)
        {
            string query = $"UPDATE Users SET Name = N'{data.Name}', Surname = N'{data.Surname}', Username = N'{data.Username}', Password = N'{data.Password}' WHERE Id = {id}";
            return SqlHelper.Exec(query);
        }
    }
}