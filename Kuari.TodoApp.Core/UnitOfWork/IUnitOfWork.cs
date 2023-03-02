namespace Kuari.TodoApp.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
