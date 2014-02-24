using DrugManagement.Model;

namespace DrugManagement.Data.Contracts
{
    public interface ILeadsUow
    {
        int Commit();
        IRepository<Drug> Parceiros { get; }
    }
}
