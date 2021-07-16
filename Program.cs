using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost, 1433; Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            //ReadUsers(connection);
            //ReadRoles(connection);
            //ReadTags(connection);
            //ReadUser();
            //CreateUser(connection);
            //UpdateUser(connection);
            DeleteUser(connection);

            connection.Close();
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Bio = "Equipe Teste02",
                Email = "teste02@hotmail.com",
                Image = "https://...",
                Name = "Equipe Teste02",
                PasswordHash = "HASH",
                Slug = "equipe-teste02"
            };
            using (connection)
            {
                connection.Insert<User>(user);
                System.Console.WriteLine("Cadastro realizado com sucesso");

            }
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
                System.Console.WriteLine(item.Name);
        }

        public static void UpdateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Id = 3,
                Bio = "Equipe de suporte",
                Email = "Suporte@hotmail.com",
                Image = "https://...",
                Name = "Equipe de suporte",
                PasswordHash = "HASH",
                Slug = "equipe-suporte"
            };
            using (connection)
            {
                connection.Update<User>(user);
                System.Console.WriteLine("Atualização realizada com sucesso");
            }
        }

        public static void DeleteUser(SqlConnection connection)
        {

            using (connection)
            {
                var user = connection.Get<User>(3);
                connection.Delete<User>(user);
                System.Console.WriteLine("Usuario removido com sucesso");
            }
        }



        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                System.Console.WriteLine(item.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                System.Console.WriteLine(item.Name);
        }




    }
}
