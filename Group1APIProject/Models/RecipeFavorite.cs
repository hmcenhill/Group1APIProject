using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1APIProject.Models
{
    public class RecipeFavorite
    {
        public int RecipeFavoriteId { get; set; }
        public int UserDataId { get; set; }
        public UserData UserData { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }

    }
}
