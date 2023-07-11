using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Starpholio.Areas.Identity.Data;
using Starpholio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starpholio.Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<IdentityResult> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var result = await manager.CreateAsync(this);

            // Add custom user claims here

            return result;
        }
    }

    public class StarpholioContext : IdentityDbContext<UserInfo>
    {
        public StarpholioContext(DbContextOptions<StarpholioContext> options)
            : base(options)
        {
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Votes> Votes { get; set; }
        public DbSet<CategoriesColour> CategoriesColour { get; set; }
        public DbSet<CategoriesStyle> CategoriesStyle { get; set; }
        public DbSet<Users1> Users1 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationships, constraints, and other configurations

            
        }
    }

    public static class DatabaseSeeder
    {


        public static void SeedData(StarpholioContext context, IServiceScopeFactory scopeFactory)
        {
            

            using var scope = scopeFactory.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<StarpholioContext>();

        }

        private static async Task SeedUsers(StarpholioContext context, UserManager<UserInfo> userManager)
        {
            var users = new List<UserInfo>
    {
        new UserInfo { UserName = "Vasco", Email = "Vasco.Borges@gmail.com" },
        new UserInfo { UserName = "André", Email = "Andre.Santos@gmail.com" },
        new UserInfo { UserName = "Emanuel", Email = "Emanuel.Santos@gmail.com" }
    };

            foreach (var user in users)
            {
                if (!context.Users.Any(u => u.Email == user.Email))
                {
                    var result = await userManager.CreateAsync(user, "Teste!234");

                    if (result.Succeeded)
                    {
                        // Add any additional user properties or claims here

                        await userManager.AddToRoleAsync(user, "UserRole");
                    }
                }
            }
        }

        private static void SeedCategoriesColour(StarpholioContext context)
        {
            var categoriesColour = new List<CategoriesColour>
            {
                new CategoriesColour
                {
                    ID = 1,
                    categoriesColour = new HashSet<CategoryColour>
                    {
                        new CategoryColour { ID = 1, Name = "Monochromatic" }
                    }
                },
                new CategoriesColour
                {
                    ID = 2,
                    categoriesColour = new HashSet<CategoryColour>
                    {
                        new CategoryColour { ID = 2, Name = "Coloured" }
                    }
                },
                new CategoriesColour
                {
                    ID = 3,
                    categoriesColour = new HashSet<CategoryColour>
                    {
                        new CategoryColour { ID = 3, Name = "Negative" }
                    }
                }
            };

            foreach (var category in categoriesColour)
            {
                if (!context.CategoriesColour.Any(c => c.ID == category.ID))
                {
                    context.CategoriesColour.Add(category);
                }
            }

            context.SaveChanges();
        }

        private static void SeedCategoriesStyle(StarpholioContext context)
        {
            var categoriesStyle = new List<CategoriesStyle>
            {
                new CategoriesStyle
                {
                    ID = 1,
                    categoriesStyle = new HashSet<CategoryStyle>
                    {
                        new CategoryStyle { ID = 1, Name = "Urban" }
                    }
                },
                new CategoriesStyle
                {
                    ID = 2,
                    categoriesStyle = new HashSet<CategoryStyle>
                    {
                        new CategoryStyle { ID = 2, Name = "Nature" }
                    }
                },
                new CategoriesStyle
                {
                    ID = 3,
                    categoriesStyle = new HashSet<CategoryStyle>
                    {
                        new CategoryStyle { ID = 3, Name = "Portrait" }
                    }
                },
                new CategoriesStyle
                {
                    ID = 4,
                    categoriesStyle = new HashSet<CategoryStyle>
                    {
                        new CategoryStyle { ID = 4, Name = "Landscape" }
                    }
                },
                new CategoriesStyle
                {
                    ID = 5,
                    categoriesStyle = new HashSet<CategoryStyle>
                    {
                        new CategoryStyle { ID = 5, Name = "Skyline" }
                    }
                }
            };

            foreach (var category in categoriesStyle)
            {
                if (!context.CategoriesStyle.Any(c => c.ID == category.ID))
                {
                    context.CategoriesStyle.Add(category);
                }
            }

            context.SaveChanges();
        }

        private static void SeedPosts(StarpholioContext context)
        {
            var posts = new List<Posts>
            {
                new Posts
                {
                    ID = 1,
                    title = "Beautiful city skyline",
                    content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Image = "Image.png",
                    Hidden = false,
                    Deleted = false,
                    UtilizadorId = 1,
                    CategoriesColourId = 1,
                    CategoriesStyleId = 5
                },
                new Posts
                {
                    ID = 2,
                    title = "Beautiful mountain pic",
                    content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Image = "image2.png",
                    Hidden = false,
                    Deleted = false,
                    UtilizadorId = 2,
                    CategoriesColourId = 2,
                    CategoriesStyleId = 2
                },
                new Posts
                {
                    ID = 3,
                    title = "Selfie experiment!",
                    content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Image = "image3.png",
                    Hidden = false,
                    Deleted = false,
                    UtilizadorId = 3,
                    CategoriesColourId = 3,
                    CategoriesStyleId = 3
                }
            };

            foreach (var post in posts)
            {
                if (!context.Posts.Any(p => p.ID == post.ID))
                {
                    context.Posts.Add(post);
                }
            }

            context.SaveChanges();
        }

        private static void SeedComments(StarpholioContext context)
        {
            var comments = new List<Comments>
            {
                new Comments
                {
                    ID = 1,
                    Comment = "Comment 1",
                    DataDoComentario = DateTime.Now,
                    UtilizadorId = 2,
                    PostId = 1
                },
                new Comments
                {
                    ID = 2,
                    Comment = "Comment 2",
                    DataDoComentario = DateTime.Now,
                    UtilizadorId = 3,
                    PostId = 1
                },
                new Comments
                {
                    ID = 3,
                    Comment = "Comment 3",
                    DataDoComentario = DateTime.Now,
                    UtilizadorId = 1,
                    PostId = 2
                }
            };

            foreach (var comment in comments)
            {
                if (!context.Comments.Any(c => c.ID == comment.ID))
                {
                    context.Comments.Add(comment);
                }
            }

            context.SaveChanges();
        }

        private static void SeedVotes(StarpholioContext context)
        {
            var votes = new List<Votes>
            {
                new Votes { ID = 1, UserFK = 1, PostId = 2 },
                new Votes { ID = 2, UserFK = 2, PostId = 2 },
                new Votes { ID = 3, UserFK = 2, PostId = 3 }
            };

            foreach (var vote in votes)
            {
                if (!context.Votes.Any(v => v.ID == vote.ID))
                {
                    context.Votes.Add(vote);
                }
            }

            context.SaveChanges();
        }
    }
}
