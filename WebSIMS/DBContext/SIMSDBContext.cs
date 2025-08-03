using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebSIMS.DBContext.Entities;

namespace WebSIMS.BDContext
{
    public class SIMSDBContext : DbContext
    {
        public SIMSDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Courses> CoursesDb { get; set; }
        public DbSet<Courses> UsersDb { get; set; }


    }
}
