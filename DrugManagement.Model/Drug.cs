using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrugManagement.Model
{
    public class Drug
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Dosage { get; set; }

        [Required]
        public int CapsuleNumber { get; set; }

        public string Obs { get; set; }
    }
}
