using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TesProgrammer.Models.DB
{
    public class DosenMatakuliah
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Dosen")]
        public int DosenId { get; set; }

        [ForeignKey("MataKuliah")]
        public int MataKuliahId { get; set; }

        public Dosen Dosen { get; set; }
        public Matakuliah MataKuliah { get; set; }
    }
}
