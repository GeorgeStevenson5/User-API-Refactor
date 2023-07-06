using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tests.User.Api.Models
{
    [Table("users")]
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //Age changed to type integer
        [Required]
        public int Age { get; set; }
    }
}
