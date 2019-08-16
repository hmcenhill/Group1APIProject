using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1APIProject.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public virtual DbSet<UserData> Users { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeFavorite> RecipeFavorites { get; set; }

        //public virtual DbSet<TicketmasterEvent> TicketmasterEvents { get; set; }
        //public virtual DbSet<TicketmasterEventFavorite> TicketmasterEventFavorites { get; set; }

    }
}
