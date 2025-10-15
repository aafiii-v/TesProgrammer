using TesProgrammer.Interface;
using TesProgrammer.Models;
using TesProgrammer.Models.DB;

namespace TesProgrammer.Services
{
    public class MataKuliahServices : IMataKuliah
    {
        private readonly ApplicationContext _context;

        public MataKuliahServices(ApplicationContext context)
        {
            _context = context;
        }

        public List<Matakuliah> GetAll()
        {
            return _context.MataKuliahs.ToList();
        }

        public bool Add(Matakuliah mk)
        {
            try
            {
                _context.MataKuliahs.Add(mk);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
