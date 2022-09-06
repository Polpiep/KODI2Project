using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KODI2Project.DB
{
    public class MyContext: DbContext
    {
        private string cs = "server=192.168.10.160;database=K_O_Artes_Test; user id=stud; password=stud";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(cs);
        }

        public DbSet<Users> Users2 { get; set; }
    }
}
