using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankFull.Models
{
    public class PhotoSend
    {
        [Key]
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string Photo { get; set; } = null!;

        [NotMapped]

        public IFormFile PhotoPath { get; set; } =null!;

    }
}
