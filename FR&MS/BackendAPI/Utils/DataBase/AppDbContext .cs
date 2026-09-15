using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace BackendAPI.Utils.DataBase; 
public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions): base(dbContextOptions) {
        
    }
    public DbSet<Ctest> cTest {  get; set; }
}
