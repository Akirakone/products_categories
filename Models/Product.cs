using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace products_categories.Models

{
    public class Product
    {
        [Key]
        public int Productid { get; set; }

        [Required(ErrorMessage ="Product name Required.")]
        public string Productname { get; set; }
        
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Price must be more than 0.")]
        public Decimal Price { get; set; }

        [Required (ErrorMessage ="product must have a description.")]
        public string description { get; set; }

        public List<Association> Categories {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}