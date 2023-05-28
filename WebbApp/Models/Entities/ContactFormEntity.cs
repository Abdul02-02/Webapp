using System.ComponentModel.DataAnnotations;

namespace Webbapp.Models.Entities
{
    public class ContactFormEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
