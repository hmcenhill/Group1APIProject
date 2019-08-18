using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Group1APIProject.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public virtual DbSet<UserData> Users { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<RecipeFavorite> RecipeFavorites { get; set; }

        internal Task GetUserIdAsync(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        //public virtual DbSet<TicketmasterEvent> TicketmasterEvents { get; set; }
        //public virtual DbSet<TicketmasterEventFavorite> TicketmasterEventFavorites { get; set; }

    }
}
