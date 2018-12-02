using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace SilverFrame.Model
{
    class Model : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Picture.db");
        }
    }

    public class Picture
    {
        public int PictureID { get; set; }
    }
}
