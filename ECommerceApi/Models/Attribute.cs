using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Models
{
    public class AttributeValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AttributeValue> Values { get; set; }
    }
}
