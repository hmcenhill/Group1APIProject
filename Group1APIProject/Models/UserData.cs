using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1APIProject.Models
{
    public class UserData
    {
        public int UserDataID { get; set; }
        public string UserName { get; set; }
        public ICollection<RecipeFavorite> RecipeFavorites { get; set; }

        //public ICollection<TicketmasterEventFavorite> TicketmasterEventFavorites { get; set; }

        public UserData(string userName)
        {
            UserName = userName;
        }
    }
}