using EntityFramework.Models;
using System;
using System.Collections.Generic;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Group group = new Group
                {
                    Name = "Rammstain",
                    Year = 1994
                };
                Group group2 = new Group
                {
                    Name = "Linkin Park",
                    Year = 1994
                };

                var songs = new List<Song>
                {
                    new Song { Name = "In the End", GroupId = group2.Id },
                    new Song { Name = "Numb", GroupId = group2.Id },
                    new Song { Name = "Mutter", GroupId = group.Id }
                };

                db.Songs.AddRange(songs);
                db.Add(group);
                db.SaveChanges();
            }
            using (AppDbContext db = new AppDbContext())
            {
                
            }
        }
    }
}
