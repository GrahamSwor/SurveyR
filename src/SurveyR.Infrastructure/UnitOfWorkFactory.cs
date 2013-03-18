using NHibernate;
using SurveyR.Core;
using SurveyR.Core.Contracts.Infrastructure;

namespace SurveyR.Infrastructure
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