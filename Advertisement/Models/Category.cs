using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Advertisement.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
    }
}