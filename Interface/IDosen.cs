namespace TesProgrammer.Interface
{
    using TesProgrammer.Models.DB;
    using System.Collections.Generic;

    public interface IDosen
    {
        bool Add(Dosen dosen);
        void AddDosenMatakuliah(int dosenId, int mataKuliahId);
        List<Matakuliah> GetAllMataKuliah();
    }
}
