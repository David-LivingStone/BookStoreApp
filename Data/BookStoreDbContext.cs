using BookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreDbContext:IdentityDbContext<ApplicationUser>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) :base(options)
        {

        }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<LendingModel> LendBooks { get; set; }
        public DbSet<OrderModel> OrderBooks { get; set; }
        
    }
}
