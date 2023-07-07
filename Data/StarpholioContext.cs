
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using Starpholio.Areas.Identity.Data;
using Starpholio.Models;


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

        

    }
}