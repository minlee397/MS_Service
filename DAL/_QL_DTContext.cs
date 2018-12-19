using Microsoft.EntityFrameworkCore;
using QL_DT.Models;

namespace QL_DT.DAL
{
    public class _QL_DTContext : DbContext
    {
        public _QL_DTContext(DbContextOptions<_QL_DTContext> options): base (options){
            this.Database.EnsureCreated();            
        }

        // Khai bao cac doi tuong trong database
        public DbSet<Product> Products {get; set;}
        public DbSet<Account> Accounts {get; set;}
        public DbSet<Receipt_Note> Receipt_Notes {get; set;}
        public DbSet<Detail_Receipt> Detail_Receipts {get; set;}
    }
}