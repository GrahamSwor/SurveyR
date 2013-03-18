using NHibernate;

namespace SurveyR.Core.Contracts.Infrastructure
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
        ISession CurrentSession { get; set; }
    }
}