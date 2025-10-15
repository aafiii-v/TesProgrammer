using TesProgrammer.Models.DB;

namespace TesProgrammer.Interface
{
    public interface IMataKuliah
    {
        List<Matakuliah> GetAll();
        bool Add(Matakuliah mk);
    }
}
