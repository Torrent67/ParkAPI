using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMain.Models
{
    [Table("parks")]
    public class Park
    {
        [Key]
        public int ParkId { get; set; }
        public int StateId { get; set; }
        [Required]
        public string ParkText { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0,10)]
        public int Rating { get; set; }
    }
}