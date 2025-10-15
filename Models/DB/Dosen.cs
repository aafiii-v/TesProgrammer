using System.ComponentModel.DataAnnotations;

namespace TesProgrammer.Models.DB
{
    public class Dosen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string KodeDosen { get; set; }

        [Required]
        public string NamaDosen { get; set; }

        public int? TahunPensiun { get; set; }

        public List<DosenMatakuliah> DosenMataKuliahs { get; set; } = new List<DosenMatakuliah>();
    }
}
