using NHibernate;
using System;

namespace ServiceDesk.API.Infrastructure.Infra.NHibernate
{
    public class TransactionBootstrap
    {
        private readonly ISession session;
        private ITransaction transaction;

        public TransactionBootstrap(ISession session) => this.session = session;
        public void Begin()
        {
            if (transaction != null)
                throw new InvalidOperationException("Já existe uma transação iniciada!");

            if (transaction == null)
                transaction = session.BeginTransaction();

        }
        public void Commit()
        {
            try
            {
                if (transaction == null)
                    throw new InvalidOperationException("Você deve iniciar uma transação antes de confirma-lá!");

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ex = ex.InnerException ?? ex;
                throw ex;
            }
        }
    }
}
