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
        public ICollection<int> FavoriteRecipeIds { get; set; }
        public ICollection<int> FavoriteEventIds { get; set; }

    }
}
