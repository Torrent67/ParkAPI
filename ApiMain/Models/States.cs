using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMain.Models
{
    [Table("states")]
    public class States
    {

        public States()
        {
            this.Parks = new HashSet<Park>();
        }
        [Key]
        public int StateId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Range(0,11)]
        
        
        public ICollection<Park> Parks { get; set; }

    }
}