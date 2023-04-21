namespace SimpAcc.API.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IContactRepository Contact { get; }

        void CreateTransaction();
        void Commit();
        void Rollback();
    }
}
