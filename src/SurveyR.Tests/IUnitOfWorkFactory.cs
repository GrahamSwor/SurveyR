using NHibernate;

namespace SurveyR.Tests
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
        ISession CurrentSession { get; set; }
    }
}