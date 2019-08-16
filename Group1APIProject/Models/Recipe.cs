using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group1APIProject.Models
{


    public class Recipe
    {
        public string Title { get; set; }
        public float Version { get; set; }
        public string Href { get; set; }
        public Result[] Results { get; set; }
    }

    public class Result
    {
        public int ResultId { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public string Ingredients { get; set; }
        public string Thumbnail { get; set; }
    }

}
