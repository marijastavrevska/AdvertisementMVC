using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advertisement.Models
{
    public class AddToCategoryModel
    {
        public int CategoryId { get; set; }
        public int AdId { get; set; }
        public List<Ad> Ads { get; set; }
        public AddToCategoryModel()
        {
            Ads = new List<Ad>();
        }
    }
}