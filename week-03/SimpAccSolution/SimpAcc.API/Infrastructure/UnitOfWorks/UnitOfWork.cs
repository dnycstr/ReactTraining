using SimpAcc.API.Application.Interfaces;

namespace SimpAcc.API.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseSession _dbSession;

        private readonly IContactRepository _contactRepository;               

        public UnitOfWork(DatabaseSession dbSession, IContactRepository contactRepository) 
        { 
            _dbSession = dbSession;     
            _contactRepository = contactRepository;
        }

        public IContactRepository Contact => _contactRepository;

        public void Dispose()
        {
            _dbSession.Transaction?.Dispose();
        }

        public void CreateTransaction()
        {
            if (_dbSession.Connection != null)
            {
                _dbSession.Transaction = _dbSession.Connection.BeginTransaction();
            }
            else 
            {
                throw new Exception("Database Session is null");
            }
        }

        public void Commit()
        {
            if (_dbSession.Transaction != null)
                _dbSession.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            if (_dbSession.Transaction != null)
                _dbSession.Transaction.Rollback();
            Dispose();
        }
    }
}
