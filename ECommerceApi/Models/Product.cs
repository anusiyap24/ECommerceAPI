using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<ProductAttribute> Attributes { get; set; }
    }

    public class ProductAttribute
    {
        public int Id { get; set; }
        public int ProductId { get; set; }  // Foreign key to Product
        public int AttributeId { get; set; }  // Foreign key to Attribute
        //public Attribute Attribute { get; set; }  // Navigation property for Attribute
    }

}
