using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace products_categories.Models
{
    public class Category
    {
        [Key]
        public int Categoryid { get; set; }
        [Required(ErrorMessage ="Product name Required.")]
        public string Categoryname { get; set; }
        public List<Association>Products {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}