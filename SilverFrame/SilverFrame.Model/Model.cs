using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace SilverFrame.Model
{
    public static class Model
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=picture.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
    }

    //public static class Model : DbContext
    //{
    //    public DbSet<Picture> Pictures { get; set; }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlite("Data Source=silverFrame.db");
    //    }
    //}

    //public class Picture
    //{
    //    public int localPictureId { get; set; }
    //    public string googlePhotosId { get; set; }
    //    public string baseUrl { get; set; }
    //    public string mimeType { get; set; }
    //    public string mediaMetadata { get; set; }

    //}
}