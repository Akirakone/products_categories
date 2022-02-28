using System;
using System.ComponentModel.DataAnnotations;
namespace products_categories.Models
{
    public class Association
    {
        [Key]
        public int Associationid { get; set; }

        public int Categoryid {get;set;}
        public Category Category {get;set;}

        public int Productid {get;set;}
        public Product Product {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}