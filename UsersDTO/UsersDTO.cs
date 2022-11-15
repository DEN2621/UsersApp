using System.ComponentModel.DataAnnotations.Schema;

namespace UsersDTO
{
    public class UsersDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
