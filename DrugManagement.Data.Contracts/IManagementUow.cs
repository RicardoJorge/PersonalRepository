using DrugManagement.Model;

namespace DrugManagement.Data.Contracts
{
    public interface IManagementUow
    {
        int Commit();
        IRepository<Drug> Drugs { get; }
    }
}
