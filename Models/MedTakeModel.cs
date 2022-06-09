using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedManager.Models
{
    [Table("Medtakes")]
    public class MedTakeModel
    {
        [Key]
        public int MedId { get; set; }
        [DisplayName("Medication name")]
        [Required(ErrorMessage = "The name of the medication is required.")]
        [MaxLength(50)]
        public string? Name { get; set; }
        [DisplayName("Dose")]
        [Required(ErrorMessage = "The dose of medication is required.")]
        [MaxLength(2000)]
        public string? Dose { get; set; }
        [DisplayName("What time")]
        [MaxLength(50)]
        public string? Hour { get; set; }
        public bool Done { get; set; }

        }
}
