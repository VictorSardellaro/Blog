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



            //CreateRole(connection);
            //ReadRoles(connection);
            //UpdateRole(connection);
            //DeleteRole(connection);

            //CreateTag(connection);
            //ReadTags(connection);
            //UpdateTag(connection);
            //DeleteTag(connection);

            //CreateUser(connection);
            ReadUsersWithRoles(connection);
            //ReadUsers(connection);
            //UpdateUser(connection);
            //DeleteUser(connection);

            connection.Close();
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Bio = "Equipe Teste03",
                Email = "teste03@hotmail.com",
                Image = "https://...",
                Name = "Equipe Teste03",
                PasswordHash = "HASH",
                Slug = "equipe-teste03"
            };
            using (connection)
            {
                connection.Insert<User>(user);
                System.Console.WriteLine("Cadastro de usuario realizado com sucesso");

            }
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                System.Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                    System.Console.WriteLine($" - {role.Name}");
            }
        }


        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                System.Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                    System.Console.WriteLine($" - {role.Slug}");
            }
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

        public static void CreateRole(SqlConnection connection)
        {
            var role = new Role()
            {
                Name = "Manager",
                Slug = "manager"
            };
            using (connection)
            {
                connection.Insert<Role>(role);
                System.Console.WriteLine("Cadastro de Role realizado com sucesso");

            }
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                System.Console.WriteLine(item.Name);
        }

        public static void UpdateRole(SqlConnection connection)
        {
            var role = new Role()
            {
                Id = 2,
                Name = "Manager2",
                Slug = "manager2"
            };
            using (connection)
            {
                connection.Update<Role>(role);
                System.Console.WriteLine("Atualização de role realizada com sucesso");
            }
        }

        public static void DeleteRole(SqlConnection connection)
        {

            using (connection)
            {
                var role = connection.Get<Role>(2);
                connection.Delete<Role>(role);
                System.Console.WriteLine("Role removido com sucesso");
            }
        }

        public static void CreateTag(SqlConnection connection)
        {
            var tag = new Tag()
            {
                Name = "ASP.NET CORE",
                Slug = "aspnetcore"
            };
            using (connection)
            {
                connection.Insert<Tag>(tag);
                System.Console.WriteLine("Cadastro de TAG realizado com sucesso");

            }
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                System.Console.WriteLine(item.Name);
        }

        public static void UpdateTag(SqlConnection connection)
        {
            var tag = new Tag()
            {
                Id = 2,
                Name = "ASP.NET CORE 2",
                Slug = "aspnetcore2"
            };
            using (connection)
            {
                connection.Update<Tag>(tag);
                System.Console.WriteLine("Atualização de TAG realizada com sucesso");
            }
        }

        public static void DeleteTag(SqlConnection connection)
        {

            using (connection)
            {
                var tag = connection.Get<Tag>(2);
                connection.Delete<Tag>(tag);
                System.Console.WriteLine("TAG removido com sucesso");
            }
        }






    }
}
