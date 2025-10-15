using System.ComponentModel.DataAnnotations;

namespace TesProgrammer.Models.DB
{
    public class Matakuliah
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string KodeMataKuliah { get; set; }

        [Required]
        public string NamaMataKuliah { get; set; }
    }
}