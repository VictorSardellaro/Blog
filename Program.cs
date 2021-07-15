﻿using System;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost, 1433; Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            //ReadUsers();
            //ReadUser();
            //CreateUser();
            //UpdateUser();
            //DeleteUser();
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();
                foreach (var user in users)
                {
                    System.Console.WriteLine(user.Name);
                }
            }
        }


        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);
                System.Console.WriteLine(user.Name);
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Equipe Teste",
                Email = "eteste@hotmail.com",
                Image = "https://...",
                Name = "Equipe Teste",
                PasswordHash = "HASH",
                Slug = "equipe-teste"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                System.Console.WriteLine("Cadastro realizado com sucesso");


            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Equipe de suporte",
                Email = "Suporte@hotmail.com",
                Image = "https://...",
                Name = "Equipe de suporte",
                PasswordHash = "HASH",
                Slug = "equipe-suporte"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);
                System.Console.WriteLine("Atualização realizada com sucesso");
            }
        }

        public static void DeleteUser()
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);
                System.Console.WriteLine("Deleção realizada com sucesso");
            }
        }
    }
}
