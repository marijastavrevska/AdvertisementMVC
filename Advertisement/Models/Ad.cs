using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Advertisement.Models
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Display(Name="Image")]
        public string ImgUrl { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        public Category category { get; set; }

    }
}