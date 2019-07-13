using LibraryData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryData
{
    public class LibraryContext:IdentityDbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Book> Books { get; set; }
        DbSet<BranchHours> BranchHours { get; set; }
        DbSet<Checkout> Checkouts { get; set; }
        DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        DbSet<Holds> Holds { get; set; }
        DbSet<LibraryAsset> LibraryAssets { get; set; }
        DbSet<LibraryBranch> LibraryBranches { get; set; }
        DbSet<LibraryCard> LibraryCards { get; set; }
        DbSet<Patron> Patrons { get; set; }
        DbSet<Status> Status { get; set; }
        DbSet<Video> Videos { get; set; }

    }
}
