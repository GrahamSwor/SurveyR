using NHibernate;

namespace SurveyR.Tests
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            throw new System.NotImplementedException();
        }

        public ISession CurrentSession { get; set; }
    }
}