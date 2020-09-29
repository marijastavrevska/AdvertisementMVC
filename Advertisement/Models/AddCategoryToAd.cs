using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advertisement.Models
{
    public class AddCategoryToAd
    {
        public int CategoryId { get; set; }
        public int AdId { get; set; }
        public List<Category> Categories { get; set; }
        public AddCategoryToAd()
        {
            Categories = new List<Category>();
        }
    }
}