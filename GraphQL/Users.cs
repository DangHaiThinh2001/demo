using System.ComponentModel.DataAnnotations;

namespace demo.GraphQL
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }    
    }
}
