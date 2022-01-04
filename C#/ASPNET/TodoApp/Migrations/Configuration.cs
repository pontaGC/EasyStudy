namespace TodoApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TodoApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoApp.Models.ToDoItemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            // モデルのData削除された場合，自動マイグレーションを許可する
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TodoApp.Models.ToDoItemContext";
        }

        protected override void Seed(TodoApp.Models.ToDoItemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // 初期データを登録する
            var admin = new User()
            {
                Id = 1,
                UserName = "admin",
                Password = "password",
                Roles = new List<Role>(),
            };

            var ponta = new User()
            {
                Id = 2,
                UserName = "ponta",
                Password = "password",
                Roles = new List<Role>(),
            };

            var administrators = new Role()
            {
                Id = 1,
                RoleName = "Administrators",
                Users = new List<User>(),
            };

            var users = new Role()
            {
                Id = 2,
                RoleName = "Users",
                Users = new List<User>(),
            };

            admin.Roles.Add(administrators);
            administrators.Users.Add(admin);

            ponta.Roles.Add(users);
            users.Users.Add(ponta);

            context.Users.AddOrUpdate(user => user.Id, new User[] { admin, ponta });
            context.Roles.AddOrUpdate(role => role.Id, new Role[] { administrators, users });
        }
    }
}
