namespace ChateauDreams.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                // If the database is empty, populate sample data in it

                CreateUser(context, "admin@gmail.com", "123", "System Administrator");
                CreateUser(context, "rosi@gmail.com", "123", "Rositsa Apostolova");
                CreateUser(context, "sasho@gmail.com", "123", "Aleksandar Lazarov");
                CreateUser(context, "adrian@gmail.com", "123", "Adrian Mladenov");

                CreateRole(context, "Administrators");
                AddUserToRole(context, "admin@gmail.com", "Administrators");

                CreateReview(context,
                    title: "Really great place",
                    text: @"<p>Exceptional view.Delicious wines.Excellent Sunday lunch.
                   Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.
                    </p>",
                    date: new DateTime(2016, 03, 27, 17, 53, 48),
                    authorUsername: "rosi@gmail.com"
                );

                CreateReview(context,
                    title: "Really great place",
                    text: @"<p>Exceptional view.Delicious wines.Excellent Sunday lunch.
                   Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.
                    </p>",
                    date: new DateTime(2016, 05, 11, 08, 22, 03),
                    authorUsername: "sasho@gmail.com"
                );

                CreateReview(context,
                    title: "Really great place",
                    text: @"<p>Exceptional view.Delicious wines.Excellent Sunday lunch.
                   Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.
                    </p>",
                    date: new DateTime(2016, 03, 27, 17, 53, 48),
                    authorUsername: "rosi@gmail.com"
                );

                CreateReview(context,
                    title: "Really great place",
                     text: @"<p>Exceptional view.Delicious wines.Excellent Sunday lunch.
                   Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.
                    </p>",
                    date: new DateTime(2016, 02, 18, 22, 14, 38),
                    authorUsername: "adrian@gmail.com"
                );

                CreateReview(context,
                    title: "Really great place",
                     text: @"<p>Exceptional view.Delicious wines.Excellent Sunday lunch.
                   Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.
                    </p>",
                    date: new DateTime(2016, 04, 11, 19, 02, 05),
                    authorUsername: "sasho@gmail.com"
                );

                CreateReview(context,
                    title: "Really great place",
                   text: @"<p>Exceptional view.Delicious wines.Excellent Sunday lunch.
                   Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.Exceptional view.Delicious wines.Excellent Sunday lunch.
                    </p>",
                    date: new DateTime(2016, 06, 30, 17, 36, 52),
                    authorUsername: "adrian@gmail.com"
                );

                context.SaveChanges();
            }
        }

        private void CreateUser(ApplicationDbContext context,
            string email, string password, string fullName)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole(ApplicationDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreateReview(ApplicationDbContext context,
            string title, string text, DateTime date, string authorUsername)
        {
            var review = new Review();
            review.Title = title;
            review.Text = text;
            review.Date = date;
            review.Author = context.Users.Where(u => u.UserName == authorUsername).FirstOrDefault();
            context.Reviews.Add(review);
        }
    }
}
