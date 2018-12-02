using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SilverFrame.Model
{
    public class SilverFrameContext : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pictures.db");
        }
    }

    public class Picture
    {
        public int PictureId { get; set; }
        public string Url { get; set; }

       

    }

}