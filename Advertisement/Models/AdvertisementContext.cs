using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Advertisement.Models
{
    public class AdvertisementContext : DbContext
    {
        public DbSet<Ad> Ads { get; set; }

        public DbSet<Category> Categories { get; set; }

        public AdvertisementContext():base("DefaultConnection") { }

        public static AdvertisementContext Create()
        {
            return new AdvertisementContext();
        }
    }
}