using TesProgrammer.Interface;
using TesProgrammer.Models;
using TesProgrammer.Models.DB;

namespace TesProgrammer.Services
{
    public class DosenServices : IDosen
    {
        private readonly ApplicationContext _context;

        public DosenServices(ApplicationContext context)
        {
            _context = context;
        }

        public bool Add(Dosen dosen)
        {
            try
            {
                _context.Dosens.Add(dosen);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void AddDosenMatakuliah(int dosenId, int mataKuliahId)
        {
            var relasi = new DosenMatakuliah
            {
                DosenId = dosenId,
                MataKuliahId = mataKuliahId
            };

            _context.DosenMataKuliahs.Add(relasi);
            _context.SaveChanges();
        }

        public List<Matakuliah> GetAllMataKuliah()
        {
            return _context.MataKuliahs.ToList();
        }
    }
}
